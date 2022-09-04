using ApplicationDb.Entities;

using Microsoft.EntityFrameworkCore;

public interface IMedicalModel
{
    DbSet<UserAccount> Accounts { get; set; }
    DbSet<BusinessDatasource> BusinessDatasources { get; set; }
    DbSet<BusinessFunction> BusinessFunctions { get; set; }
    DbSet<BusinessResource> BusinessResources { get; set; }

    DbSet<UserGroupMessage> GroupMessages { get; set; }
    DbSet<UserGroup> Groups { get; set; }
    DbSet<GroupsBusinessFunctions> GroupsBusinessFunctions { get; set; }
    DbSet<HospitalDepartment> HospitalDepartments { get; set; }
    DbSet<LoginEvent> LoginFacts { get; set; }
    DbSet<MedicalCard> MedicalCards { get; set; }
    DbSet<MedicalDepartment> MedicalDepartments { get; set; }
    DbSet<MedicalFunction> MedicalFunctions { get; set; }
    DbSet<MedicalRecord> MedicalRecords { get; set; }
    DbSet<MedOrganization> MedOrganizations { get; set; }
    DbSet<MessageAttribute> MessageAttributes { get; set; }
    DbSet<MessageProperty> MessageProperties { get; set; }
    DbSet<MessageProtocol> MessageProtocols { get; set; }
    DbSet<UserMessage> Messages { get; set; }
    DbSet<UserPerson> Persons { get; set; }
    DbSet<UserSettings> Settings { get; set; }
    DbSet<UserGroups> UserGroups { get; set; }
    DbSet<UserApi> Users { get; set; }
}