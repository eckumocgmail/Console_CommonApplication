using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


/// <summary>
/// 
/// </summary>
public class DataSeriallizer
{
    /// <summary>
    /// Распаковка JSON-объекта
    /// </summary>
    public object Unpackage(string type, string properties)
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        Type modelType = ReflectionService.TypeForName(type);
        object model = ReflectionService.CreateWithDefaultConstructor<object>(modelType);

        Dictionary<string, object> modelValues = JsonConvert.DeserializeObject<Dictionary<string, object>>(properties);
        new ReflectionService().copyFromDictionary(model, modelValues);
        return model;
    }


    /// <summary>
    /// Упаковка JSON-объекта
    /// </summary>
    public object CopyFromDictionary(object target, Dictionary<string,object> valuesMap)
    {
        MyMessageModel model = new MyMessageModel(target.GetType());
        foreach (string property in GetPropertyNames(target))
        {
            if (valuesMap.ContainsKey(property) )
            {
                object value = valuesMap[property];
                string propertyTypeName = model.GetProperty(property).Type;
                if (value != null && (value.GetType().Name == "Int64"|| propertyTypeName == "Int32"))
                {
                    value = Int32.Parse(value.ToString());
                }
                try
                {
                    Setter.SetValue(target, property, value);
                    //target.GetType().GetProperty(property).SetValue(target, value);
                }
                catch (Exception ex)
                {
                    Api.Utils.Info(ex);
                    //Setter.SetValue(target, property, value);
                }
                    
            }
        }
        return target;
    }

        
    public object Copy(object target, object from)
    {
        foreach(string property in GetPropertyNames(target))
        {
            object value = from.GetType().GetProperty(property).GetValue(from);
            target.GetType().GetProperty(property).SetValue(target,value);
        }
        return target;
    }

    public object Create(Type type)
    {
        ConstructorInfo constructor = 
            (from c in new List<ConstructorInfo>(type.GetConstructors()) where c.GetParameters().Length == 0 select c).FirstOrDefault();
        return constructor.Invoke(new object[0]);
    }

    public object From( string json )
    {
            
        Dictionary<string, object> valuesMap = JsonConvert.DeserializeObject<Dictionary<string,object>>(json);
        object model = null;
        if (valuesMap.ContainsKey("type"))
        {
            string type = valuesMap["type"].ToString();
            valuesMap.Remove("type");
            Type modelType = ReflectionService.TypeForName(type);
            model = Create(modelType);
            model = CopyFromDictionary(model, valuesMap);
        }
        else
        {
            model = JsonConvert.DeserializeObject<object>(json);
        }            
        return model;
    }

       

    public Dictionary<string, object> ToValuesMap(object user)
    {
        Dictionary<string, object> valuesMap = new Dictionary<string, object>();
        GetPropertyNames(user).ForEach(name =>
        {
            valuesMap[name] = user.GetType().GetProperty(name).GetValue(user);
        });
        valuesMap["type"] = user.GetType().FullName;
        return valuesMap;
    }

    private List<string> GetPropertyNames(object model)
    {
        List<string> properties = new List<string>();
        string name = model.GetType().Name;
        if( name == "Object" || name == "JObject")
        {
            return properties;
        }
        foreach (var prop in model.GetType().GetProperties())
        {
            properties.Add(prop.Name);
        }
        return properties;
    }

    public void Resolve(object myNavigationOptions, Dictionary<string, string> dic)
    {
        foreach(var p in ToValuesMap(myNavigationOptions))
        {
            dic[p.Key] = p.Value.ToString();
        }

    }

    public object CopyFromDictionarySave(object target, Dictionary<string, object> valuesMap)
    {
        MyMessageModel model = new MyMessageModel(target.GetType());
        foreach (string property in GetPropertyNames(target))
        {
            if (valuesMap.ContainsKey(property))
            {
                    
                object value = valuesMap[property];
                string propertyTypeName = model.GetProperty(property).Type;
                if (value != null && (value.GetType().Name == "Int64" || propertyTypeName == "Int32"))
                {
                    value = Int32.Parse(value.ToString());
                }

                target.GetType().GetProperty(property).SetValue(target, value);
                     
            }
        }
        return target;
    }
}
