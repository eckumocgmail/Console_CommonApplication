using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


using static Api.Utils;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Text;


/// <summary>
/// Основной модуль приложения
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class RootModule : RootModule<DataSqlLiteModule<AuthorizationDataModel>> 
{ 
}


/// <summary>
/// Основной модуль приложения
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class RootModule<TModule> : SPAModule where TModule : Module
{
 
    public RootModule() : base()
    {
        ApplyConfiguration(GetConfiguration());
    }

    public override void ApplyConfiguration(IConfiguration Configuration = null)
    {
        this.Info("Применяю параметры конфигурации();");
        base.ApplyConfiguration(Configuration);
        //Import(new FilesServiceModule());

        Import(new TransportModule());       
        Import((TModule)typeof(TModule).New());

        var datasources = Configuration.GetSection("DataSources");
        List<KeyValuePair<string, object>> ds = datasources.Get<List<KeyValuePair<string, object>>>();
        this.TraceHier();
    }



    /// <summary>
    /// Регистрация сервисов
    /// </summary>
    public override void OnConfigureServices(IServiceCollection services)
    {
        //регистрация сервис ISpaFileProvider
        this.Info("OnConfigureServices()");

        base.OnConfigureServices(services);
        services.AddScoped<ITokenStorage, FileTokenStorage>();
        services.AddScoped(typeof(HttpClientController), sp =>
        {
            return new HttpClientController(
                sp.GetService<ITokenStorage>() );
        });
        services.AddSignalR();
        var builder1 = services.AddRazorPages().AddRazorRuntimeCompilation();
        var builder2 = services.AddControllersWithViews().AddRazorRuntimeCompilation();
        GetAssemblies().ToList().ForEach(lib => builder1.AddApplicationPart(lib));
        GetAssemblies().ToList().ForEach(lib => builder2.AddApplicationPart(lib));
        ConfigurProvider(services);

    }

    public override void OnConfigureMiddleware(IApplicationBuilder app)
    {
    }


    public override void ConfigureEndpoint(IEndpointRouteBuilder endpoint)
    {

    }


    /// <summary>
    /// Печать иерархии зависимостей
    /// </summary>
    private void TraceHier()
    {
        Action<ICoreModule> OnNode = (node) =>
        {
            node.CurrentType = node.GetType();
            this.Info(node.GetVirtualIP());
        };
        this.ForEach(OnNode);
    }


    /// <summary>
    /// 
    /// </summary>
    public override void ConfigureApi(ApiBehaviorOptions behaviour)
    {
        this.Info($"ConfigureApi({(behaviour)})");
        behaviour.ClientErrorMapping[1] = new ClientErrorData()
        {
            Link = "404",
            Title = "Ресурс не найден"
        };
        behaviour.ClientErrorMapping[1] = new ClientErrorData()
        {
            Link = "500",
            Title = "Внутренее исключение"
        };

    }






    protected virtual void ConfigurProvider(IServiceCollection services)
    {
        this.Info($"ConfigureProvider() ... ");

        IList<string> declarations = new List<string>();
        foreach (var type in services.ToList().Select(s => s.ServiceType).ToArray())
        {
            FactoryUtils.Get().AddTypes(type.Assembly);
            declarations.Add(type.GetNameOfType());
        }
        NameServiceProvider.AddNamespace(services);
    }

    protected override void OnConfigureEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapRazorPages();
    }


    protected override void ConfigureDispatcher(HttpConnectionDispatcherOptions dispatcher)
    {
        this.Info("ConfigureDispatcher()");
        foreach (var auth in dispatcher.AuthorizationData)
        {
            string[] roles = (string.IsNullOrEmpty(auth.AuthenticationSchemes) == false) ?
                auth.AuthenticationSchemes.Split(",") : new string[0];
            foreach (var scheme in auth.AuthenticationSchemes)
            {

                this.Info($"\t dispatcher must authorization by scheme {scheme} like one of: ");
                foreach (string role in roles)
                {
                    this.Info("\t\t" + role);
                }

            }
        }
    }
    public override void ConfigurateJson(JsonOptions json)
    {
        this.Info($"ConfigurateJson( {Formating.ToJson(json) } )");
    }

    public override void ConfigurateApiControllers(MvcOptions options)
    {
        this.Info($"ConfigureApiControllers( {Formating.ToJson(options) } )");
    }
}

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public abstract class ViewModule : Module
{

    public ViewModule() : base()
    {
        CurrentType = typeof(ViewModule);

    }


    protected abstract void OnConfigureEndpoint(IEndpointRouteBuilder endpoints);

    protected abstract void ConfigureDispatcher(HttpConnectionDispatcherOptions dispatcher);

    public abstract void ConfigureApi(ApiBehaviorOptions behaviour);

    public abstract void ConfigurateJson(JsonOptions json);
    public abstract void ConfigurateApiControllers(MvcOptions options);



    public abstract void ConfigureEndpoint(IEndpointRouteBuilder app);

}


[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class AppServiceModel
{
    public AppServiceModel()
    {
    }

}


public class DataModule<DataContextType>
{
}

public interface IHttpHandler
{
    public void OnHttpRequest(HttpContext httpContext);
}


public interface ICoreModule: IHttpHandler
{
    public Type CurrentType { get; set; }
    public ICoreModule Parent { get; set; }
    public List<ICoreModule> Imports { get; set; }
    void ConfigureWebHost(Microsoft.AspNetCore.Hosting.IWebHostBuilder builder);
    void Broadcast(Action<object> todo);
    void ForEach(Action<ICoreModule> OnNode);


    void Import(ICoreModule module);
    void OnConfigureMiddleware(IApplicationBuilder app);
    void OnConfigureServices(IServiceCollection services);
    void Configure(IApplicationBuilder app);
    void ConfigureServices(IServiceCollection services);
    
    HashSet<Assembly> GetAssemblies();
    int GetLevel();
    int GetOrder();
    string GetVirtualIP();
    
}

/// <summary>
/// Модульный тест, тестирует группу объектов, методов функций 
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public abstract class Module : ConsoleProgram<Module>, ICoreModule
{
    private ServiceCollection Services = new ServiceCollection();

    public string WebRoot { get; set; } = 
        Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");

    public Module()
    {
        this.CurrentType = typeof(Module);
        this.Log();
    }

    public override string ToString()
    {
        return GetType().GetTypeName();
    }

    [NotInput()]
    public Type CurrentType { get; set; }

    //[SelectControl("{{GetModulesNames()}}")]
    public ICoreModule Parent { get; set; }

    [InputStructureCollection("")]
    public List<ICoreModule> Imports { get; set; } = new List<ICoreModule>();

    private string GetWebRoot() => WebRoot;


    /// <summary>
    /// Конфигурация хоста
    /// </summary>    
    public virtual void ConfigureWebHost(Microsoft.AspNetCore.Hosting.IWebHostBuilder builder)
    {
        this.Info("Настройка веб-сервера()");

        builder.UseWebRoot(GetWebRoot());        
        builder.ConfigureServices(ConfigureServices);
        builder.Configure(Configure);
    }


    public void Test(IHost host)
    {

    }

    public void Setup()
    {
        RunInteractive(this);
    }


    /// <summary>
    /// Конфигурация приложения зависит от рабочей директории
    /// </summary>    
    protected IConfiguration Configuration { get; set; }
    public virtual IConfiguration GetConfiguration()
    {
        Info("Рабочая директория " + GetWrk());

        var builder = new ConfigurationBuilder();
        foreach (var jsonFile in GetJsonFiles())
            builder.AddJsonFile(jsonFile);
        foreach (var iniFile in GetIniFiles())
            builder.AddIniFile(iniFile);
        return builder.Build();
    }

    /// <summary>
    /// Реализация функции регистрации сервисов
    /// </summary>
    /// <param name="services"></param>
    public abstract void OnConfigureServices(IServiceCollection services);


    /// <summary>
    /// Последовательный вызов событий регистрации сервисов
    /// </summary>
    /// <param name="services"></param>
    public virtual void ConfigureServices(IServiceCollection services)
    {

        this.Info("ConfigureServices(...)");
        services.AddScoped<ListItemService>();
        services.AddScoped<ListService>();
        var ctrl = this;
        FactoryUtils.Get().AddTypes(this.GetType().Assembly);
        services.AddSingleton(this.GetType(), (p) => { return ctrl; });
        OnConfigureServices(services);
        foreach (var childModule in Imports)
        {
            childModule.ConfigureServices(services);
        }
    }


    /// <summary>
    /// Реализация функции регистрации компонентов промежуточного ПО
    /// </summary>
    /// <param name="services"></param>
    public abstract void OnConfigureMiddleware(IApplicationBuilder app);


    /// <summary>
    /// Последовательный вызов событий регистрации компонентов промежуточного ПО
    /// </summary>
    /// <param name="services"></param>
    public virtual void Configure(IApplicationBuilder app)
    {
        this.Info("Configure(...)");
        app.Use(async (context, next) =>
        {
            this.Info(context.Request.Path);
            await next.Invoke();
        });
        OnConfigureMiddleware(app);
        foreach (var childModule in Imports)
        {
            childModule.Configure(app);
        }
    }

    public void OnHttpRequest(HttpContext httpContext)
    {
        this.Info(this.GetActionInfo());
    }
    /// <summary>
    /// Регистрация сборки тестирования
    /// </summary>
    public virtual void ApplyConfiguration(IConfiguration configuration = null)
    {
        


        CurrentType = typeof(ICoreModule);
        Imports = new List<ICoreModule>();

        FactoryUtils.Get().AddTypes(this.GetType().Assembly);
    }


    
    /// 
    public int GetLevel()
    {
        int ctn = 0; ICoreModule p = this;
        while (p != null)
        {
            p = p.Parent; ctn++;
        }
        return ctn;
    }


    /// 
    public int GetOrder() { 
   
        if (Parent != null)
        {
            return Parent.Imports.IndexOf(this);
        }
        return 255;
    }


    /// 
    public string GetVirtualIP()
    { 
        string addr = "";
        int ctn = 1; ICoreModule p = this;
        while (p != null)
        {
            addr += p.GetOrder() + ".";
            p = p.Parent; ctn++;
        }
        while (ctn < 7)
        {
            addr += "0.";
            ctn++;
        }
        addr += "0";

        return addr;
    }


    /// 
    protected List<ICoreModule> GetImports() => Imports;
    public void Import(ICoreModule module)
    {
        this.Info("Импорт модуля на уровень " + module.GetLevel() + " " + module.GetTypeName());
        module.Parent = this;
        Imports.Add(module);
    }





    /// <summary>
    /// Выполнение для каждого модуля
    /// </summary>
    /// <param name="todo"></param>
    public void Broadcast(Action<object> todo)
    {
        this.Info($"Broadcast({todo})");
        todo(this);
        foreach (var p in Imports)
        {
            p.Broadcast(todo);
        }
    }


    /// <summary>
    /// Получение коллекции сборок
    /// </summary>
    /// <returns></returns>
    public HashSet<Assembly> GetAssemblies()
    {     
        var list = new HashSet<Assembly>();
        list.Add(this.GetType().Assembly);
        Func<HashSet<Assembly>, HashSet<Assembly>, HashSet<Assembly>> Concatenation = (l, r) =>
        {
            foreach (var item in r)
            {
                l.Add(item);
            }
            return l;
        };
        Imports.ForEach(p =>
        {
            Concatenation(list, p.GetAssemblies());
        });
        return list;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="OnNode"></param>
    public void ForEach(Action<ICoreModule> OnNode)
    {
        OnNode(this);
        Imports.ForEach(OnNode);
    }

    
} 