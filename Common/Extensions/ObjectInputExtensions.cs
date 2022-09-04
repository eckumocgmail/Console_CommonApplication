using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using static Api.Utils;

/// <summary>
/// расширения для ввода данных
/// </summary>
public static class ObjectInputExtensions
{
   

    /// <summary>
    /// Переход консолши в служебное приложения предназначенное для работы со свойствами объекта
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public static IConfiguration RunConfigurationBilder(this object target)
    {
        ConsoleProgram.RunInteractive(target);
        return target.ToConfiguration();
    }


    public static IConfiguration ToConfiguration(this object target)
    {
        string filepath = Path.Combine(
            System.IO.Directory.GetCurrentDirectory(),
            "Config",
            target.GetFileName()).ToString();
        try
        {
            target.Info($"{target.GetFileName()} => ToConfiguration()");


            if (System.IO.File.Exists(filepath) == false)
                filepath.CreateFile();
            target.Info(filepath);

            var builder = new ConfigurationBuilder();
            string json = target.ToJsonOnScreen();
            target.Info(json);
            json.WriteToFile(filepath);
            builder.AddJsonFile(filepath);
            return builder.Build();
        }catch (Exception ex)
        {
            target.Error(ex, "Ошибка при конфигурации "+filepath);
            throw;
        }
    }
     

    

    /// <summary>
    /// Получение имён свойств полежащих вводу
    /// </summary>
    public static string[] GetUserInputPropertyNames(this Type type)
    {
        var navs = Utils.GetRefTypPropertiesNames(type);        
        return ReflectionService
              .GetPropertyNames(type).
               Where(n => 
                   Utils.IsInput(type, n) &&
                   Utils.IsVisible(type, n) &&
                   navs.Contains(n) == false && 
                   navs.Contains(n+"ID") == false).ToArray();
    }

    /// <summary>
    /// Проверка является ли свойство коллекцией
    /// </summary>
    public static bool IsCollectionType(this Type type)
    {
        return Typing.IsCollectionType(type);
    }

    /// <summary>
    /// Получение аттрибутов
    /// </summary> 
    public static Dictionary<string, string> GetAttrs( this object p )
    {
        if(p is Type)return Utils.ForType((Type)p);
        return Utils.ForType(p.GetType());
    }

    public static string GetAttribute<TAttr>(this object type, string defaultVAlue) where TAttr: Attribute
    {
        return type.GetAttribute(typeof(TAttr).GetNameOfType());
    }

    /// <summary>
    /// Получение аттрибутов
    /// </summary> 
    public static string GetAttribute(this object p, string nameoftype)
    {
         
        var attrs = p.GetAttrs();
        if (nameoftype.EndsWith("Attribute"))
        {
            if (attrs.ContainsKey(nameoftype))
            {
                return attrs[nameoftype];
            }
            else if (attrs.ContainsKey(nameoftype.Replace("Attribute", "")))
            {
                return attrs[nameoftype.Replace("Attribute", "")];
            }
            else
            {
                return null;
            }
        }
        else
        {
            if (attrs.ContainsKey(nameoftype))
            {
                return attrs[nameoftype];
            }
            else if (attrs.ContainsKey(nameoftype+"Attribute"))
            {
                return attrs[nameoftype + "Attribute"];
            }
            else
            {
                return null;
            }
        }
        
    }


    /// <summary>
    /// Получение имён свойств
    /// </summary> 
    public static string[] GetOwnPropertyNames(this Type type)
    {
        return (from p in new List<PropertyInfo>((type).GetProperties()) where p.DeclaringType == type select p.Name).ToArray();
    }

    /// <summary>
    /// Получение имён методов
    /// </summary> 
    public static string[] GetOwnMethodNames(this Type type)
    {
        return (from p in new List<MethodInfo>((type).GetMethods()) where p.DeclaringType == type select p.Name).Where(name => name.StartsWith("get_")==false && name.StartsWith("set_")==false).ToArray();
    }

    /// <summary>
    /// Возвращает значение свойства
    /// </summary> 
    public static object GetProperty(this object target, string property )
    {
        var prop = target.GetType().GetProperties().FirstOrDefault(n => n.Name == property);
        var result = prop == null? null: prop.GetValue(target);
        return result;
    }

    /// <summary>
    /// Возвращает значение свойства
    /// </summary> 
    public static void Set(this object target, string property, object value)
    {
        target.GetType().GetProperty(property).SetValue(target,value);
    }

  


    /// <summary>
    /// Преобразование к формату JSON
    /// </summary>
    public static Dictionary<string, object> ToDictionary(this object target)
    {
        var result = new Dictionary<string, object>();
        target.GetOwnPropertyNames().ToList().ForEach(name => { 
            result[name]=target.GetProperty(name);  
        });
        return result;
    }


    /// <summary>
    /// Преобразование к формату JSON
    /// </summary>
    public static Dictionary<string, string> ToActionLinks(this object target, string pattern)
    {
        var result = new Dictionary<string, string>();
        target.GetOwnPropertyNames().ToList().ForEach(name => {
            result[name] = ObjectCompileExpExtensions.Expression.Interpolate(pattern, new { 
                action = name                
            });
        });
        return result;
    }

    /// <summary>
    /// Преобразование к формату JSON
    /// </summary>
    public static string ToXML(this object target)
    {
        return Formating.ToXML(target);
    }
    
    
}
