using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// ЗАгружает веб-модуль с проксированием на сервис времени разработки
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public abstract class SPAModule: ViewModule
{
    protected SPAModuleOptions _options;


    public override void ApplyConfiguration(IConfiguration Configuration ) 
    {
        base.ApplyConfiguration(Configuration);
        CurrentType = typeof(SPAModule);


        _options = new SPAModuleOptions();
        Configuration.GetReloadToken().RegisterChangeCallback(
            (changed)=> {
                Console.WriteLine("Конфигурация приложения изменилась "+changed);
            }, this
        );
        //_options.EnsureIsCorrect();
    }


    protected  string GetStaticFileOptions() => "/wwwroot";
    protected  override abstract void ConfigureDispatcher(HttpConnectionDispatcherOptions dispatcher);
    protected  override abstract void OnConfigureEndpoint(IEndpointRouteBuilder endpoints);


    public override void OnConfigureServices(IServiceCollection services)
    {  
        this.Info("OnConfigureServices()");
        services.AddControllersWithViews().AddControllersAsServices()
            .AddViewComponentsAsServices();
        services.AddSpaStaticFiles(configuration =>
        {
            configuration.RootPath =
                _options==null? "ClientApp/distr":_options.StaticFilesPath;
        });      
    }
    

    public override void Configure(IApplicationBuilder app)
    {
        app.UseExceptionHandler((ex) => { 

        });
        app.UseHttpsRedirection();
        app.UseStaticFiles(GetStaticFileOptions());
        app.UseSpaStaticFiles();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {                        
            endpoints.MapRazorPages();            
            endpoints.MapControllers();
            OnConfigureEndpoint(endpoints);
        });
        app.UseSpa(spa =>
        {
            //spa.Options.SourcePath = _options.SourceFilesPath;
            //spa.UseAngularCliServer(npmScript: "start");
            spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
        });
    }



}
