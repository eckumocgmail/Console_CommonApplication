using AuthorizationMVC.Views.Login;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using static Api.Utils;


/// <summary>
/// Основной модуль приложения.
/// 
/// 1) ServiceController
/// -Запускает фоновый процесс, который управляет 
/// службами работающими в фоновом режиме.
/// 
/// 
/// -Запускает основные сервисы управления данными 
/// и сервисами диалога с пользователем.
/// </summary>
public class CommonApplication : RootModule
{

    /// <summary>
    /// Сервисы управления данными
    /// </summary>
    private IList<Module> DataModules = new List<Module>();

    /// <summary>
    /// Сервисы диалога с пользвателем
    /// </summary>
    private IList<ViewModule> ViewModules = new List<ViewModule>();

    /// <summary>
    /// URL-прокси сервера
    /// </summary>
    public static string ProxyUrl { get; set; }

    public CommonApplication() : base() { }





    


    /// <summary>
    /// Регистрация сервисов 
    /// </summary>    
    public override void ConfigureServices(IServiceCollection services)
    {
        Clear();
        services.AddDataModels(GetConfiguration());
        services.AddHttpContextAccessor();
        services.AddHttpClient();
        services.AddSignalR();
        services.AddRazorPages().AddRazorRuntimeCompilation();
        services.AddControllersWithViews().AddRazorRuntimeCompilation();
        services.AddTransient<HttpCookieManager>();
        services.AddScoped<ListService>();
        services.AddScoped<ListItemService>();        
        services.AddScoped<IUserNotificationsService, UserNotificationsService>();
        services.AddScoped<CssSerializer>();
        services.AddScoped<UserModelsService>();
        services.AddScoped<IComponentRegistry, ComponentRegistry>();        
        services.AddScoped<IAnaliticsServiceModel, AnaliticsServiceLocal>();
        services.AddScoped<UserGroupsService>();
        services.AddSingleton(typeof(AuthorizationDataModel),sp=>new AuthorizationDataModel());
         
 
        services.AddSingleton<ProcessManager>();
        services.AddSingleton<UserMessagesService>();
        services.AddSingleton<VideoResource>(); 
        services.AddSingleton<ReCaptchaService>();
        services.AddSingleton<ReCaptchaOptions>();
        services.AddSingleton<APIServices,AuthorizationServices>();
 
        services.AddScoped<INavigationService, NavigationService>();     
        services.AddScoped(typeof(Service), sp=>new Service() { 
            Url = "https://localhost:5001"
        });
        services.AddScoped<ReCaptchaService>();        
        services.AddScoped<APIAuthorization,AuthorizationService>();
        services.AddScoped<CatalogDataModel>();
        services.AddSingleton(typeof(EmailOptions), sp => {

            WriteLine("Считываем конфигурацию электронной почты");
            var options = Configuration.GetSection(typeof(EmailOptions).GetTypeName()).Get<EmailOptions>();
            if (options == null)
            {
                options = new EmailOptions();
                WriteLine($"\n\n" +
                    $"(!) Дополните appsettings.json параметром: \n");
                WriteLine($"\"EmailOptions\": " + new EmailOptions().ToJsonOnScreen());
            }
            return options;
        });
        services.AddSingleton<IEmailService, EmailService>();
        services.AddScoped<TokenManagement>();
        services.AddScoped<TableService>();
        services.AddSingleton<AuthorizationOptions>();
        services.AddSingleton<APIUsers, AuthorizationUsers>();
        services.AddSingleton<APIServices, AuthorizationServices>();
        services.AddSpaStaticFiles(configuration =>
        {
            configuration.RootPath = "ClientApp/distr";
        });
        var names = services
            .Select(s => s.ServiceType.GetNameOfType())
            .Where(name => GetExecutingAssembly().GetClassTypes().Select(t => t.GetTypeName())
            .Contains(name)).ToList();      
        services.AddSingleton(typeof(NameServiceProvider), sp => NameServiceProvider.Create(sp, names));
        this.Info(names.ToJsonOnScreen());
    }



    /// <summary>
    ///  Конфигурация конвеера
    /// </summary>
    public override void Configure(IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            this.Info(context.Request.Path);
            try
            {
                await next.Invoke();
            }catch(Exception ex)
            {
                await context.Response.WriteAsync(ex.Message);
                await context.Response.WriteAsync(ex.StackTrace);
            }
        });
        app.UseDeveloperExceptionPage();
        app.UseHttpsRedirection();
        app.UseStaticFiles();   
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapHub<ServiceAgentsHub>("/hubs/service-agents");
            endpoints.MapHub<UserAgentsHub>("/hubs/user-agents");
            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
        });        
        app.UseSpa(spa =>
        {
            this.Info(CommonApplication.ProxyUrl);
            spa.UseProxyToSpaDevelopmentServer(CommonApplication.ProxyUrl);
            //spa.UseDirectoryToSpaDevelopmentServer("ClientApp");
        });       
    }
}
public static class SpaExtensions
{
    public static void UseDirectoryToSpaDevelopmentServer(this ISpaBuilder spa, string directory)
    {
        spa.Options.SourcePath = directory;
        spa.UseAngularCliServer(npmScript: "start");
    }
}