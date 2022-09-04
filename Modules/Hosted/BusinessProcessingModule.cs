using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class BusinessProcessingModule<THostedService>: Module
        where THostedService : IHostedService
{
    public IHostBuilder ConfigureServices(IHostBuilder builder)

        => builder.ConfigureServices((HostBuilderContext context, IServiceCollection services) =>
        {
            this.Configuration = context.Configuration;
            ConfigureServices(services);
        });

  

  



    /// <summary>
    /// 
    /// </summary>
    public class BackgroundWorker: IHostedService
    {
        private readonly ILogger<BackgroundWorker > logger;
        private readonly THostedService hosted;

        public BackgroundWorker(
            ILogger<BackgroundWorker > logger,
            THostedService hosted)
        {
            this.logger = logger;
            this.hosted = hosted;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"StartAsync({cancellationToken.ToString()}) begin");
                await hosted.StartAsync(cancellationToken);
                logger.LogInformation($"StartAsync({cancellationToken.ToString()}) completed");

            }
            catch (Exception ex)
            {
                logger.LogInformation($"StartAsync({cancellationToken.ToString()}) failed");
                logger.LogInformation($"{ex.ToString()}");
            }

        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"StopAsync({cancellationToken.ToString()}) begin");
                await hosted.StopAsync(cancellationToken);
                logger.LogInformation($"StopAsync({cancellationToken.ToString()}) completed");

            }
            catch (Exception ex)
            {
                logger.LogInformation($"StopAsync({cancellationToken.ToString()}) failed");
                logger.LogInformation($"{ex.ToString()}");
            }
        }
    }

    public override void OnConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(typeof(THostedService));
        services.AddHostedService<BackgroundWorker>();
    }

    public override void OnConfigureMiddleware(IApplicationBuilder app)
    {
        
    }
}