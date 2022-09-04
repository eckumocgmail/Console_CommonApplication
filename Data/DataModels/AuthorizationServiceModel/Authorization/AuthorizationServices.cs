using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


public interface APIServices : APIActiveCollection<Service>, DoCheck
{

    /// <summary>
    /// Сведения о экземляре службы, к котороый выполняется запрос/
    /// т.е. Service==localhost
    /// </summary>    
    Service GetServiceLocator();

    /// <summary>
    /// Сведения о экземляре службы, к котороый выполняется запрос/
    /// т.е. Service==localhost
    /// </summary>    
    IEnumerable<Service> GetProviders();

    /// <summary>
    /// Описатели услуг
    /// </summary>    
    IDictionary<Service, MyApplicationModel> Discovery();


    /// <summary>
    /// На указанный сервис передаётся запрос с адресом 
    /// для получения обратного сообщения, который будет действителен в течении
    /// заданного диапазона
    /// </summary>
    /// <param name="service"></param>
    /// <param name="returlUrl"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    Task<object> Request(Service service, string returlUrl, long timeout);




    void Disconnected(string connectionId);
    void Connected(string connectionId);
}
public class AuthorizationServices: AuthorizationCollection<Service>, APIServices
{
    private readonly Service _service;

    public AuthorizationServices(
        Service service,
        AuthorizationOptions options) : base(options)
    {
        this._service = service;
    }

    public Service GetServiceLocator() => _service;

    public IEnumerable<Service> GetProviders()
    {
        var result = new List<Service>();
        foreach( string provider in _options.Providers)
        {
            result.Add(new Service() { 
                Name = provider
            });
        }
        return result;
    }

    public IDictionary<Service, MyApplicationModel> Discovery()
    {
        IDictionary<Service, MyApplicationModel> disc = new Dictionary<Service, MyApplicationModel>();  
        foreach( string provider in _options.Providers)
        {
            string url = $"https://{provider}/api";
            try
            {
                string json = url.Get();
                MyApplicationModel model = json.FromJson<MyApplicationModel>();
                disc[GetService(provider)] = model;
            }
            catch(Exception ex)
            {
                ex.ToString().WriteToConsole();
            }
        }
        return disc;
    }

    

    private Service GetService(string provider)
    {
        return new Service() { 
            Name=provider
        };
    }

    public async Task<object> Request(Service service, string returlUrl, long timeout)
    {
        this.Info($"Запрос: " + service.Name + " <= "+returlUrl);
        await Task.CompletedTask;
        return null;
    }

    public void Disconnected(string connectionId)
    {
        this.Info($"Отключено: " +connectionId);
    }

    public void Connected(string connectionId)
    {
        this.Info($"Подключено: " + connectionId);
    }
}




/// <summary>
/// Тестируем AuthorizationUsers 
/// </summary>
[Label("Тестирование " + nameof(AuthorizationServices))]
public class AuthorizationServicesTest : TestingElement
{
    public AuthorizationServicesTest()
    {
    }

    public AuthorizationServicesTest(TestingElement parent) : base(parent)
    {
    }



    public override List<string> OnTest()
    {
        try
        {
            var options = this.Get<AuthorizationOptions>();
            var users = this.Get<AuthorizationServices>();

            users.DoCheck(System.DateTimeOffset.Now.ToUnixTimeMilliseconds()).Wait();
            this.Messages.Add(this.GetSuccessMessage<AuthorizationUsers>());

            string key = users.Put(new Service());
            if (users.Take(key) == null)
                throw new Exception("Не удалось извлечь контекст веб-сервисов по ключу");
            this.Messages.Add("Контекст веб-сервисов при добавлении в коллекции генерирует уникальный ключ, " +
                "по которому в дальйшем предоставляется доступ к объекту. ");

            users.RemoveAll();
            if (users.Take(key) != null)
                throw new Exception("Контекст веб-сервисов не был отчищен");
            this.Messages.Add("Контекст веб-сервисов удаляет все ссылки при" +
                " выполнении метода RemoveAll. ");

            key = users.Put(new Service());
            Thread.Sleep((int)options.SessionTimeout+100);
            users.DoCheck(System.DateTimeOffset.Now.ToUnixTimeMilliseconds()).Wait();
            if (users.Take(key) != null)
                throw new Exception("Контекст веб-сервисов не был отчищен");
            this.Messages.Add("Контекст веб-сервисов удаляет устаревшие ссылки " +
                "при выполнении проверки DoCheck(). ");

            this.Messages.Add(this.GetSuccessMessage<AuthorizationServices>());

        }
        catch (Exception ex)
        {
            string message = GetFailedMessage();
            this.Error(message, ex);
            this.Messages.Add(message);
            throw new Exception(message, ex);
        }
        return Messages;
    }

}