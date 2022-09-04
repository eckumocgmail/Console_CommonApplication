using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

 
 
[Label("Абстрактный класс \"Активный обьект\"( пользователи, службы ).")]
[Description("Активация объекта предполагает процедуру идентификации и авторизации.")]
public abstract class ActiveObject: DictionaryTable
{        
  
    [Label("Последнее посещение")]
    public long LastActiveTime { get; set; } = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        

    [Label("Онлайн")]
    public bool IsActive { get; set; }


    [Label("Секретный ключ")]
    public string SecretKey { get; set; }

    
}

