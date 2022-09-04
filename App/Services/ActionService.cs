
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;


/// <summary>
/// 
/// </summary>
public class ActionService
{
    private HashSet<string> PrimitiveTypeNames = new HashSet<string>() {
        "String", "Boolean", "Double", "Int16", "Int32", "Int64", "UInt16", "UInt32", "UInt64" };

    /// <summary>
    /// 
    /// </summary>
    public class ActionResult
    {
        public IDataSource datasource { get; set; }
        public string expression { get; set; }
        public object result
        {
            get
            {
                return datasource.Execute(expression);
            }
        }
    }


 


    /// <summary>
    /// 
    /// </summary>
    /// <param name="method"></param>
    /// <param name="target"></param>
    /// <param name="json">Параметры выполнения сериализованные в json</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public object Invoke( object target, MethodInfo method, Dictionary<string, object> parametersMap)
    {
        string state = "Поиск обьекта: ";
        Dictionary<string, object> pars = new Dictionary<string, object>();
        List<object> invArgs = null;
        try
        {
            DataSeriallizer bind = new DataSeriallizer();         
            foreach(string key in parametersMap.Keys)
            {
                var subject = parametersMap[key];
                if ((subject.GetType().IsPrimitive || PrimitiveTypeNames.Contains(subject.GetType().Name))==false)
                {
                    string propertyJson = JObject.FromObject(parametersMap[key]).ToString();
                    object value = bind.From(propertyJson);
                    pars[key] = value;

                }
                else
                {
                    if (parametersMap[key].GetType().Name == "Int64")
                    {                             
                        pars[key] = Int32.Parse(parametersMap[key].ToString());
                    }
                    else
                    {
                        pars[key] = parametersMap[key];
                    }                        
                }
            }            

            invArgs = new List<object>();
            foreach (ParameterInfo pinfo in method.GetParameters())
            {
                if (pinfo.IsOptional == false && pars.ContainsKey(pinfo.Name) == false)
                {
                    throw new Exception("require argument " + pinfo.Name);
                }

                string parameterName = pinfo.ParameterType.Name;
                if (parameterName.StartsWith("Dictionary"))
                {
                    Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(pars[pinfo.Name].ToString());
                    invArgs.Add(dictionary);
                }
                else
                {
                    invArgs.Add(pars[pinfo.Name]);
                }

            }
        }
        catch (Exception ex)
        {
            throw new Exception("ArgumentsException: " + ex.Message, ex);
        }


        try
        {
            object result = method.Invoke(target, invArgs.ToArray());
            state = state.Substring(0, state.Length - 7) + "успех;";
            return result;
        }
        catch (Exception ex)
        {
            string message = "";
            while (ex.InnerException!=null)
            {
                message += ex.InnerException.Message;
                ex = ex.InnerException;
            }
            throw new Exception(message,ex);
        }
    }
}



/// <summary>
/// 
/// </summary>
public class ActionServiceTest : TestingElement
{
    public override List<string> OnTest()
    {
        return this.Messages;
    }
}