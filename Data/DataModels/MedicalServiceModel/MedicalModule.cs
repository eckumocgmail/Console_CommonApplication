using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace MvcDeliveryAuth.Domains.Medical
{
    public class MedicalModule: IServiceModule
    {
        private ILogger<MedicalModule> Logger = OverrideLogging.GetLogger<MedicalModule>();
        public void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            Logger.LogInformation("ConfigureServices(...)");
            services.AddDbContext<MedicalDbContext>(options=>options.UseInMemoryDatabase(nameof(MedicalDbContext)));
            services.AddSingleton<MedicalDbInitializer>();
        }
    }
}
