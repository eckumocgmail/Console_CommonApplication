using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
 
/// <summary>
/// 
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public abstract class BaseDbContext : DbContext, IDbContext, IDisposable, IDataCrud
{
    public List<string> GetIndexes (string name)
    {
        Type entityType = FactoryUtils.Get().TypeForName(name);
        List<string> terms = AttrsUtils.SearchTermsForType(entityType);
        return terms;
    }

    public IEnumerable<dynamic> Search(string name, string query, int pageNumber, int pageSize)
    {
        Func<BaseEntity, bool> verify = Expressions.ArePropertiesContainsText<BaseEntity> (GetIndexes (name), query);
        IQueryable<BaseEntity> q = ((IQueryable<BaseEntity>)(GetDbSet(name)));
        return q.Where(p => verify(p));
    }

    /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// <summary>
    /// Вывод комманд
    ////// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///  </summary>
    public class LoggingInterceptor : DbCommandInterceptor
    {
        protected ILogger<BaseDbContext.LoggingInterceptor> logger =
            LoggerFactory.Create(options => options.AddConsole()).CreateLogger<BaseDbContext.LoggingInterceptor>();
        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command,
            CommandEventData events,
            InterceptionResult<DbDataReader> result)
        {
            this.Info(events.Connection.ToJsonOnScreen());
            this.Info(command.CommandText);
            return result;
        }
    }
    /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///     

    private static ConcurrentDictionary<int, BaseDbContext> Objects = new ConcurrentDictionary<int, BaseDbContext>(); public static int Counter = 0; private int Number;

    private IDataCrud IDataCrudController { get; set; }
    public string ConnectionString { get; set; }
    

    public BaseDbContext()
    {
        this.Number = Counter == int.MaxValue ? (Counter = 1) : (++Counter);
        this.IDataCrudController = new DataCrud(this);
        Objects[this.Number] = this;
        this.Info($"Создан новый экземпляр {GetType().GetTypeName()} с номером {this.Number} (Всего: {Objects.Count})");
    }

    public BaseDbContext(DbContextOptions options) : base(options)
    {
        if (options == null)
            throw new ArgumentNullException(nameof(options));
        this.IDataCrudController = new DataCrud(this);
        this.Number = Counter == int.MaxValue ? (Counter = 0) : (Counter++);
        Objects[this.Number] = this;
        this.Info("Создан новый экземпляр: " + options.GetType().GetNameOfType());
    }



    protected abstract void InitDbSets();
    public void InitData()
    {
        InitDbSets();
        this.Info($"Наборы данных: {this.GetRecordsCount().Where(kv => kv.Value == 0).Select(kv => kv.Key).ToJson()} не заполнены. ");
        throw new Exception($"Наборы данных: {this.GetRecordsCount().Where(kv => kv.Value == 0).Select(kv => kv.Key).ToJson()} не заполнены. ");
    }

    private IDictionary<string,int> GetRecordsCount()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public IDictionary<string,int> Init()
    {
        var operations = new Dictionary<string, int>();
        foreach(Type type in GetEntityTypes())
        {
            try
            {
                this.Info(new
                {
                    Type = type.GetNameOfType(),
                    Name = type.Label(),
                    Api = type.GetBaseTypesNames().ToJson(),
                    Set = (operations[type.GetNameOfType()] = Count(type.GetNameOfType()))
                });
            }      
            catch (Exception ex)
            {
                this.Error(ex);
                continue;
            }
        }
        return operations;
    }


    /// <summary>
    /// Выполняется по событию установки конфигурации в EntityFramework
    /// </summary>
    /// <param name="builder">объект содержит методы конфигурации</param>
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //Api.Utils.Info(AuthorizationDataModel.DEFAULT_CONNECTION_STRING);
        if (!options.IsConfigured)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.TrustServerCertificate = false;
            builder.IntegratedSecurity = true;
            builder.DataSource = "AGENT\\KILLER";
            builder.InitialCatalog = "AppHospital";
            this.ConnectionString = builder.ToString();
            //optionsBuilder.UseSqlServer(ConnectionString);
            string filename = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data", typeof(AnaliticsDataModel).GetNameOfType().ToKebabStyle() + ".db");
            this.Info(filename.FileSize() + " "+ filename);
            options.UseFile(filename);

            //optionsBuilder.UseInMemoryDatabase(GetType().GetTypeName());
        }
    }

    public override void Dispose()
    {
        base.Dispose();
        Objects.TryRemove(this.Number, out var model);
        Counter--;
    }



  


    public List<string> GetPendingMigrations()
    {
        return (List<string>)Database.GetPendingMigrations();
    }



    public List<string> GetMigrations()
    {

        return (List<string>)Database.GetAppliedMigrations();
    }


    /// <summary>
    /// Генерация структуры данных
    /// </summary>
    /// <param name="builder"></param>

    public IEnumerable<Type> GetInterfaces<TInterface>()
    {
        return this.GetEntitiesTypes().Where(t => t.IsImplementsFrom(typeof(TInterface)));
    }

    private IEnumerable<Type> GetEntitiesTypes()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        this.Info("Создаю ограничения целостности ...");
        /*try
        {
            foreach (var entityType in GetEntityTypes())
                modelBuilder.ApplyAnnotations(this);
        }catch (Exception ex)
        {
            ex.ToString().WriteToConsole();
        }*/
    }



    public override int SaveChanges() => base.SaveChanges();
    public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();

    public IEnumerable<Type> GetEntityTypes<TEntityInterface>()
        => GetEntityTypes().Where(type => type.IsImplementsFrom(typeof(TEntityInterface)));

    public IEnumerable<Type> GetEntityTypes()
    {
        HashSet<string> entities = new HashSet<string>();
        foreach (MethodInfo info in GetType().GetMethods())
        {
            if (info.Name.StartsWith("get_") == true && info.ReturnType.Name.StartsWith("DbSet"))
            {
                if (info.Name.IndexOf("MigrationHistory") == -1)
                {
                    entities.Add(Typing.ParseCollectionType(info.ReturnType));
                }
            }
        }
        return entities.Select(t =>t.ToType());
    }

    /* public IEnumerable<string> GetEntityTypeNames() => 
         base.Model.GetEntityTypes().Select(e => e.ClrType.Name);*/

    public IQueryable<T> GetDbSet<T>() where T : class => this.Set<T>();


    public void Trace()
    {
        foreach (string typeName in GetEntityTypes().Select(t => t.GetNameOfType()))
            this.Info(typeName + " => " + ((object)this.GetDbSet(typeName)).ToJsonOnScreen());
    }

    public dynamic GetDbSet(string T)
    {
        return null;// ((DbContext)this).GetDbSet(T);
    }

    public int Count(string entity)
    {
        return IDataCrudController.Count(entity);
    }

    public void Create(object target)
    {
        IDataCrudController.Create(target);
    }

    public void Delete(object target)
    {
        IDataCrudController.Delete(target);
    }

    public object Find(string entity, int id)
    {
        return IDataCrudController.Find(entity, id);
    }

    public HashSet<string> GetKeywords(string entity, string query)
    {
        return IDataCrudController.GetKeywords(entity, query);
    }

    public object[] List(string entity)
    {
        return IDataCrudController.List(entity);
    }

    public object[] List(string entity, int page, int size)
    {
        return IDataCrudController.List(entity, page, size);
    }

    public IQueryable<dynamic> Page(IQueryable<dynamic> items, int page, int size)
    {
        return IDataCrudController.Page(items, page, size);
    }

    public dynamic Page(string entity, int page, int size)
    {
        return IDataCrudController.Page(entity, page, size);
    }

    public int PagesCount(string entity, int size)
    {
        return IDataCrudController.PagesCount(entity, size);
    }

    public void Update(string name, object targetData)
    {
        IDataCrudController.Update(name, targetData);
    }

    public object Where(string entity, string expression)
    {
        return IDataCrudController.Where(entity, expression);
    }

    public object Where(string entity, string key, object value)
    {
        return IDataCrudController.Where(entity, key, value);
    }

    
}
