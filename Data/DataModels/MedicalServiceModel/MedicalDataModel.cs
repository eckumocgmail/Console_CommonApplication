using ApplicationDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MvcMarketPlace.Data.Entities;
using NetCoreConstructorAngular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



[Label("Модель интернет-магазина")]
[Description("Абстракция высшего уровня, решает дугие задачи в нутри системы")]
public class MedicalModel : BaseDbContext, IMedicalModel
{
    protected override void InitDbSets()
    {
    }
    public MedicalModel() : base() { }
    public MedicalModel(DbContextOptions<MedicalModel> options) : base(options) { }


    public virtual DbSet<MedOrganization> MedOrganizations { get; set; }
    public virtual DbSet<MedicalFunction> MedicalFunctions { get; set; }
    public virtual DbSet<MedicalCard> MedicalCards { get; set; }
    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }
    public virtual DbSet<HospitalDepartment> HospitalDepartments { get; set; }
    public virtual DbSet<MedicalDepartment> MedicalDepartments { get; set; }


    public virtual DbSet<UserAccount> Accounts { get; set; }
    public virtual DbSet<UserApi> Users { get; set; }

    public virtual DbSet<LoginEvent> LoginFacts { get; set; }
    public virtual DbSet<UserGroups> UserGroups { get; set; }
    public virtual DbSet<UserGroup> Groups { get; set; }
    public virtual DbSet<UserMessage> Messages { get; set; }
    public virtual DbSet<UserPerson> Persons { get; set; }
    public virtual DbSet<UserSettings> Settings { get; set; }
    public virtual DbSet<BusinessResource> BusinessResources { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public virtual DbSet<UserGroupMessage> GroupMessages { get; set; }
    public virtual DbSet<MessageAttribute> MessageAttributes { get; set; }
    public virtual DbSet<MessageProperty> MessageProperties { get; set; }
    public virtual DbSet<MessageProtocol> MessageProtocols { get; set; }
    public virtual DbSet<FileEntity> ImageResources { get; set; }




    public virtual DbSet<GroupsBusinessFunctions> GroupsBusinessFunctions { get; set; }
    public virtual DbSet<BusinessFunction> BusinessFunctions { get; set; }
    public virtual DbSet<BusinessDatasource> BusinessDatasources { get; set; }
    public virtual DbSet<FileCatalog> FileCatalogs { get; set; }
    public virtual DbSet<FileEntity> FileResources { get; set; }

    /// <summary>
    /// Выполняется по событию установки конфигурации в EntityFramework
    /// </summary>
    /// <param name="builder">объект содержит методы конфигурации</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Api.Utils.Info(AuthorizationDataModel.DEFAULT_CONNECTION_STRING);
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase(nameof(AppDbContext));
            //optionsBuilder.UseSqlServer(AuthorizationDataModel.DEFAULT_CONNECTION_STRING.Replace("AppDesign", "MedicalApp"));
            //optionsBuilder.ConfigureWarnings(ConfigureWarnings);
            optionsBuilder.EnableDetailedErrors(true);
            optionsBuilder.AddInterceptors(new IInterceptor[] { new LoggingInterceptor() });
        }

    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }





}