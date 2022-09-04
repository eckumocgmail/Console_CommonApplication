
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class MVCViewModule : ViewModule
{
    public  MVCViewModule():base()
    {
        CurrentType = typeof(MVCViewModule);
    }

    public override void ConfigurateApiControllers(MvcOptions options)
    {

    }

    public override void ConfigurateJson(JsonOptions json)
    {
        
    }

    public override void ConfigureApi(ApiBehaviorOptions behaviour)
    {
        
    }

   

    public override void ConfigureEndpoint(IEndpointRouteBuilder endpoints)
    {
        
        endpoints.MapControllerRoute(name: "api", pattern: "/api/{controller}");
        endpoints.MapDefaultControllerRoute();
        endpoints.MapRazorPages();
        endpoints.MapFallbackToPage("/Index");
    }

    public override void OnConfigureMiddleware(IApplicationBuilder app)
    {
        app.UseExceptionHandler("/ErrorPage");        
        app.UseHttpsRedirection();
        app.UseStaticFiles();        
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            OnConfigureEndpoint(endpoints);            
        });
    }

    public override void OnConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews(); ;
        services.AddSignalR();
        services
            .AddRazorPages()
            .AddDataAnnotationsLocalization(ConfigureDataAnnotations)
            .AddJsonOptions(ConfigurateJson)
            .AddFormatterMappings(ConfigureFormatterMappings)
            .AddControllersAsServices()
            .AddViewComponentsAsServices()
            .ConfigureApiBehaviorOptions(ConfigureApi);
        services.Configure<MvcViewOptions>(ConfigureViewOptions);
    }

    private void ConfigureViewOptions(MvcViewOptions viewOptions)
    {      
        



        //viewOptions.ViewEngines.Clear();
        //viewOptions.ViewEngines.Insert(0, new CustomViewEngine());
    }

    private void ConfigureFormatterMappings(FormatterMappings mapping)
    {
        
    }

    private void ConfigureDataAnnotations(MvcDataAnnotationsLocalizationOptions obj)
    {
        this.Info(Formating.ToJsonOnScreen(obj));
    }

    protected  override void ConfigureDispatcher(HttpConnectionDispatcherOptions dispatcher)
    {
    }

    protected  override void OnConfigureEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapDefaultControllerRoute();
        endpoints.MapFallbackToPage("/Index");
    }
}