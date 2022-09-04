﻿
using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;
using System.Collections.Generic;

[Icon("message")]
[Label("Информационные характеристики сообщений")]
public class MessageProtocol : BusinessEntity<MessageProtocol>, IMessageProtocol
{         
    

    [Label("Источник")]     
    [SelectDictionary(nameof(BusinessFunction) + ",Name")]
    public int? FromID { get; set; }
    public virtual BusinessFunction From { get; set; }


    public int? FromBusinessFunctionID { get; set; }
    public int? ToBusinessFunctionID { get; set; }

    [Label("Приёмник")]
    [SelectDictionary(nameof(BusinessFunction) + ",Name")]
    public int? ToID { get; set; }
    public virtual BusinessFunction To { get; set; }


    [Label("Свойства")]
    public virtual List<IMessageProperty> Properties 
    { 
        get; 
        set; }


    public MessageProtocol()
    {
    }

    public BusinessFunction GetFromBusinessFunction()
    {
        using (var db = new BusinessDataModel())
        {
            return db.BusinessFunctions.Find(FromBusinessFunctionID);
        }
    }


    public BusinessFunction GetToBusinessFunction()
    {
        using (var db = new BusinessDataModel())
        {
            return db.BusinessFunctions.Find(ToBusinessFunctionID);
        }
    }


    public string GetInputTableName()
    {
        return "[" + RusEngTranslite.TransliteToLatine(this.Name).ToUpper() + "]";
    }

    
}
