using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class HttpCommonModule: Module
{
    public HttpCommonModule()
    {
    }

    public override void OnConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped(typeof(HttpContext), sp=>sp.GetService<IHttpContextAccessor>().HttpContext);
        services.AddScoped(typeof(HttpRequest), sp=>sp.GetService<HttpContext>().Request);
        services.AddScoped(typeof(ConnectionInfo), sp=>sp.GetService<HttpContext>().Connection);
        services.AddTransient<HttpCookieManager>();
    }

    public override void OnConfigureMiddleware(IApplicationBuilder app)
    {
 
    }

        
}
 