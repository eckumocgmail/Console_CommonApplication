using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class InputParams
{
    public string Tag { get; set; }
    public Dictionary<string, string> Attrs { get; set; }
    public string Text { get; set; }


    public string BeginText()
    {
        string attrsstr = "";
        foreach (var attr in Attrs)
        {
            attrsstr += $" {attr.Key}='{attr.Value}'";
        }
        return $"<{Tag}{attrsstr}>";
    }


    public string EndText()
    {
        string attrsstr = "";
        foreach (var attr in Attrs)
        {
            attrsstr += $" {attr.Key}='{attr.Value}'";
        }
        return $"</{Tag}{attrsstr}>";
    }


    public string GetNameAttribute()
    {
        if (Attrs.ContainsKey("Name"))
        {
            return Attrs["Name"];
        }
        return null;
    }
}
