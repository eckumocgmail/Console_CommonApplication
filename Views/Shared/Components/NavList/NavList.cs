using Microsoft.AspNetCore.Mvc;

using System.Collections;
using System.Collections.Generic;

public class NavList: ViewItem
{
    public IDictionary<string,string> Model { get; set; } = new Dictionary<string,string>();

    public NavList(IDictionary<string, string> Model)
    {
        if (Model == null)
            throw new System.ArgumentNullException("Model");
        foreach (var kv in Model)
        {
            this.Model[kv.Key] = kv.Value;   
        }
    }
}
