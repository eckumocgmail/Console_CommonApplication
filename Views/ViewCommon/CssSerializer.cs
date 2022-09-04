using System;
using System.Collections.Generic;

public class CssSerializer
{
    /// <summary>
    /// Форматированный вывод свойств CSS
    /// </summary>    
    public string Seriallize(Dictionary<string, object> valuesMap, Dictionary<string, Dictionary<string,string>> attrsMap)
    {
        string text = "";        
        foreach(var p in valuesMap)
        {
            if (p.Key == "ClassList") continue;
            text += $"{TextNaming.ToKebabStyle(p.Key)}: {ToQualifiedString(p.Value, attrsMap[p.Key])}; ";
        }
        return text;
    }

    /// <summary>
    /// Текстовое значение вывода данных. 
    /// Анализирует атрибуты свойства.
    /// </summary>  
    public static string ToQualifiedString(object value, Dictionary<string, string> attrs)
    {

        if (attrs.ContainsKey(nameof(InputPercentAttribute)))
        {
            return value.ToString() + "%";
        }
        else if (attrs.ContainsKey("SelectControlAttribute"))
        {
            return value.ToString();
        }
        else if (attrs.ContainsKey(nameof(UnitsAttribute)))
        {
            return value.ToString() + attrs[nameof(UnitsAttribute)];
        }
        else if (attrs.ContainsKey(nameof(InputColorAttribute)))
        {
            return value.ToString();
        }
        else
        {
            throw new Exception("Качественно определить специализированный текст пока не удалось.");
        }

    }
}