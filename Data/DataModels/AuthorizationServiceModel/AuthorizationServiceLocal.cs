using ApplicationDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AuthorizationServiceLocal: Local, IAuthorizationServiceModel
{

    [NotNullNotEmpty]
    public IEntityFasade<UserAccount> Accounts { get; set; }

    [NotNullNotEmpty]
    public IEntityFasade<UserGroup> Groups { get; set; }

    [NotNullNotEmpty]
    public IEntityFasade<UserGroupMessage> GroupMessages { get; set; }

    [NotNullNotEmpty]
    public IEntityFasade<UserAuthEvent> LoginFacts { get; set; }

    [NotNullNotEmpty]
    public IEntityFasade<UserMessage> Messages { get; set; }

    [NotNullNotEmpty]
    public IEntityFasade<ServiceMessage> News { get; set; }

    [NotNullNotEmpty]
    public IEntityFasade<UserPerson> Persons { get; set; }

    [NotNullNotEmpty]
    public IEntityFasade<UserSettings> Settings { get; set; }

    [NotNullNotEmpty]    
    public IEntityFasade<UserApi> Users { get; set; }

    [NotNullNotEmpty]
    public IEntityFasade<UserGroups> UserGroups { get; set; }

    [NotNullNotEmpty]
    public IEntityFasade<TimePoint> Calendars { get; set; }


    public AuthorizationServiceLocal( IAuthorizationDataModel dataModel ) : base(AppProviderService.GetInstance())
    {


        Accounts = new EntityFasade<UserAccount>(dataModel);
        Groups = new EntityFasade<UserGroup>(dataModel);
        GroupMessages = new EntityFasade<UserGroupMessage>(dataModel);
        LoginFacts = new EntityFasade<UserAuthEvent>(dataModel);
        Messages = new EntityFasade<UserMessage>(dataModel);
        News = new EntityFasade<ServiceMessage>(dataModel);
        Persons = new EntityFasade<UserPerson>(dataModel);
        Settings = new EntityFasade<UserSettings>(dataModel);
        Users = new EntityFasade<UserApi>(dataModel);
        UserGroups = new EntityFasade<UserGroups>(dataModel);
        Calendars = new EntityFasade<TimePoint>(dataModel);
        EnsureIsValide();
    }



 
 
}
