﻿
using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[Icon("message")]
[Label("Поле сообщения")]
public class MessageProperty : DictionaryTable, IMessageProperty
{
    [Label("Надпись")]
    [Help("Надпись располагается рядом над элементом ввода")]
    [NotNullNotEmpty("Введите ")]
    [InputRusText("Используйте русскую кирилицу для надписи поля ввода")]
    public string Label { get; set; }


    [Label("Имя в наборе данных")]
    [Help("Имя свойства сообщения является идентификатором в наборе данных")]
    [NotNullNotEmpty("Введите имя свойства сообщения")]
    [InputEngText("Используйте латиницу для имени свойства сообщения")]
    public string Name { get; set; } = "New property";


    [Label("Порядковый номер")]
    public int Order { get; set; } = 0;


    public string GetDataType() => this.Attribute.CSharpType;
    public string GetInputType() => this.Attribute.InputType;

    public string GetSqlServerType() => this.Attribute.SqlServerDataType;


    [Label("Подпись")]
    [InputRusText("Используйте русскую кирилицу")]
    public string Help { get; set; }

    [Label("Обязательное")]
    public bool Required { get; set; }

    [Label("Уникальное")]
    public bool Unique { get; set; }

    [Label("Создание индекса")]
    [Help("Индексируемые поля являются ключами для поиска")]
    public bool Index { get; set; }



    [Label("Атрибут")]
    [SelectDictionary(nameof(MessageAttribute) + ",Name")]
    [NotNullNotEmpty("Необходимо выбрать атрибут")]
    public int AttributeID { get; set; }

    [Label("Атрибут")]
    [JsonIgnore()]
    [NotInput("Свойство " + nameof(Attribute) + " не вводится пользователем, оно устанавливается в соответвии с внешним ключом " + nameof(AttributeID))]
    public virtual IMessageAttribute Attribute { get; set; }





    [Label("Протокол сообщения")]
    [SelectDictionary(nameof(MessageProtocol) + ",Name")]
    [NotNullNotEmpty("Необходимо выбрать протокол")]
    public int MessageProtocolID { get; set; }

    [Label("Протокол сообщения")]
    [JsonIgnore()]
    [NotInput("Свойство " + nameof(MessageProtocol) + " не вводится пользователем, оно устанавливается в соответвии с внешним ключом " + nameof(MessageProtocolID))]
    public virtual IMessageProtocol MessageProtocol { get; set; }


}
