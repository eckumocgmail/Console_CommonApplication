using ApplicationCore.Converter;

using ApplicationDb.Entities;
 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

[Label("Модель интернет-магазина")]
[Description("Абстракция высшего уровня, решает дугие задачи в нутри системы")]
public sealed class MedicalDataModel: BaseDbContext, IDbContext
{
    protected override void InitDbSets()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Api.Utils.Info(AuthorizationDataModel.DEFAULT_CONNECTION_STRING);
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase(nameof(MedicalDataModel));
            //optionsBuilder.UseSqlServer(AuthorizationDataModel.DEFAULT_CONNECTION_STRING);
            //optionsBuilder.ConfigureWarnings(ConfigureWarnings);            
            //optionsBuilder.EnableDetailedErrors(true);           
            //optionsBuilder.AddInterceptors(new IInterceptor[] { new LoggingInterceptor() });
        }
    }
    public MedicalDataModel() {
        Console.WriteLine(this);

    }
    public MedicalDataModel(DbContextOptions<MedicalDataModel> opt):base( opt   )
    {
        Console.WriteLine(this);
   
    }
 
 



    public DbSet<ManagmentLocation> Locations { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<MedicalCard> MedicalCards { get; set; }
    public DbSet<MedicalStep> MedicalSteps { get; set; }
    public DbSet<MedicalCase> MedicalCases { get; set; }
    public DbSet<MedicalBed> MedicalBeds { get; set; }
    public DbSet<MedicalDevice> MedicalDevices { get; set; }
    public DbSet<MedicalFunction> MedicalFunctions { get; set; }
    public DbSet<MedicalLab> MedicalLabs { get; set; }
    public DbSet<MedicalRoom> MedicalRoom { get; set; }
    public DbSet<Position> ManagmentPositions { get; set; }

   

    public IEnumerable<INavigation> GetNavigationPropertiesForType(Type type)
    {
        return EntityUtils.GetNavigation(type);
    }

    public int Save()
    {
        return base.SaveChanges();
    }

    public void Update(BaseEntity baseEntity)
    {
        this.Update(baseEntity);
        base.SaveChanges();
    }

    public DbSet<UserAccount> Accounts{ get; }
    public DbSet<BusinessDatasource> BusinessDatasources{ get; }
    public DbSet<BusinessFunction> BusinessFunctions{ get; }
    public DbSet<BusinessResource> BusinessResources{ get; }
    public DbSet<UserGroupMessage> GroupMessages{ get; }
    public DbSet<UserGroup> Groups{ get; }
    public DbSet<GroupsBusinessFunctions> GroupsBusinessFunctions{ get; }
    public DbSet<HospitalDepartment> HospitalDepartments{ get; }
    public DbSet<LoginEvent> LoginFacts{ get; }
    public DbSet<MedicalDepartment> MedicalDepartments{ get; }
    public DbSet<MedicalRecord> MedicalRecords{ get; }
    public DbSet<MedOrganization> MedOrganizations{ get; }
    public DbSet<MessageAttribute> MessageAttributes{ get; }
    public DbSet<MessageProperty> MessageProperties{ get; }
    public DbSet<MessageProtocol> MessageProtocols{ get; }
    public DbSet<UserMessage> Messages{ get; }
    public DbSet<UserPerson> Persons{ get; }
    public DbSet<UserSettings> Settings{ get; }
    public DbSet<UserGroups> UserGroups{ get; }
    public DbSet<UserApi> Users{ get; }
}