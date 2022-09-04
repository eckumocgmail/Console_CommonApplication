using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class TransportModule: Module
{
    public TransportModule()
    {

    }

    public ISignalRServerBuilder builder { get; set; }
 

    public override void OnConfigureServices(IServiceCollection services)
    {
        this.builder = services.AddSignalR(ConfigureSignalR);
    }



    public override void OnConfigureMiddleware(IApplicationBuilder app)
    {
        this.Info("OnConfigureMiddleware()");
    }


    /// <summary>
    /// Метод конфигурации служб SignalR
    /// </summary>
    /// <param name="options">свойства конфигурации</param>
    private void ConfigureSignalR(HubOptions options)
    {
        Api.Utils.Info("Конфигурации служб SignalR:");
        foreach (string protocol in options.SupportedProtocols)
        {
            Api.Utils.Info($"\t доступен протокол: {protocol}");
        }
    }
}
 