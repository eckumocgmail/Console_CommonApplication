
using CoreModel;

using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


/// <summary>
/// Фиксирует события бизнес процессов
/// </summary>
public class EventLog: BaseEntity
{

    [NotNullNotEmpty("Необходимо указать дату")]
    [Label("Дата регистрации")]
    [InputDateTime()]
    [NotInput()]
    public DateTime Created { get; set; } = DateTime.Now;

    public string Controller { get; set; }
    public string Action { get; set; }
    public string JsonArgs { get; set; }
    public string JsonResult { get; set; }
    public string File { get; set; }
    public int Line { get; set; }


    public bool Completed { get; set; }
    public bool Success { get; set; }

    public virtual int TID { get; set; } 
    public virtual TimePoint T { get; set; }
        

    public virtual int ProcessID { get; set; }
    public virtual int HostID { get; set; }
    public virtual int AppID { get; set; }
    public virtual int UserID { get; set; }
    public virtual int ThreadID { get; set; }
    public virtual int RequestID { get; set; }
}
