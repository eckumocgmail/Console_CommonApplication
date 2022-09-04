using ApplicationDb.Entities;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;

 
[Label("Много ко многим")]
public class UserGroups: BaseEntity
{        
    public int UserID { get; set; }

    [JsonIgnore()]
    public virtual UserApi  User { get; set; }
    public int GroupID { get; set; }

    [JsonIgnore()]
   public virtual UserGroup Group { get; set; }
}
 