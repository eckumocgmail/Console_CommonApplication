
using static Api.Utils;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static ExtensionsCommonApplication;

/// <summary>
/// Методы расширения
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public static class ExtensionsCommonApplication
{
    /// <summary>
    /// Контекст хранения данных
    /// </summary>
    /// <returns></returns>
    public static DbContext GetDbContext( this BaseEntity target )
    {
        return new AppDbContext();
    }

    public static object JoinAll(this BaseEntity target)
    {
        foreach (var nav in EntityUtils.GetNavigation(target.GetType()))
        {
            target.Join(nav.Name);
        }
        return target;
    }

    public static BaseEntity Join(this BaseEntity target ,string propertyName)
    {
        object value = null;
        if (Typing.IsCollectionType(target.GetType().GetProperty(propertyName).PropertyType))
        {
            string entity = Typing.ParseCollectionType(target.GetType().GetProperty(propertyName).PropertyType);
            using (var db = new CommonDataModel())
            {

                var nav = EntityUtils.GetNavigationKeyFor(entity, target.GetType());
                string p = nav.Name + "ID";
                var q = new AppDbContext().GetDbSet(entity);
                List<BaseEntity> resultSet = new List<BaseEntity>();
                foreach (var item in q)
                {
                    if (ReflectionService.GetValueFor(item, p).ToString() == target.ID.ToString())
                    {
                        resultSet.Add((BaseEntity)item);
                    }
                }


                if (TypeUtils.IsCollectionType(target.GetType().GetProperty(propertyName).PropertyType))
                {

                    object pproperty = target.Get(propertyName);
                    try
                    {
                        var method = pproperty.GetType().GetMethod("Add");
                        if (method == null)
                        {
                            throw new Exception($"{pproperty.GetType().Name} не реализует метод Add");
                        }
                        else
                        {
                            resultSet.ForEach(next => method.Invoke(pproperty, new object[] { next }));
                        }

                    }
                    catch (Exception ex)
                    {
                        Info(ex);
                    }



                }
                else
                {
                    value = q.FirstOrDefault();
                    Setter.SetValue(target, propertyName, value);
                }

                //value = (from item in ((IQueryable<BaseEntity>)(db.GetDbSet(entity))) where ReflectionService.GetValueFor(item, p).ToString() == this.ID.ToString() select p).ToList();
                //(from p in list where ReflectionService.GetValueFor(p, zz) select p).ToList();
            }

            ;
        }
        else
        {
            object pid = target.GetProperty(propertyName + "ID");
            if (pid != null)
            {
                int id = int.Parse(pid.ToString());
                using (var db = new CommonDataModel())
                {
                    string entity = target.GetType().GetProperty(propertyName).PropertyType.Name;

                    value = db.Find(entity, id);
                }
                Setter.SetValue(target, propertyName, value);
            }


        }
        return target;
    }

    public static void Create(this BaseEntity target)
    {
        using (var db = new AppDbContext())
        {
            db.Add(target);
            db.SaveChanges();
        }
    }

    public static void Delete(this BaseEntity target)
    {
        using (var db = new AppDbContext())
        {

            db.Delete(target);
        }
    }

    public static void Refresh(this BaseEntity target)
    {
        using (var db = new AppDbContext())
        {
            object data = db.GetDbSet(target.GetType().Name).Find(target.ID);
            new ReflectionService().copy(data, target);
        }
    }



    public static void Update(this BaseEntity target)
    {

        using (var db = new CommonDataModel())
        {
            db.Update(target);
            db.SaveChanges();
        }
    }
    public static Table ToDictionaryTable(this BaseEntity target)
    {
        return new TableService().ForDictionary(Formating.ToDictionary(target), Utils.LabelFor(target.GetType()));
    }

    public static ComponentViewModel ToCard(this BaseEntity target)
    {
        return new CardService().ForEntity(target);
    }

    public static Form ToForm(this BaseEntity target)
    {
        return new Form(target);
    }
    /*public static DatabaseManager GetDatabaseManager(this AuthorizationDataModel model)
    {
        string con = "Driver={SQL Server};" + AuthorizationDataModel.DEFAULT_CONNECTION_STRING.Replace(@"\\", @"\");
        return new DatabaseManager(con);
    }*/
    public static void UseExceptionCatcher(
                    this IApplicationBuilder app,
                    Func<Exception, string> Catch)
    {
        app.UseMiddleware<ExceptionCatcherMiddleware>(Catch);
    }
    public static void AddDataModels(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddFileDatabase<AppDbContext>();

        services.AddScoped<CommonDataModel>();
        AddMarket(services);
        AddAnalitics(services);
        AddAnaliticsModel(services);
        AddAuthorizationModel(services);
        AddBusinessModel(services);
        AddDnsModel(services);
        AddManagmentModel(services);
        AddDeployModel(services);
        AddCustomerModel(services);
        AddCommunicationModel(services);

        services.AddFileDatabase<MedicalDataModel>();

        services.AddFileDatabase<FilesDataModel>();
        services.AddScoped(typeof(IFilesDataModel), sp => sp.GetService<FilesDataModel>());
        services.AddScoped(typeof(IEntityFasade<UserMessage>), sp => new EntityFasade<UserMessage>(sp.GetService<FilesDataModel>()));

        services.AddFileDatabase<AuthorizationDataModel>();
        services.AddScoped(typeof(IAuthorizationDataModel), sp => sp.GetService<AuthorizationDataModel>());

        services.AddFileDatabase<ManagmentDataModel>();
        services.AddScoped(typeof(IManagmentDataModel), sp => sp.GetService<ManagmentDataModel>());

    }

    private static void AddAnaliticsModel(IServiceCollection services)
    {
        services.AddFileDatabase<AnaliticsDataModel>();
    }

    private static void AddAuthorizationModel(IServiceCollection services)
    {
        services.AddFileDatabase<AuthorizationDataModel>();
    }

    private static void AddBusinessModel(IServiceCollection services)
    {
        services.AddFileDatabase<BusinessDataModel>();
    }

    private static void AddDnsModel(IServiceCollection services)
    {
        services.AddFileDatabase<DnsDataModel>();
    }

    private static void AddManagmentModel(IServiceCollection services)
    {
        services.AddFileDatabase<ManagmentDataModel>();
    }

    private static void AddDeployModel(IServiceCollection services)
    {
        services.AddFileDatabase<DeployDataModel>();
    }

    private static void AddCustomerModel(IServiceCollection services)
    {
        services.AddFileDatabase<CustomerDataModel>();
    }

    private static void AddCommunicationModel(IServiceCollection services)
    {
        services.AddFileDatabase<CommunicationDataModel>();
        services.AddScoped(typeof(ICommunicationDataModel), sp => sp.GetService<CommunicationDataModel>());
        services.AddScoped<ICommunicationServiceModel, CommunicationServiceLocal>();

    }

    private static void AddMarket(IServiceCollection services)
    {
        
        services.AddFileDatabase<MarketDataModel>();
        services.AddScoped(typeof(IMarketDataModel), sp => sp.GetService<MarketDataModel>());
        services.AddScoped<IAnaliticsServiceModel, AnaliticsServiceLocal>(); 
        
    }

    private static void AddAnalitics(IServiceCollection services)
    {
        services.AddFileDatabase<AnaliticsDataModel>();
        services.AddScoped(typeof(IAnaliticsDataModel), sp => sp.GetService<AnaliticsDataModel>());
        services.AddScoped<IAnaliticsServiceModel, AnaliticsServiceLocal>();
    }


    /// <summary>
    /// 
    /// </summary> 
    public static IHost TestHost(this IHost host)
    {

        foreach (Type unit in Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsExtendsFrom(typeof(TestingUnit))))
        {
            try
            {
                ((TestingUnit)unit.New()).DoTest().ToDocument().WriteToConsole();
            }
            catch (Exception ex)
            {
                host.Error(ex);
            }
        }
        return host;
    }

    public static IHost ConfigureHost(this IHost host)
    {
        TestMigrations(host);
        TestRegistration(host);
        return host;
    }


    /// <summary>
    /// Заполнения ошибками валидации
    /// </summary>
    public static void Add(this ModelStateDictionary state, IDictionary<string, List<string>> errors)
    {

        foreach (var kv in errors)
        {
            foreach (var error in kv.Value)
            {
                state.AddModelError(kv.Key, error);
            }
        }
    }


    private static void TestMigrations(IHost host)
    {
        
        using (var scope = host.Services.CreateScope())
            try
            {
                foreach (object p in scope.ServiceProvider.GetServices(typeof(DbContext)))
                {
                    host.LogInformation($"{p.GetType().GetNameOfType()}");

                    DbContext db = (DbContext)p;
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    host.LogInformation(p.GetType().GetNameOfType() +
                        " Формирование структуры данных выполнено успешно.");
                }
            }
            catch (Exception ex)
            {
                host.LogInformation("Ошибка при формировании структуры данных: " + ex);
            }
    }

    private static void TestRegistration(IHost host)
    {
        ILogger logger =
            LoggerFactory.Create(options => options.AddConsole()).CreateLogger("Модель аутентификации. Регистрация учетных записей.");
        using (var scope = host.Services.CreateScope())
            try
            {
                APIAuthorization auth = scope.ServiceProvider.GetService<APIAuthorization>();
                if (auth.HasUserWithEmail("eckumoc@gmail.com"))
                    auth.RemoveUserWithEmail("eckumoc@gmail.com");
                auth.Signup("eckumoc@gmail.com", "Gye*34FRtw", "Gye*34FRtw");
                if (auth.HasUserWithEmail("eckumoc@gmail.com") == false)
                {
                    throw new Exception("Регистрация учетных записей не работает");
                }
                else
                {
                    LoggerFactory.Create(options => options.AddConsole())
                        .CreateLogger("AppModelExtensions")
                        .LogInformation("Обнаружили новую учётную запись");
                }
                logger.LogInformation("Формирование структуры данных выполнено успешно.");
            }
            catch (Exception ex)
            {
                logger.LogInformation("Ошибка при формировании структуры данных: " + ex);
            }

    }

    public static void RunDbConsoleController(this DbContext db)
    {
        ILogger logger =
            LoggerFactory.Create(options => options.AddConsole()).CreateLogger("Модель аутентификации. Регистрация учетных записей.");
        try
        {
            Clear();

            db.Database.EnsureCreated();
            logger.LogInformation(db.Database.GenerateCreateScript());
            logger.LogInformation(db.GetType().GetNameOfType());
            logger.LogInformation("update - выполнение миграций");
            logger.LogInformation("exit - выход из приложения");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "update":
                    db.Database.Migrate();
                    break;
                case "exit":
                    break;
                default:
                    logger.LogInformation("НЕ понятно");
                    break;
            }
        }
        catch (Exception ex)
        {

            logger.LogInformation("Схема данных не сгенерирована");
            logger.LogInformation(ex.Message);
            Console.ReadLine();
        }
    }

    public static async Task SendTextMessage(this HttpContext http, object list, string contentType)
    {
        http.Response.ContentType = contentType;
        await http.Response.WriteAsync(list.ToJsonOnScreen());
    }
    /// <summary>
    /// Состав операций
    /// </summary>
    public static IEnumerable<string> GetVerbs(this Assembly assembly)
    {
        List<string> res = new List<string>();
        foreach (Type type in assembly.GetControllers())
        {
            res.AddRange(type.GetMethods().Select(mbox => mbox.Name));
        }
        return new HashSet<string>(res);
    }


    /// <summary>
    /// Проверка имя есляется ли сущностью контекста базы данных
    /// </summary>    
    public static bool IsEntity(this string name)
    {
        var entityTypeNames = new CommonDataModel().GetEntityTypeNames();
        return entityTypeNames.Contains(TextCounting.GetSingleCountName(name)) || entityTypeNames.Contains(TextCounting.GetMultiCountName(name));
    }

    /// <summary>
    /// Перенаправление к операции =>         
    /// </summary>
    public static void Publish(this HttpContext http, string group)
    {
        DataRequestMessage message = http.ToRequestMessage();
        http.Response.Redirect("/AppModel/Publish?group=" + group);
    }






    public static IServiceCollection AddManagmentApiServices(this IServiceCollection services)
    {

        //services.AddScoped< ApiSalaryReportService>();
        return services;
    }


    public static void AddAppModelSessionBackgroundServices(this IServiceCollection services, IConfiguration configuration)
    {
       
    }


    public static void AddAppModelAuthorizationBackgroundServices(this IServiceCollection services, IConfiguration configuration)
    {
        //http
        services.AddHttpContextAccessor();
        services.AddTransient<HttpCookieManager>();


        //session
        services.AddSingleton<APIAuthorization, AuthorizationService>();
        services.AddSingleton<APIUsers, AuthorizationUsers>();
        services.AddSingleton<AuthorizationOptions>();

    }



    public static void AddAppModelAuthorizationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataModels(configuration);
        services.AddFileDatabase<AuthorizationDataModel>();
        
        services.AddEmail(configuration);
        services.AddScoped<APIAuthorization, AuthorizationService>();
        services.AddSingleton<AuthorizationOptions>();
        services.AddScoped<UserModelsService>();
        services.AddScoped<IUserNotificationsService, UserNotificationService>();
        services.AddScoped<UserMessagesService>();
    }

    /// <summary>
    /// 
    /// </summary>
    public class ExceptionCatcherMiddleware : IMiddleware
    {
        private readonly Func<Exception, string> _Catch;
        public ExceptionCatcherMiddleware(Func<Exception, string> Catch)
        {
            _Catch = Catch;
        }
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                Console.WriteLine($"{context.Items} ");
                return next.Invoke(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine("catch");
                return Task.Run(() => {
                    context.Response.WriteAsync(_Catch(ex));
                });
            }
        }
    }

    
    /// <summary>
    /// Извлечение модели запроса
    /// </summary>
    public static DataRequestMessage ToRequestMessage(this HttpContext httpContext)
    {
        LoggerFactory.Create(options => options.AddConsole()).CreateLogger(
            nameof(ExceptionCatcherMiddleware) + "." +
            nameof(ToRequestMessage)
        ).LogInformation($"ToRequestMessage( )");

        DataRequestMessage Request = new DataRequestMessage();
        var headers = new Dictionary<string, string>();
        foreach (var kv in httpContext.Request.Headers)
            headers[kv.Key] = kv.Value;

        Request.Headers = headers;
        Request.TraceId = httpContext.TraceIdentifier;
        Request.ActionName = httpContext.Request.Path.Value.ToString();
        Request.ParametersMap = httpContext.GetQueryParams();
        Request.MessageBody = httpContext.ReadRequestBody().Result;
        return Request;
    }

   
    /// <summary>
    /// Метод сериализации парамтеров в строку запроса
    /// </summary>
    public static string ToQueryString(this Dictionary<string, object> Params)
    {
        LoggerFactory.Create(options => options.AddConsole()).CreateLogger(
            nameof(ExceptionCatcherMiddleware) + "." +
            nameof(GetQueryParams)
        ).LogInformation($"ToQueryString(${Params.ToJsonOnScreen()})");

        string QueryString = "";
        foreach (var Entry in Params)
        {
            Type Type = Entry.GetType();
            QueryString += $"{Entry.Key}={Entry.Value}&";
        }
        return QueryString.Length > 0 ? "?" + QueryString : "";
    }


    /// <summary>
    /// Извлечение параметров запроса и контекста
    /// </summary>
    /// <param name="Http"> контекст протокола </param>
    /// <returns></returns>
    public static Dictionary<string, object> GetQueryParams(this HttpContext Http)
    {
        LoggerFactory.Create(options => options.AddConsole()).CreateLogger(
            nameof(ExceptionCatcherMiddleware) + "." +
            nameof(GetQueryParams)
        ).LogInformation($"GetQueryParams()");

        Dictionary<string, object> pars = new Dictionary<string, object>();
        foreach (var Entry in Http.Request.Query)
        {
            pars[Entry.Key] = Entry.Value;
        }
        return pars;
    }


    /// <summary>
    /// Считывание бинарных данных в основном блоке сообщения
    /// </summary>
    public static async Task<byte[]> ReadRequestBody(this HttpContext httpContext)
    {
        LoggerFactory.Create(options => options.AddConsole()).CreateLogger(
            nameof(ExceptionCatcherMiddleware) + "." +
            nameof(ReadRequestBody)
        ).LogInformation($"ReadRequestBody()");

        long? length = httpContext.Request.ContentLength;
        if (length != null)
        {
            byte[] data = new byte[(long)length];
            await httpContext.Request.Body.ReadAsync(data, 0, (int)length);
            string mime = httpContext.Request.ContentType;
            return data;
        }
        return new byte[0];
    }



}


[Icon("database")]
[Description("Интерфейс предназначен для реализации вызовов к контексту базы данных EF.")]
public interface IDbContext
{


    public int SaveChanges();
    public Task<int> SaveChangesAsync();

    public dynamic GetDbSet(string T);


    public IEnumerable<Type> GetEntityTypes();
    public IEnumerable<Type> GetEntityTypes<TEntityInterface>();
}


public static class DbContextExtension
{

    public static IDictionary<string, int> GetRecordsCount(this DbContext db)
    {
        var result = new Dictionary<string, int>();
        foreach (string name in db.GetEntityTypeNames())
        {
            try
            {
                result[name] = ((IDataCrud)db).Count(name);
            }catch (Exception ex)
            {
                db.Error(ex);
                continue;
            }
        }
        return result;
    }

    /// <summary>
    /// Контекст хранения данных
    /// </summary>
    /// <returns></returns>
    public static IQueryable<BaseEntity> GetDbSet(this BaseEntity target)
    {
        return (IQueryable<BaseEntity>)new AppDbContext().GetDbSet(target.GetType().Name);
    }

    public static bool IsValid(this DbContext db)
    {
        var emptyKV = db.GetRecordsCount().Where(kv => kv.Value == 0);
        foreach (var kv in emptyKV)
        {
            string inputSteps = "Необходимо наполнить данными следующие таблицы: " + kv.Key;
        }
        if (emptyKV.Count() > 0)
            return false;
        return true;
    }


    /// <summary>
    /// Получение сущностей типа таблица фактов
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public static HashSet<Type> GetHierDictionaries(this DbContext db)
    {
        HashSet<Type> entities = new HashSet<Type>();
        foreach (Type dbsetType in db.GetEntitiesTypes())
        {
            Type entityType = dbsetType.GenericTypeArguments[0];
            bool isHier = false;
            isHier = IsHierDictinary(entityType, isHier);
            if (isHier)
            {
                entities.Add(entityType);
            }
        }
        return entities;
    }

    private static bool IsHierDictinary(Type entityType, bool isHier)
    {
        Type p = entityType;
        while (p != typeof(Object) && p != null)
        {
            if (p.Name.StartsWith("HierDictionaryTable"))
            {
                isHier = true;
                break;
            }
            p = p.BaseType;
        }

        return isHier;
    }



    /// <summary>
    /// Получение сущностей типа таблица фактов
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public static HashSet<Type> GetFactsTables(DbContext _context)
    {
        HashSet<Type> entities = new HashSet<Type>();
        foreach (Type dbsetType in _context.GetEntitiesTypes())
        {
            Type entityType = dbsetType.GenericTypeArguments[0];
            Type p = entityType;
            while (p != typeof(Object) && p != null)
            {
                if (p.Equals(typeof(EventLog)))
                {
                    entities.Add(entityType);
                    break;
                }
                p = p.BaseType;
            }
        }
        return entities;
    }

    public static List<string> GetStatsTableNames(DbContext _context)
    {
        List<string> names = new List<string>();
        /*foreach(var p in _context.GetStatsTables())
        {
            names.Add(p.Name);
        }*/
        return names;
    }


    /// <summary>
    /// Получение сущностей типа таблица фактов
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public static HashSet<Type> GetStatsTables(DbContext _context)
    {
        HashSet<Type> entities = new HashSet<Type>();
        foreach (Type dbsetType in _context.GetEntitiesTypes())
        {
            Type entityType = dbsetType.GenericTypeArguments[0];
            Type p = entityType;
            while (p != typeof(Object) && p != null)
            {

                if (p.Equals(typeof(EventLog)))
                {
                    entities.Add(entityType);
                    break;
                }
                p = p.BaseType;
            }
        }
        return entities;
    }



    public static TimePoint GetTodayCalendar(IAuthorizationDataModel _context)
    {
        TimePoint c = (from cal in _context.Calendars where cal.Timestamp == TimeUtils.GetTodayBeginTime() select cal).FirstOrDefault();
        DateTime p = DateTime.Now;
        if (c == null)
        {
            _context.Calendars.Add(c = new TimePoint()
            {
                Day = p.Day,
                Quarter = p.Month < 4 ? 1 : p.Month < 7 ? 2 : p.Month < 10 ? 3 : 4,
                Month = p.Month,
                Week = 1,
                Year = p.Year,
                Timestamp = (long)((new DateTime(p.Year, p.Month, p.Day) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds)
            });
            _context.SaveChanges();
        }
        return c;
    }

}


/// <summary>
/// Расширение класса DbContext
/// </summary>
public static class DbContextExtensions
{
    /// <summary>
    /// Нехороший способ извеления наименований сущностей
    /// </summary>
    /// <param name="subject"> контекст данных </param>
    /// <returns> множество наименований сущностей </returns>
    /*public static HashSet<Type> GetEntitiesTypes( this DbContext subject)
    {
        Type type = subject.GetType();
        HashSet<Type> entities = new HashSet<Type>();
        foreach (MethodInfo info in type.GetMethods())
        {
            if (info.Name.StartsWith("get_") == true && info.ReturnType.Name.StartsWith("DbSet"))
            {
                if (info.Name.IndexOf("MigrationHistory") == -1)
                {
                    entities.Add(info.ReturnType);
                }
            }
        }
        return entities;
    }
    */








    public static dynamic DbSetFor(this DbContext _context, string entityTypeShortName)
    {
        foreach (MethodInfo info in _context.GetType().GetMethods())
        {
            if (info.Name.StartsWith("get_") == true && info.ReturnType.Name.StartsWith("DbSet"))
            {
                if (info.Name.IndexOf("MigrationHistory") == -1)
                {

                    string displayName = info.ReturnType.ShortDisplayName();
                    string entityTypeName = displayName.Substring(displayName.IndexOf("<") + 1);
                    entityTypeName = entityTypeName.Substring(0, entityTypeName.IndexOf(">"));
                    
                    if (entityTypeShortName == entityTypeName)
                    {
                     
                        return (dynamic)info.Invoke(_context, new object[0]);
                    } 
                }

            }
        }

        throw new Exception($"Сущность [{entityTypeShortName}] не определена в контексте базы данных");
    }

    public static dynamic GetDbSet<T>(this DbContext _context)
    {
        return _context.GetDbSet(typeof(T).Name);
    }

    /// <summary>
    /// Получение первичных ключей
    /// </summary>
    /// <param name="_context"></param>
    /// <param name="entityType"></param>
    /// <returns></returns>
    public static IEnumerable<IKey> GetEntityKeys(this DbContext _context, Type entityType)
    {
        IEntityType entity = (from navs in _context.Model.GetEntityTypes() where navs.Name == entityType.FullName select navs).FirstOrDefault();
        return entity.GetKeys();
    }




    /// <summary>
    /// Получение свойств навигации
    /// </summary>
    /// <param name="_context"></param>
    /// <param name="singleRecord"></param>
    /// <returns></returns>
    public static IEnumerable<INavigation> GetNavigationProperties(this DbContext _context, object singleRecord)
    {
        IEntityType entity = (from navs in _context.Model.GetEntityTypes() where navs.Name == singleRecord.GetType().FullName select navs).FirstOrDefault();
        return entity.GetNavigations();
    }
    public static IEnumerable<INavigation> GetNavigationPropertiesForType(this DbContext _context, Type type)
    {
        IEntityType entity = (from navs in _context.Model.GetEntityTypes() where navs.Name == type.FullName select navs).FirstOrDefault();
        IEnumerable<INavigation> navigations = entity.GetNavigations();
        return navigations;
    }




    /// <summary>
    /// Получение значения атрибута Label
    /// </summary>
    /// <param name="_context"></param>
    /// <param name="entityType"></param>
    /// <param name="nav"></param>
    /// <returns></returns>
    public static string GetDisplayName(this DbContext _context, Type entityType, string propertyName)
    {
        string name = "";
        foreach (var prop in _context.GetEntityProperties(entityType))
        {
            if (prop.Name.Equals(propertyName + "ID") || prop.Name.Equals(propertyName))
            {
                foreach (var attr in prop.PropertyInfo.GetCustomAttributesData())
                {
                    if (attr.AttributeType.Name == "DisplayAttribute" || attr.AttributeType.Name == "DisplayNameAttribute")
                    {
                        foreach (var arg in attr.ConstructorArguments)
                        {
                            if (string.IsNullOrEmpty(name = arg.Value.ToString()) == false)
                            {
                                break;
                            }

                        }
                    }

                }
            }
        }
        return name;
    }

    /// <summary>
    /// Получение значения атрибута Label
    /// </summary>
    /// <param name="_context"></param>
    /// <param name="entityType"></param>
    /// <param name="nav"></param>
    /// <returns></returns>
    public static string GetDisplayName(this DbContext _context, Type entityType, INavigation nav)
    {
        string name = "";
        foreach (var prop in _context.GetEntityProperties(entityType))
        {
            if (prop.Name.Equals(nav.Name + "ID") || prop.Name.Equals(nav.Name))
            {
                foreach (var attr in prop.PropertyInfo.GetCustomAttributesData())
                {
                    if (attr.AttributeType.Name == "DisplayNameAttribute")
                    {
                        foreach (var arg in attr.ConstructorArguments)
                        {
                            name = arg.Value.ToString();
                            break;
                        }
                    }

                }
            }
        }
        return name;


    }

    public static IEnumerable<IProperty> GetEntityProperties(this DbContext _context, Type entityType)
    {
        IEntityType entity = (from navs in _context.Model.GetEntityTypes() where navs.Name == entityType.FullName select navs).FirstOrDefault();
        return entity.GetProperties();
    }

    public static IEnumerable<IAnnotation> GetAnnotationsForObject(this DbContext _context, object singleRecord)
    {
        IEntityType entity = (from navs in _context.Model.GetEntityTypes() where navs.Name == singleRecord.GetType().FullName select navs).FirstOrDefault();
        return entity.GetAnnotations();
    }
    public static Dictionary<string, object> GetAnnotationsForType(this DbContext _context, Type type)
    {
        Dictionary<string, object> attributes = new Dictionary<string, object>();
        IEntityType entity = (from navs in _context.Model.GetEntityTypes() where navs.Name == type.FullName select navs).FirstOrDefault();
        foreach (IAnnotation an in entity.GetAnnotations())
        {
            attributes[an.Name] = an.Value;
        }
        return attributes;
    }
    public static IEnumerable<IAnnotation> GetAnnotationsForType(this DbContext _context, string fullName)
    {
        IEntityType entity = (from navs in _context.Model.GetEntityTypes()
                              where navs.Name == fullName
                              select navs).FirstOrDefault();
        return entity.GetAnnotations();
    }
    public static List<string> GetEntityTypeNames(this DbContext _context)
    {
        var list = new List<string>();
        foreach(PropertyInfo p in _context.GetType().GetProperties())
        {
            if(p.PropertyType.GetTypeName().IndexOf("DbSet") != -1)
            {
                list.Add(Typing.ParseCollectionType(p.PropertyType));
            }
        }
        return list;
    }


    /// <summary>
    /// Таблицы фактов
    /// </summary> 
    public static List<Type> GetFacts(this DbContext ctx)
    {
        var res = new List<Type>();
        ctx.GetEntityTypeNames().ForEach(name =>
        {
            if (name.ToType().IsExtends(nameof(EventLog)))
            {
                res.Add(name.ToType());
            }
        });
        return res;
    }
    /// <summary>
    /// Случайный набор данных
    /// </summary>
    /// <param name="ctx"></param>
    public static dynamic GetRandomDbSet(this DbContext ctx)
    {
        string[] arr = ctx.GetEntityTypeNames().ToArray();
        int n = Randomizing.GetRandomInt(0, arr.Length);

        return ctx.GetDbSet(arr[n]);
    }



    /// <summary>
    /// Случайное имя типа
    /// </summary> 
    public static string GetRandomTypeName(this DbContext ctx)
    {
        string[] arr = ctx.GetEntityTypeNames().ToArray();
        int n = Randomizing.GetRandomInt(0, arr.Length - 1);
        return arr[n];
    }


    /// <summary>
    /// Метод генерации случайного пароля заданной длины
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string GenRandom(this string s, int l)
    {
        Random random = new Random(DateTime.Now.Millisecond + 100);
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                        "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower() +
                        "0123456789";
        return new string(Enumerable.Repeat(chars, l)
                            .Select(s => s[random.Next(s.Length)]).ToArray());

    }







    public static void _insert(this object collection, object item)
    {
        var m = collection.GetType().GetMethod("Add");
        if (m != null)
        {
            m.Invoke(collection, new object[] { item });
        }
    }

    public static dynamic _random(this Type type)
    {

        object values = null;
        if (TypeUtils.IsPrimitive(type) == true)
        {
            if (type == typeof(int))
            {
                return Randomizing.GetRandomInt(0, 10);
            }
            else if (type == typeof(bool))
            {
                return Randomizing.GetRandomInt(0, 100) >= 50;
            }
            else if (type == typeof(string))
            {
                return GetHashSha256("");
            }
            else if (type == typeof(int?))
            {

                int ri = Randomizing.GetRandomInt(0, 10);
                return ri == 0 ? null : ri;
            }
            else if (type == typeof(float))

            {
                return (Randomizing.GetRandomInt(0, 100)) / 100;
            }
            else if (type == typeof(DateTime))
            {


                return Randomizing.GetRandomDate(DateTime.Now, DateTime.Now.AddYears(1));
            }
            else if (type == typeof(DateTime?))
            {
                return Randomizing.GetRandomDate(DateTime.Now, DateTime.Now.AddYears(1));
            }
            else if (type == typeof(float?))
            {

                return (Randomizing.GetRandomInt(0, 100)) / 100;
            }



        }
        else
        {
            if (TypeUtils.IsCollectionType(type))
            {
                values = new List<object>();
                Type t = TypeUtils.ParseCollectionType(type).ToType();
                for (int i = 0; i < 100; i++)
                {

                    values._insert((object)t._random());
                }
            }
            else
            {

                return type.Name.New();
            }
        }
        return values;
    }

    private static dynamic GetHashSha256(string v)
    {
        throw new NotImplementedException($"{typeof(ExceptionCatcherMiddleware).GetTypeName()}");
    }

    public static object GetRandomMessage(this DbContext ctx)
    {
        var entityTypeName = ctx.GetRandomTypeName().ToType();

        ctx.Info($"Получение случайного значения {entityTypeName}");
        object value = entityTypeName._random();
        return value;
    }


}