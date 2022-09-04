using ApplicationDb.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAuthorizationDataModel: IDbContext
{
    public DbSet<UserAccount> Accounts { get; set; }
    public DbSet<UserApi> Users { get; set; }

    public DbSet<UserGroups> UserGroups { get; set; }
    public DbSet<UserGroup> Groups { get; set; }
    public DbSet<UserMessage> Messages { get; set; }
    public DbSet<UserPerson> Persons { get; set; }
    public DbSet<UserSettings> Settings { get; set; }
    public DbSet<BusinessResource> BusinessResources { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public DbSet<TimePoint> Calendars { get; set; }
    public DbSet<UserGroupMessage> GroupMessages { get; set; }
    public DbSet<MessageAttribute> MessageAttributes { get; set; }
    public DbSet<MessageProperty> MessageProperties { get; set; }
    public DbSet<MessageProtocol> MessageProtocols { get; set; }



}
