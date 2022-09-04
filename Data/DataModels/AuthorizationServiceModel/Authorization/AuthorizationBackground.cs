using static Api.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
 
using System.Linq;

/// <summary>
/// Поток управления жизненым циклом обьектов сеанса.
/// </summary>
public class AuthorizationBackground : BackgroundService, IDisposable, DoCheck, APIActiveObject
{   


    private readonly AuthorizationOptions _options;
    private readonly APIUsers _users;
    private readonly APIServices _services;
    private readonly IServiceProvider _provider;
    private readonly AuthorizationClient _client;
    private readonly Service _service;



    /// <param name="options"> Параметры </param>
    /// <param name="users"> Коллекция авторизованных пользователей </param>
    /// <param name="services"> Коллекция авторизованных служб </param>
    public AuthorizationBackground(
            AuthorizationClient client,
            IServiceProvider provider,
            Service service,
            AuthorizationOptions options,
            APIServices services,
            APIUsers users )
    {
        _options = options;
        _users = users;
        _services = services;
        _provider = provider;
        _client = client;
        _service = service;

        if(this._options.LogginAuth)
            this.Info("Created");
        services.Put(service);


    }


    /// <summary>
    /// Выполнение фоновой задачи до тех пор пока не получен запрос на прерывание
    /// </summary>
    /// <param name="stoppingToken"> токен управления потоком </param>
    /// <returns></returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        string hubUrl = $"{_options.GetApplicationUrls().First()}/hubs/service-agents";
        if (this._options.LogginAuth)
            this.Info(hubUrl);
        /*await _client.Connect(hubUrl).ContinueWith(async (res) =>
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Thread.Sleep(_options.CheckTimeout);
                await _client.Request((response) =>
                {
                    if (this._options.LogginAuth)
                        this.Info($"Checked: {_service.ToJsonOnScreen()}");
                }, "DoCheck");
                await this.DoCheck(_options.SessionTimeout);
            }
            await Task.CompletedTask;
        });*/
        while (!stoppingToken.IsCancellationRequested)
        {
            Thread.Sleep(_options.CheckTimeout);           
            await this.DoCheck(_options.SessionTimeout);
        }
        await Task.CompletedTask;

    }

    /// <summary>
    /// Уничтожение сервиса
    /// </summary>
    public override void Dispose()
    {
        if (this._options.LogginAuth)
            this.Info("Dispose()");
        base.Dispose();
    }


    public async Task DoCheck(long timeout)
    {
        try
        {
            Clear();
             
            this.Info("DoCheck()");
            await _users.DoCheck(timeout);
            await _services.DoCheck(timeout);
        }catch (Exception ex)
        {

            this.Error("Ошибка при выполнении периодических задач: "+ex.Message);
        }
    }

    


    public RequestMessage ActionEvent(ResponseMessage message)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public Task<RequestMessage> ActionEventAsync(ResponseMessage message)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}
 