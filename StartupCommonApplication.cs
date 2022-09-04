using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AngularApplication
{


    public class StartupCommonApplication
    {


        public IConfiguration Configuration { get; }


        public StartupCommonApplication(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFileDatabase<AnaliticsDataModel>();
            services.AddAuthorization();
            services.AddAuthentication(OnConfigureAuthentication);
            services.AddRazorPages(OnConfigureRazorPages).AddRazorRuntimeCompilation();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        private void OnConfigureAuthentication(AuthenticationOptions authenticationOptions)
        {
        }

        private void OnConfigureRazorPages(RazorPagesOptions razorPagesOptions)
        {
            


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication().UseFileServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(http => {

                string uri = http.Request.Path.ToString();
                this.Info( uri );
                switch (uri.ToLower())
                {

                    case "/notfound":
                        break;
                    default:
                        http.Response.Redirect("/notfound");
                        break;
                }
                return Task.CompletedTask;
            });
        }
    }
}
