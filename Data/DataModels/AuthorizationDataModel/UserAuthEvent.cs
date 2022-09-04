



using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;

 
[Label("Факт авторизации пользователя")]
public class UserAuthEvent: EventLog
{ 
    public override int UserID { get; set; }
    [JsonIgnore()]
    public virtual UserApi  User { get; set; }
}
 