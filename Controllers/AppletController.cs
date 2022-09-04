

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


[Route("[controller]/[action]")]
public class AppletController: Controller
{

    private static HashSet<string> PrimitiveTypeNames = new HashSet<string>() {
            "String", "Boolean", "Double", "Int16", "Int32", "Int64", "UInt16", "UInt32", "UInt64" };
    private static HashSet<string> ObjectMethods = new HashSet<string>() {
            "GetHashCode", "Equals", "ToString", "GetType", "ReferenceEquals" };

    private ConcurrentDictionary<string, Func<AppletController, object>> _provider =
        new ConcurrentDictionary<string, Func<AppletController, object>>();
     


    public MyControllerModel GetController(object subject)
        => GetController(subject, new List<string>());

    public void AddHttpClient(Type ControllerInterface)
        => this.Info($"{ControllerInterface.Name}");

    private MyControllerModel GetController(object subject, List<string> path)
    {
        Type type = subject.GetType();
        string url = "https://";
        path.ForEach((s1) => {
            url = $"{url}/{s1}";
        });
        var ctrl = new MyControllerModel()
        {
            Name = type.Name,
            Path = url
        };
        foreach (MethodInfo info in type.GetMethods())
        {
            if (info.IsPublic && !ObjectMethods.Contains(info.Name))
            {
                List<string> actionPath = new List<string>(path);
                actionPath.Add(info.Name);

                ctrl.Actions[info.Name] = new MyActionModel()
                {
                    Name = info.Name,
                    Path = info.Name.ToKebabStyle(),
                };
                Dictionary<string, object> args = new Dictionary<string, object>();
                foreach (ParameterInfo pinfo in info.GetParameters())
                {
                    ctrl.Actions[info.Name].Parameters[pinfo.Name] = new MyParameterDeclarationModel()
                    {
                        Type = pinfo.ParameterType.Name,
                        IsOptional = pinfo.IsOptional,
                        Name = pinfo.Name
                    };
                }
            }
        }
        foreach (FieldInfo info in type.GetFields())
        {
            if (info.IsPublic)
            {
                if (!info.GetType().IsPrimitive && !PrimitiveTypeNames.Contains(info.GetType().Name))
                {
                    List<string> childPath = new List<string>(path);
                    childPath.Add(info.Name);
                    ctrl.Actions[info.Name] = GetController(info.GetValue(subject), childPath);
                }
            }
        }
        return ctrl;
    }


    /**
     * Метод получения семантики public-методов обьекта
     */
    private object GetSkeleton(object subject, List<string> path)
    {

        Dictionary<string, object> actionMetadata = new Dictionary<string, object>();
        if (subject == null || subject.GetType().IsPrimitive || PrimitiveTypeNames.Contains(subject.GetType().Name))
        {
            return actionMetadata;
        }
        else
        {
            if (subject is Dictionary<string, object>)
            {
                actionMetadata = GetSkeletonFromDictionary((Dictionary<string, object>)subject, path);
            }
            else
            {
                //Debug.WriteLine(JObject.FromObject(subject));
                Type type = subject.GetType();
                //Debug.WriteLine(type.Name, path);

                actionMetadata = GetSkeletonFromType(type, path);

            }
        }

        return actionMetadata;
    }




    /////
    public Dictionary<string, object> GetSkeletonFromType(object subject, List<string> path)
    {
        Type type = subject.GetType();
        var actionMetadata = new Dictionary<string, object>();
        foreach (MethodInfo info in type.GetMethods())
        {
            if (info.IsPublic && !ObjectMethods.Contains(info.Name))
            {
                Dictionary<string, object> args = new Dictionary<string, object>();
                foreach (ParameterInfo pinfo in info.GetParameters())
                {
                    args[pinfo.Name] = new
                    {
                        type = pinfo.ParameterType.Name,
                        optional = pinfo.IsOptional,
                        name = pinfo.Name
                    };
                }
                List<string> actionPath = new List<string>(path);
                actionPath.Add(info.Name);

                actionMetadata[info.Name] = new
                {
                    type = "method",
                    path = actionPath,
                    args = args
                };
            }
        }
        foreach (FieldInfo info in type.GetFields())
        {
            if (info.IsPublic)
            {
                if (!info.GetType().IsPrimitive && !PrimitiveTypeNames.Contains(info.GetType().Name))
                {
                    List<string> childPath = new List<string>(path);
                    childPath.Add(info.Name);
                    actionMetadata[info.Name] = GetSkeleton(info.GetValue(subject), childPath);
                }
            }
        }
        return actionMetadata;
    }



    ////
    public Dictionary<string, object> GetSkeletonFromDictionary(Dictionary<string, object> subject, List<string> path)
    {
        Dictionary<string, object> actionMetadata = new Dictionary<string, object>();
        foreach (var kv in ((Dictionary<string, object>)subject))
        {
            actionMetadata[kv.Key] = kv.Value;
            if (!kv.Value.GetType().IsPrimitive && !PrimitiveTypeNames.Contains(kv.Value.GetType().Name))
            {

                List<string> childPath = new List<string>(path);
                childPath.Add(kv.Key);
                actionMetadata[kv.Key] = GetSkeleton(kv.Value, childPath);
            }
        };
        return actionMetadata;
    }



    

    [NonAction]
    public object GetService(Type serviceType)
    {
        var constructor = GetDefaultConstructor(serviceType);
        if (constructor == null)
        {
            throw new Exception("Не определён конструктор по-умолчанию для типа " + serviceType.Name);
        }
        else
        {

            return constructor.Invoke(new object[] { });
        }
    }



    public ConstructorInfo GetDefaultConstructor(Type type)
    {
        return (from c in new List<ConstructorInfo>(type.GetConstructors()) where c.GetParameters().Length == 0 select c).FirstOrDefault();
    }





    /// <summary>
    /// Программная утилита коммандной строки
    /// </summary>
    public void Run()
    {
        string command = "services list";
        while (command != "exit")
        {
            Console.WriteLine("Введите тип контроллера");

            try
            {

                string typeName = Console.ReadLine();
                if (typeName == null)
                {
                    Console.WriteLine("Тип не найден");
                }
                else
                {
                    Type type = FactoryUtils.Get().TypeForName(typeName);
                    object instance = FactoryUtils.Get().CreateWithDefaultConstructor<object>(type);
                    object skeleton = GetSkeleton(instance, new List<string>());
                    Console.WriteLine(
                        JsonConvert.SerializeObject(skeleton, new JsonSerializerSettings())
                    ); ;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

}

