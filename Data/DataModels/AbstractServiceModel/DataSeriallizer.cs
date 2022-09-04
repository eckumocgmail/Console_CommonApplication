using System;
using System.Collections.Generic;

using static Api.Utils;

/// <summary>
/// Сериализатор слаботипизированных объектов
/// </summary>
public class DataSeriallizer2
{
    public static string Seriallize(object target)
    {
        if (target == null)
            throw new ArgumentNullException("target"); 
        var dictionary = new Dictionary<string, object>();
        dictionary["type"] = target.GetTypeName();
        dictionary["message"] = target;
        return dictionary.ToJsonOnScreen();
    }

    public static object Deseriallize(string type, string json)
    {
        if (type == null)
            throw new ArgumentNullException("type");
        if (type == null)
            throw new ArgumentNullException("json");
        
        try
        {
            Type ptype = type.ToType();
            object result = ptype.New();
            Dictionary<string, object> dic = json.FromJson<Dictionary<string, object>>();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);    
        }
    }

    public static object Deseriallize(string json)
    {
        if (String.IsNullOrWhiteSpace(json))
            throw new ArgumentNullException("json");
        Dictionary<string, object> dictionary = null;
        try
        {
            dictionary = json.FromJson<Dictionary<string, object>>();
        }
        catch(Exception ex)
        {
            throw new ArgumentException("Не удалось прочитать json", "json",ex);
        }
        if (dictionary.ContainsKey("type") == false)
        {
            throw new ArgumentException("Не найден ключ type в объекте json", "json");
        }
        else
        if (dictionary.ContainsKey("message") == false)
        {
            throw new ArgumentException("Не найден ключ message в объекте json", "json");
        }
        else
        {
            try
            {
                string typeName = dictionary["type"].ToString();
                var result = typeName.ToType().New();
                var data = dictionary["message"].ToJsonOnScreen().FromJson<Dictionary<string, object>>();
                foreach (var kv in data)
                {
                    try
                    {
                        GetApp().Info($"{kv.Key}={kv.Value}");
                        Setter.SetValue(result, kv.Key, kv.Value);
                    }
                    catch (Exception ex)
                    {
                        result.Error("Ошибка при установки значения свойства " + kv.Key + " => " + ex.Message);
                    }
                }
               
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Не удалось прочитать json", "json", ex);
            }
            
        }
        
    }


}

/// <summary>
/// 
/// </summary>
public class DataSeriallizer2Test : TestingElement
{
    public DataSeriallizer2Test(TestingUnit appUnitTests):base(appUnitTests)
    {
    }

    public override List<string> OnTest()
    { 
        string json = "";
        try
        {
            var before = new UserAccount("eckumoc@gmail.com", "sgdf1423");
            this.Info(json = DataSeriallizer2.Seriallize(before));
            if (DataSeriallizer2.Deseriallize(json).Equals(before))
            {
                Messages.Add($"{typeof(DataSeriallizer).GetNameOfType()} работает корректно \n{DataSeriallizer2.Deseriallize(json).ToJsonOnScreen()}");
            }
            else
            {
                Messages.Add($"{typeof(DataSeriallizer).GetNameOfType()} работает не корректно\n{DataSeriallizer2.Deseriallize(json).ToJsonOnScreen()}");
            }
        }
        catch (Exception ex)
        {
            this.Error(ex);
            Messages.Add($"{typeof(DataSeriallizer).GetNameOfType()} работает не корректно: {ex.Message}");
        }
        return Messages;
    }
}