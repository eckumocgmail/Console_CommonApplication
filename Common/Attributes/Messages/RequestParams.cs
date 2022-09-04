using Newtonsoft.Json.Linq;
using System.Collections.Generic;


[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class RequestParams
{
    public string path { get; set; }
    public JObject pars { get; set; }
    public byte[] blob { get; set; }

}