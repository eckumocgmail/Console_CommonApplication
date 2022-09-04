 

using ApplicationDb.Entities;
 

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

 
using NetCoreConstructorAngular.Data;

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class AuthorizationDataModelTest
{

}
/// <summary>
/// Контекст доступа к обьектам базы данных (EntityFramework)
/// </summary>
public partial class AuthorizationDataModel : BaseDbContext, IAuthorizationDataModel
{
    public static readonly string DEFAULT_CONNECTION_STRING = GetConnectionString();
    protected override void InitDbSets()
    {
    }
    private static string GetConnectionString()
    {
        var builder = new Microsoft.Data.SqlClient.SqlConnectionStringBuilder();
        builder.DataSource = "AGENT\\KILLER";
        builder.InitialCatalog = "www";
        builder.TrustServerCertificate = false;
        builder.IntegratedSecurity = true;
        return builder.ToString();
    }

    public virtual DbSet<UserAccount> Accounts { get; set; }
    public virtual DbSet<UserApi > Users { get; set; }
 
    public virtual DbSet<LoginEvent> LoginFacts { get; set; }
    public virtual DbSet<UserGroups> UserGroups { get; set; }

    internal DatabaseManager GetDatabaseManager()
    {
        throw new NotImplementedException();
    }

    public virtual DbSet<UserGroup> Groups { get; set; }
    public virtual DbSet<UserMessage> Messages { get; set; }
    public virtual DbSet<UserPerson> Persons { get; set; }
    public virtual DbSet<BusinessFunction> BusinessFunctions { get; set; }
    public virtual DbSet<BusinessResource> BusinessResources { get; set; }

    public virtual DbSet<MessageAttribute> MessageAttributes { get; set; }
    public virtual DbSet<MessageProperty> MessageProperties { get; set; }
    public virtual DbSet<MessageProtocol> MessageProtocols { get; set; }

    public virtual DbSet<UserSettings> Settings { get; set; }
    public virtual DbSet<GroupsBusinessFunctions> GroupsBusinessFunctions { get; set; }

    
    /// <summary>
    /// 
    /// </summary>
    public virtual DbSet<UserGroupMessage> GroupMessages { get; set; }
    public virtual DbSet<FileEntity> ImageResources { get; set; }
    public virtual DbSet<FileCatalog> PRoductionCatalog { get; set; }
 



    public virtual DbSet<TimePoint> Calendars { get; set; }
    public virtual DbSet<FileCatalog> FileCatalogs { get; set; }
    public virtual DbSet<FileEntity> FileResources { get; set; }

   
   

    public AuthorizationDataModel():base()
    {

    }
   

    public void ExecuteProcedure(string sql)
    {
        throw new Exception(sql);
        //Database.ExecuteSqlCommand(string.Format(
        //                @"CREATE UNIQUE INDEX LX_{0} ON {0} ({1})",
        //                         "Entitys", "FirstColumn, SecondColumn"));
    }


    public void GetProcedures()
    {
        foreach (var fx in Model.GetDbFunctions())
        {
   
            string query = fx.Name;
            foreach (var par in fx.Parameters)
            {
                query += $"{par.Name} {par.TypeMapping.DbType.Value} ";
            }
            Api.Utils.Info(query);
            
        }
    }

    


    /// <summary>
    /// Вывод сообщения в консоль
    /// </summary>
    /// <param name="v">текст сообщения</param>
    private void ToConsole(string v)
    {
        Debug.WriteLine(v);
    }


     


    private void ConfigureWarnings(WarningsConfigurationBuilder obj)
    {
                
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //uniq constraint
        builder.Entity<BusinessResource>()
               .HasIndex(u => u.Name)
               .IsUnique();

        //uniq constraint
        builder.Entity<BusinessResource>()
               .HasIndex(u => u.Code)
               .IsUnique();

        //uniq constraint
        builder.Entity<UserAccount>()
               .HasIndex(u => u.Email)
               .IsUnique();


        //uniq constraint
        builder.Entity<UserGroup>()
               .HasIndex(u => u.Name)
               .IsUnique();

        //uniq constraint
        builder.Entity<UserGroups>()
               .HasIndex(u => new { u.UserID, u.GroupID })
               .IsUnique();

        //uniq constraint
        builder.Entity<UserPerson>()
               .HasIndex(u => new { u.FirstName, u.SurName, u.LastName, u.Birthday })
               .IsUnique();
    }

}