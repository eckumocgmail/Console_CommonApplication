 

using ApplicationCore.Converter;
using ApplicationDb.Entities; 
using Managment.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

/// <summary>
/// Объединяет сегменты данных определённых в модулях, реализующих DataModule
/// </summary>
/// <returns>Общий список сущностей всех сегментов данных</returns>
public class CommonDataModel : BaseDbContext, IDisposable, IDbContext
{

    /// <summary>
    /// Получает корневой модуль через систему внедрения зависимостей
    /// </summary>
    /// <param name="erp"></param>
    public CommonDataModel() : base()
    {
        Add(new MedicalDataModel());
        Add(new AnaliticsDataModel());
        Add(new MarketDataModel());
        Add(new ManagmentDataModel());
        Add(new CustomerDataModel());
        Add(new CommunicationDataModel());
        Add(new AuthorizationDataModel());



    }


    public Dictionary<string, object> GetDatasets()
    {
        var result = new Dictionary<string, object>();

        list.ForEach(p => {
            Dictionary<string, object> map = ((DbContext)p).GetDbSets();
            foreach (var kv in map)
            {
                result[kv.Key] = kv.Value;
            }
        });
        return result;
    }


    /// <summary>
    /// Возвращает контекст для данной записи
    /// </summary>
    /// <param name="record"></param>
    /// <returns></returns>
    public IDbContext GetContextFor(BaseEntity record)
    {
         
        return (IDbContext)list.Find(p => ((DbContext)p).GetEntityTypeNames().Contains(record.GetType().Name));

    }
    public IDbContext GetContextForType(Type record)
    {

        var r = list.Find(p => ((DbContext)p).GetEntityTypeNames().Contains(record.Name));
        return (IDbContext)r;

    }


    /// <summary>
    /// Возвращает общий список сущностей всех сегментов данных
    /// </summary>
    /// <returns>Общий список сущностей всех сегментов данных</returns>
    public List<string> GetEntityTypeNames()
    {
        var r = new List<string>();
        list.ForEach(p => {
            r.AddRange(((IDbContext)p).GetEntityTypes().Select(t=>t.GetNameOfType()));
           
        });
        return r;
    }


    /// <summary>
    /// Поиск по первичному ключу
    /// </summary>
    /// <param name="entity">имя сущности</param>
    /// <param name="id">ключ</param>
    /// <returns>ссылка</returns>
    /*public BaseEntity Find(string entity, int id)
    {
        base.Find
        return (BaseEntity)GetDbSet(entity).Find(id);
    }


    /// <summary>
    /// Поиск массива данных по исени сущности
    /// </summary>
    /// <returns>Общий список сущностей всех сегментов данных</returns>
    public dynamic GetDbSet(string entity)
    {
        object p = null;
        list.ForEach(dbc => {
            if (((DbContext)dbc).GetEntityTypeNames().Contains(entity))
            {
                object r = ((DbContext)dbc).GetDbSet(entity);
                if (r != null)
                {
                    p = r;
                }
            }

        });
        return p;
    }


    /// <summary>
    /// Освобождение памяти
    /// </summary>
    public void Dispose()
    {
        list.ForEach(p => ((DbContext)p).Dispose());
    }


    /// <summary>
    /// Выполнение транзакции
    /// </summary>
    public void SaveChanges()
    {
        list.ForEach(p => ((DbContext)p).SaveChanges());
    }



    /// <summary>
    /// Выполнение транзакции
    /// </summary>
    public async Task<int> SaveChangesAsync()
    {
        int summ = 0;
        var all = new List<int>();
        list.ForEach(async p => {
            int res = await ((DbContext)p).SaveChangesAsync();
            summ += res;
            all.Add(res);
        });
        await Task.CompletedTask;
        return summ;


    }

    public void Update(BaseEntity baseEntity)
    {
        var ctx = GetContextFor(baseEntity);
        //GetDbSet().Update(baseEntity);
        ctx.SaveChanges();
    }
    */
    public List<IDbContext> list { get; set; } = new List<IDbContext>();

    public IEnumerable<INavigation> GetNavigationPropertiesForType(Type type)
    {
        var ctx = GetContextForType(type);

        return null;///ctx.GetNavigationPropertiesForType(type);
    }

    protected override void InitDbSets()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public void ForEach(Action<object> p)
    {
        throw new NotImplementedException();
    }
}

public partial class AppDbContext : BaseDbContext , IDisposable, IAuthorizationDataModel, IBusinessDataModel, IManagmentDataModel
{
    private readonly DbContextOptions<AppDbContext> _options;

    public AppDbContext() {
        
    }

    public AppDbContext(DbContextOptions<AppDbContext>  options) : base(options)
    {
        _options = options;
    }
     
  

    public virtual DbSet<UserAccount> Accounts { get; set; }
    public virtual DbSet<UserGroup> Groups { get; set; }
    public virtual DbSet<UserGroupMessage> GroupMessages { get; set; }
    public virtual DbSet<UserAuthEvent> LoginFacts { get; set; }
    public virtual DbSet<UserMessage> Messages { get; set; }
    public virtual DbSet<ServiceMessage> News { get; set; }
    public virtual DbSet<UserPerson> Persons { get; set; }
    public virtual DbSet<UserSettings> Settings { get; set; }
    public virtual DbSet<UserApi > Users { get; set; }
    public virtual DbSet<UserGroups> UserGroups { get; set; }

    public virtual DbSet<GroupsBusinessFunctions> GroupsBusinessFunctions { get; set; }
    public virtual DbSet<BusinessDatasource> BusinessDatasources { get; set; }
    public virtual DbSet<BusinessFunction> BusinessFunctions { get; set; }
    public virtual DbSet<BusinessLogic> BusinessLogics { get; set; }
    public virtual DbSet<BusinessProcess> BusinessProcesss { get; set; }
    public virtual DbSet<BusinessReport> BusinessReports { get; set; }
    public virtual DbSet<BusinessResource> BusinessResources { get; set; }
    public virtual DbSet<BusinessProcess> BusinessProcesses { get; set; }
    public virtual DbSet<MessageAttribute> MessageAttributes { get; set; }
    public virtual DbSet<MessageProperty> MessageProperties { get; set; }
    public virtual DbSet<MessageProtocol> MessageProtocols { get; set; }
    public virtual DbSet<ValidationModel> ValidationModels { get; set; }
    public virtual DbSet<BusinessData> BusinessData { get; set; }
    public virtual DbSet<BusinessIndicator> BusinessIndicators { get; set; }
    public virtual DbSet<BusinessDataset> BusinessDatasets { get; set; }
    public virtual DbSet<BusinessGranularities> Granularities { get; set; }
    public virtual DbSet<BaseOrganization> Organizations { get; set; }
    
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<EmployeeExpirience> EmployeeExpirience { get; set; }
    public virtual DbSet<Position> Positions { get; set; }
    public virtual DbSet<PositionFunction> PositionFunctions { get; set; }
    public virtual DbSet<FunctionSkills> FunctionSkills { get; set; }

    public IDbContext GetContextFor(BaseEntity baseEntity) => this;

    public object Execute(string sql)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public virtual DbSet<SalaryReport> SalaryReports { get; set; }
    public virtual DbSet<Skill> Skills { get; set; }
    public virtual DbSet<StaffsTable> Staffs { get; set; }
    public virtual DbSet<PaymentPersonal> TariffRates { get; set; }
    public virtual DbSet<TimeSheet> TimeSheets { get; set; }
    
    public virtual DbSet<MedicalCard> MedicalCards { get; set; }
    public virtual DbSet<MedicalStep> MedicalSteps { get; set; }
    public virtual DbSet<MedicalCase> MedicalCases { get; set; }
    public virtual DbSet<Position> ManagmentPositions { get; set; }
    public virtual DbSet<MedicalBed> MedicalBeds { get; set; }
    public virtual DbSet<MedicalDevice> MedicalDevices { get; set; }
    public virtual DbSet<MedicalFunction> MedicalFunctions { get; set; }
    public virtual DbSet<MedicalLab> MedicalLabs { get; set; }
    public virtual DbSet<MedicalRoom> MedicalRoom { get; set; }
    public virtual DbSet<FileCatalog> FileCatalogs { get; set; }
    public virtual DbSet<FileEntity> FilResources { get; set; }
  
 
    public virtual DbSet<TimePoint> Calendars { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<FileEntity> FileResources { get; }
    public virtual DbSet<HospitalDepartment> HospitalDepartments { get; }
    public virtual DbSet<FileEntity> ImageResources { get; }
    public virtual DbSet<MedicalDepartment> MedicalDepartments { get; }
    public virtual DbSet<MedicalRecord> MedicalRecords { get; }
    public virtual DbSet<MedOrganization> MedOrganizations { get; }
    public virtual DbSet<FileCatalog> PRoductionCatalog { get; }

    protected override void InitDbSets()
    {
    }
}


/// <summary>
/// Функции расширения 
/// </summary>
public static class ApplicationDbContextExtensions
{

    /// <summary>
    /// 
    /// </summary>     
    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration Configuration=null)
    {
        return (IServiceCollection)services.Commit(
            () => {
                services.AddScoped(typeof(IBusinessDataModel), (provider) => {
                    var ctx = (AppDbContext)provider.GetService(typeof(AppDbContext));
                    return ctx;
                });
                services.AddScoped(typeof(IAuthorizationDataModel), (provider) => {
                    var ctx = (AppDbContext)provider.GetService(typeof(AppDbContext));
                    return ctx;
                });
                services.AddScoped(typeof(IMedicalCardModel), (provider) => {
                    var ctx = (AppDbContext)provider.GetService(typeof(AppDbContext));
                    return ctx;
                });
                services.AddScoped(typeof(IManagmentDataModel), (provider) => {
                    var ctx = (AppDbContext)provider.GetService(typeof(AppDbContext));
                    return ctx;
                });
                services.AddScoped(typeof(IAuthorizationDataModel), (provider) => {
                    var ctx = (AppDbContext)provider.GetService(typeof(AppDbContext));
                    return ctx;
                });
                return services;
            },
            new Dictionary<string, object>() {
                { "Configuration", Configuration }
            });
        
        
    }
}
