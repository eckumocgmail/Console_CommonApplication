using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class RequestMessage: EventArgs
{    
    [Required(ErrorMessage ="Необходимо задать иденификатор запроса")]
    public string SerialKey { get; set; }

    [Required(ErrorMessage = "Необходимо задать наименование операции")]
    [InputEngText]
    public string ActionName { get; set; }

    [Required(ErrorMessage = "Необходимо задать наименование тип сервиса")]
    [InputEngText]
    public string ServiceName { get; set; }

    [Display(Name = "Фактические аргументы выполнения операции")]
    [Required(ErrorMessage = "Необходимо задать фактические аргументы выполнения операции")]
    public object MessageObject { get; set; }
    
    public Dictionary<string, object> GetArguments()
        => JsonConvert.DeserializeObject<Dictionary<string, object>>(JObject.FromObject(MessageObject).ToString());
}