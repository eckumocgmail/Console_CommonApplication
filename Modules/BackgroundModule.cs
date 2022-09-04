using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class BackgroundModule<BackgroundServiceType> : Module where BackgroundServiceType : IHostedService
{

    public override void OnConfigureServices(IServiceCollection services)
    {
    }

    public override void OnConfigureMiddleware(IApplicationBuilder app)
    {
    }
}
