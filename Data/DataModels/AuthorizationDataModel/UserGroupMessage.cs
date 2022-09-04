using ApplicationDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Label("Сообщения в группе")]
public class UserGroupMessage: UserMessage
{
    public int GroupID { get; set; }
    public virtual UserGroup Group { get; set; }
}
