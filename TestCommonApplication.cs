using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;

using static Api.Utils;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

[Label("Функциональный тест")]
[Description("Класс отвечает за проверку функциональной состовляющей приложения. ")]
[Icon("universal.png")] 
public class TestCommonApplication : TestingUnit
{
    public static void Main(ref string[] args)    
    {
         
        AppProviderService.GetInstance().AddSingletons(GetExecutingAssembly().GetClassTypes());
        
        

        RunTestUnit();
        RunTestFunc();
        RunTestInt();
        RunCommonApplication.Start(ref args);
    }

    public override TestReport DoTest(bool strict = false, bool interactive = false)
    {
        return base.DoTest(strict, interactive);   
    }
    private static int RunTestFunc()
    {
        int max = 0;
        int version = 0;
        using (var db = new AppDbContext())
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            int rolesCounter = 0;
            foreach (var br in db.BusinessResources.ToList())
            {


                int functionsCounter = 0;
                foreach (var bf in db.BusinessFunctions.Where(bfn => bfn.BusinessResourceID == br.ID))
                {

                    if (RunTestFunc(db, br, bf))
                    {
                        functionsCounter++;
                        version++;
                    }
                    max++;

                }
                rolesCounter++;
            }
        }
        Info("Реализовано {} из {} функций");
        return version;
    }


    /// <summary>
    /// Проверка работоспособности функции приложения
    /// </summary>

    private static bool RunTestFunc(AppDbContext db, BusinessResource br, BusinessFunction bf)
    {
        return true;
    }

    private static int RunTestInt() => 0;



    /// <summary>
    /// Продолжает выполнение тестов начиная с последнего успешно выполненого элемента.
    /// Используется в "Строгом режиме", который предполгает прерывание в случае 
    /// отрицательного результата проверки.
    /// </summary>
    /// <returns>Версия приложения</returns>
    private static int RunTestUnit()
    {
        int version = 0;
        try
        {
            var app = new TestCommonApplication(true);
            var report = app.DoTest(false, false);
            version = report.GetVersion();

            report.ToDocument().WriteToConsole();
        }catch (Exception ex)
        {
            Error(ex);
        }

        return version;
    }


    /// <summary>
    /// Аналогично методу Continue зп исключением того, что выполнение элемента 
    /// проверки исполняется после подтверждения пользоателем. После отказа
    /// тест пропускается и ваполняетсяф следующий.
    /// </summary>
    /// <returns></returns>
    public static int ContinueInteractive()
    {
        int version = 0;

        var app = new TestCommonApplication();
        version = app.DoTest(true, true).GetVersion();

        return version;
    }


    /// <summary>
    /// Регистрация сервисов в контейнере
    /// </summary>    
    public void OnConfigureServices(IServiceCollection services)
    {
        AddUnitTests(services);
        AddBusinessTests(services);
        AddIntegrationTests(services);
        AddSelf(services);
    }

    private void AddSelf(IServiceCollection services)
    {
        services.AddSingleton(this);
    }

    private void AddIntegrationTests(IServiceCollection services)
    {
      
    }

    private void AddBusinessTests(IServiceCollection services)
    {
   
    }


    /// <summary>
    /// 
    /// </summary>
    private void AddUnitTests(IServiceCollection services)
    {
        foreach (var service in services)
        {

        }
    }


    public void OnConfigureMiddleware(IApplicationBuilder app)
    {
        var module = new Dictionary<string, Action<IApplicationBuilder>>();
       
        app.UseRouting();
        app.UseEndpoints(endpoints => {
            foreach(var kv in module)
            {
                app.Map(kv.Key, http =>
                {
                    kv.Value(http);
                });
            }
            
        });
        app.Run(http => {
            return Task.CompletedTask;
        });
    }

    /// <summary>
    /// Выполнение статически заврегистрирооованных модульных тестов
    /// </summary>   
    public static int RunTest(ref string[] args)
    {
        int n = 0;
        do
        {
             
            Info("Выполняем тестирование...");
            var created = Create(args);
            created.DoTest(ProgramDialog.SingleSelect(

            "Выполнять тесты в интерактивном режиме?",
            new string[]{
                "Да","Нет"
            }, ref args) == "Да").ToDocument().WriteToConsole();
            WriteLine("");
            WriteLine("");
            n++;
            WriteLine("Для выхода введите Y");

        } while (Console.ReadLine().ToLower() != "y");
        return n;
    }
     


    /// <param name="args">Аргументы полученные от коммандной оболочки</param>    
    private static TestCommonApplication Create(params string[] args)
    {
        var program = new TestCommonApplication();
        foreach (var arg in args)
            try
            {
                program.OnMessage(arg);
            }
            catch (Exception ex)
            {
                program.Error(ex,ex.Message);
            }

        return program.Commit<TestCommonApplication>(
            () => {                                
                return program;
            },
            new Dictionary<string, object>()
            {
                {"args", args }
            } );        
    }



    public void LogTestPlan()
    {
        this.ToNode().GoToChildren((node) => {
            string before = "";
            for (int i = 0; i < node.GetLevel(); i++)
                before += "\t";

            
            Console.WriteLine($"{before}{node.GetIntPath()}: {node.Item.GetTypeName()}"); ;
            
        });
        Api.Utils.ConfirmContinue();
    }


    
        
    

    /// <summary>
    /// Типы сообщений
    /// </summary>
    enum AppRootProgramMessageType{ Command, Url, Module, Key }

    /// <summary>
    /// Обработка текстового сообщения
    /// </summary>    
    private void OnMessage(string arg)
    {        
        this.Info(arg);
        
        switch (arg[0])
        {
            case '.': OnCommandArgument(arg.Substring(1)); break;
            case '<': OnUrlArgument(arg.Substring(1)); break;
            case '/': OnKeyArgument(arg.Substring(1)); break; 
            case ':': OnModuleArgument(arg.Substring(1)); break;
            
            default: throw new ArgumentException(
                $"Аргумент запуска задан неверно. " +
                $"Убедитесь что все аргументы начинаются со символа ch=[:<./]");
        }
    }

    private void OnCommandArgument(string v)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    private void OnKeyArgument(string v)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    private void OnUrlArgument(string v)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    /// <summary>
    /// Сборка приложения
    /// </summary>
    public virtual IHost Build<T>(int https= 5001) where T : ICoreModule
    {
        this.Info($"Сборка модуля {typeof(T).GetNameOfType()}");

        Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
        try
        {
            T module = (T)typeof(T).New();
            var hostBuilder = Host.CreateDefaultBuilder();
            hostBuilder = hostBuilder.ConfigureWebHostDefaults(webBuilder =>
            {
                
                webBuilder.UseUrls($"https://127.0.0.1:{https};");
                webBuilder.ConfigureServices(module.ConfigureServices);
                webBuilder.Configure(module.Configure);
                webBuilder.ConfigureServices(services => services.AddSingleton(typeof(T)));
            });

            IHost host = hostBuilder.Build();

            return host;
        }
        catch (Exception ex)
        {
            ex.ToDocument().Log();
            throw;
        }
    }



    private void OnModuleArgument(string module)
    {
        try
        {
            var core = module.New();
            core.GetProcedure("ConfigureService");
        }
        catch (Exception)
        {
            
        }
    }


    /// <summary>
    /// Ключи исполнения программы:
    /// /mvc         - mvc
    /// /blazor      - web assembly
    /// /concole     - консоль
    /// /webapi      - веб-хост
    /// /win         - настолььное приложение
    /// /background  - фоновый режим
    /// </summary>
    private IDictionary<string, Action<TestCommonApplication>> StartupKeys =
        new ConcurrentDictionary<string, Action<TestCommonApplication>>();

    /// <summary>
    /// Описание ключей (по идеи используется как минимум в справке)
    /// </summary>
    private IDictionary<string, string> StartupDescriptions =
        new Dictionary<string, string>()
        {
                { "mvc",        "mvc" },
                { "blazor",     "web assembly"},
                { "concole",    "консоль"},
                { "webapi",     "веб-хост"},
                { "win",        "настольное приложение"},
                { "background", "фоновый режим"}
        };
 

    public void AddStartup(
        Action<IStartup,IConfiguration, IServiceCollection> configureServiceProvider, 
        Action<IStartup,IConfiguration,IApplicationBuilder, IWebHostEnvironment> configureMiddleware)
    {
    }

    

    public TestCommonApplication(): base(null)
    {
        Init();
    }

    private void Init()
    {


       
        Push(new DataUnit(this));

        /*Push(new TestTypeScriptSeriallizer(this));
        Push(new DataSeriallizer2Test(this));
        Push(new CrudTest(this));

        Push(new AttributeInputUnit(this));
        Push(new AttributeValidationTests(this));
        Push(new ExtensionUtilsUnit(this));
        Push(new CommonUnit(this));

        Push(new AttributesUnit(this));
        Push(new DataUnit(this));
        Push(unit: new ExtensionUtilsUnit(this)); */
  //      Push(new AuthorizationServicesTest(this));
    //    Push(new AuthorizationUsersTest(this));
    //    Push(new AuthorizationUnit(this));
        Push(new AuthorizationUnit(this));
    }

    public TestCommonApplication(bool v):base()
    {
        Init();
    }

 

  
}