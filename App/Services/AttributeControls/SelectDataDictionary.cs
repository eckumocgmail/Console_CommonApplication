using ApplicationCore.Converter.ClientApp;

using CoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class SelectDataDictionaryAttribute : ControlAttribute
{

    private string entity;
    private string property;


    public SelectDataDictionaryAttribute(string expression)
    {
        string[] spices = expression.Split(",");
        if (spices.Length != 2)
        {
            throw new Exception("Выражение [SelectDataDictionaryAttribute] задано неверно");
        } 
        this.entity = spices[0];
        this.property = spices[1];
    }




    public override ViewItem CreateControl(object field)
    {
        Dictionary<object, object> options = new Dictionary<object, object>();
        using (var db = new AppDbContext())
        {
            
            db.List(entity).ForEach<object>(record => {
                options[record.GetProperty("ID")] = record.GetProperty(property);
            });

        }
        return new Select()
        {
            Options = options
        };            
    }
}
    
