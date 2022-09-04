using System;
using System.IO;
using System.Linq;
using ReCaptcha;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using static Api.Utils;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public interface IRun
{
    public void Begin();
    public void Continue(string stage);
    public void Continue();
}


/// <summary>
/// Выполнение приложения 
/// </summary>
public class RunCommonApplication: IRun
{
    private static string DEFAULTS_DEV_URL = "http://localhost:4200";

    /// <summary>
    /// 
    /// </summary> 
    public static void Start(ref string[] args)
    {
        if (args.Length > 0)
        {
            StartProxyServer(args[0], ref args);
        }
        else
        {
            StartProxyServer(DEFAULTS_DEV_URL, ref args);
        }
    }




    /// <summary>
    /// Воспроизведение структуры данных и инициаллизация минимального набора
    /// </summary>    
    public static void GenerateDatabases(IHost host)
    {
        try
        {
            using (var scope = host.Services.CreateScope())
            {
                Clear();
                scope.ServiceProvider.GetService<NameServiceProvider>().GetServiceNames().ToJsonOnScreen().WriteToConsole();
                Api.Utils.ConfirmContinue();
                GenerateDatabaseSchema<AppDbContext>(scope);
                GenerateDatabaseSchema<AnaliticsDataModel>(scope);
                GenerateDatabaseSchema<AuthorizationDataModel>(scope);
                GenerateDatabaseSchema<MarketDataModel>(scope);
                GenerateDatabaseSchema<ManagmentDataModel>(scope);
                GenerateDatabaseSchema<FilesDataModel>(scope);
                GenerateDatabaseSchema<MedicalDataModel>(scope);
                GenerateDatabaseSchema<DeployDataModel>(scope);
                GenerateDatabaseSchema<CustomerDataModel>(scope);
                GenerateDatabaseSchema<BusinessDataModel>(scope);

                scope.ServiceProvider.GetService<APIAuthorization>().Signup("eckumocuk@gmail.com", "eckumocuk@gmail.com", "eckumocuk@gmail.com");

            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }        
    }



    /// <summary>
    /// Выполнение с перенаправлением на прокси сервер
    /// </summary>    
    public static void StartProxyServer(string url, ref string[] args)
    {
        Info($"StartProxyServer({url})");

        var config = new ConfigureCommonApplication();
        string[] argments = config.GetArguments().ToArray();
         
        var process = new RunCommonApplication( );
        Info();
        try
        {
            var host = process.CreateHostBuilder(url).Build();
            ConfirmExecute("Сгенерить структуру данных",() => {
                GenerateDatabases(host);
            });
            host.Run();
        }
        catch (AggregateException ex)
        {
            Error(ex);
            var keys = GetExecutingAssembly().GetTypes().Select(t => t.Name);
            ex.Message.SplitWords()
                .Where(word => word.EndsWith("Controller")==false && keys.Contains(word)).ToHashSet()
                .Select( word => $"services.AddScoped<{word}>();")
                .ToJsonOnScreen().WriteToConsole();
        }
        catch (Exception ex)
        {
            Error(ex);
            process.Error(ex);
        }
    }

    

    /// <summary>
    /// Сборка модулей приложений аргументы( путь к директориям, тип модулей )
    /// </summary>
    public IHostBuilder CreateHostBuilder(string url)
    {
        Clear();
        var builder = Host.CreateDefaultBuilder( );
        builder.ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureServices(ConfigureServices);

            CommonApplication.ProxyUrl = url;
            webBuilder.UseStartup<CommonApplication>();
        });

        
        builder.ConfigureServices(services =>
        {                
            services.AddSingleton<AuthorizationOptions>();
            services.AddSingleton<APIAuthorization, AuthorizationService>();
            services.AddSingleton<APIServices, AuthorizationServices>();
            services.AddSingleton<APIUsers, AuthorizationUsers>();
            services.AddSingleton<SessionOptions>();
            services.AddSingleton<Service>();
            services.AddSingleton<ReCaptchaOptions>();
            services.AddSingleton<EmailOptions>();
        });
               
        return builder;
    }

 
    /// <summary>
    /// Регистрация сервисов в контейнере
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
        this.Info($"OnConfigureServices()");

        services.AddRazorPages().AddRazorRuntimeCompilation();
        services.AddControllersWithViews().AddRazorRuntimeCompilation();
        services.AddSignalR();     
        services.AddSession();
    }


    /// <summary>
    /// Конфигурация конвеера обработки запросов
    /// </summary>
    public void Configure(IApplicationBuilder app)
    {
        this.Info($"OnConfigureMiddleware()");

        app.UseMiddleware<AppMiddlewareComponent>();
        app.UseDeveloperExceptionPage();
        app.UseStaticFiles("/wwwroot");
        app.UseSpaStaticFiles();
        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseSession();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllerRoute("default", "{controller=Api}/{action=Index}");
            endpoints.MapHub<ServiceAgentsHub>("/hubs/service-agents");
            endpoints.MapHub<UserAgentsHub>("/hubs/user-agents");
            endpoints.MapFallbackToController("Http404", "Api");
        });
    }

     
    /// <summary>
    /// Конфигурация фоновой службы аутентификации
    /// </summary>
    public void ConfigureBackgroundAuth(IServiceCollection services)
    {
        try
        {
            var builder = new CommonAppBuilder(services);
            builder.AddSingleton<AuthorizationOptions>();
            builder.AddSingleton<APIServices, AuthorizationServices>();
            builder.AddSingleton<APIUsers, AuthorizationUsers>();
            builder.AddHostedService<AuthorizationBackground>();
            builder.AddSingleton(typeof(AuthorizationClient), sp =>
               new AuthorizationClient(
                   sp.GetService<AuthorizationOptions>(),
                   sp.GetService<Service>()
               ));
            builder.AddSingleton<Service>();
        }
        catch (Exception ex)
        {
            Error("Исключение перехвачено в методе ConfigureServices", ex);
        }
    }


    

    /// <summary>
    /// Генерация статических ресурсов
    /// </summary>
    private static void Generate()
    {
        string AppLoginDir = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Views".ToString());
        using (var ctx = new AppDbContext())
        {
            ConverterAngular.GenerateDataModelToTypeScript(
                   $@"{AppLoginDir}\ViewScripts\data-model\", ctx);

            FactoryUtils.Get().AddTypes(typeof(FunctionSkills).Assembly);
            foreach (Type ctrl in FactoryUtils.Get().GetControllers().Values)
            {
                string script = CoreCommon.DataConverter.Generators.JavaScript.JavaScriptHttpClientGenerator.Create(ctrl);
                System.IO.File.WriteAllText(
                    @$"{AppLoginDir}\ViewScripts\web-services\" +

                    TextNaming.ToKebabStyle(ctrl.Name) + ".js",
                    script);
            }


            ConverterAngular.GenerateDataModelToJavaScript(ctx,
                @$"{AppLoginDir}\ViewScripts\");
        }
        DataInitiallizer.ValidateDatabase();
    }


    /// <summary>
    /// Восстановление структуры данных
    /// </summary>
    public static void GenerateDatabaseSchema<TDataModel>(IServiceScope scope) where TDataModel : BaseDbContext
    {
        try
        {
            scope.Info(typeof(TDataModel).GetNameOfType());

            using (var db = scope.ServiceProvider.GetRequiredService<TDataModel>())
            {

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                db.InitData();
            }
        }
        catch (InvalidOperationException ex)
        {
            scope.Info($"Зарегистрируйте тип {typeof(TDataModel).GetNameOfType()}");
            scope.Error(ex);
            throw new Exception("В контейнере не зарегистриован сервис " + typeof(TDataModel).GetNameOfType());

        }
        catch (Exception ex)
        {
            scope.Error(ex);
            throw new Exception("В контейнере не зарегистриован сервис " + typeof(TDataModel).GetNameOfType());
        }
    }

    public void Begin()
    {
        
    }

    public void Continue(string stage)
    {
    }

    public void Continue()
    {
    }
}
 