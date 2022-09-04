
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http.Connections.Client;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Net.Http;

public class AsyncContextTest : TestingElement
{
    public override System.Collections.Generic.List<string> OnTest()
    {
        var context = new AsyncContext();
        string key = context.Put((message) => {
        });
        key.WriteToConsole();
        Messages.Add("Реализована функция выдачи ключей доступа к асинхронным операциям");
        return Messages;

    }
}
/// <summary>
/// Область регистрации функций обработки ответных сообщений
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class AsyncContext
{
    private HttpClient http = new HttpClient();

    /// <summary>
    /// Динамическая область памяти для регистрации ссылок на функции обрабатывающии ответное сообщение
    /// </summary>
    private ConcurrentDictionary<string, Action<object>> Pool = new ConcurrentDictionary<string, Action<object>>();

    /// <summary>
    /// Длина ключа доступа к функции обрабатывающей ответное сообщение
    /// </summary>
    private int SerialKeyLength = 32;
    private Random Random = new Random();



    /// <summary>
    /// Регистрация функции обработчика
    /// </summary>
    /// <param name="Handle">ссылка на функцию</param>
    /// <returns>ключ доступа</returns>
    public string Put(Action<object> Handle)
    {
        lock (this.Pool)
        {
            string SerialKey = GenerateSerialKey();
            Pool[SerialKey] = Handle;
            return SerialKey;
        }
    }


    /// <summary>
    /// Извлечение функции обработчика
    /// </summary>
    /// <param name="SerialKey"> ключ доступа</param>
    /// <returns>функция обработчика</returns>
    public Action<object> Take(string SerialKey)
    {
        lock (this.Pool)
        {
            Action<object> Handle = null;
            Pool.TryRemove(SerialKey, out Handle);
            return Handle;
        }
    }


    /// <summary>
    /// Генерация уникального ключа доступа
    /// </summary>
    /// <returns></returns>
    private string GenerateSerialKey()
    {
        string key;
        do
        {
            key = "";
            for (int i = 0; i < SerialKeyLength; i++)
            {
                key += (Math.Floor(Random.NextDouble() * 10)).ToString();
            }
        } while (Pool.ContainsKey(key));
        return key;
    }
}
public class HubClientTest
{
}

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class MessageClient : AsyncContext, IHostedService
{    


    private string                  Url;
    private IHubConnectionBuilder   Builder;
    private HubConnection           Connection;


    public MessageClient(string Url="https://localhost:5001/DevHub")
    {
        this.Url = Url;
        Builder = new HubConnectionBuilder().WithUrl(this.Url, Configure);
    }

    public void Configure(HttpConnectionOptions options)
    {        
        options.SkipNegotiation = true;
        options.Transports = HttpTransportType.WebSockets;
    }


    [Label("")]
    public async Task Connect()
    {
        Console.WriteLine("Connecting to URL: "+Url);
        Connection = Builder.Build();

        Connection.On<string>("Response", OnResponse);
        Connection.Closed += async (Exception exception) =>
        {
            Console.WriteLine(exception);
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await Connection.StartAsync();
        };
        await Connection.StartAsync();        
        Console.WriteLine("Connected to URL: " + Url);
    }


    private void OnResponse(string ResponseText)
    {
        Console.WriteLine("Handling Response: \n" + ResponseText);
        DataResponseMessage ResponseMessage = JsonConvert.DeserializeObject<DataResponseMessage>(ResponseText);
        var Todo = Take(ResponseMessage.SerialKey);
        if (ResponseMessage.ActionStatus == "Success")
        {
            Console.WriteLine("Handled Response: \n" + ResponseText);
            Todo(ResponseMessage.MessageObject);
        }
        else
        {
            Console.WriteLine("Операция не выполнена: "+ ResponseMessage.SerialKey);
        }        
    }


    public async Task Request(object Message, Action<object> Handle)
    {
        Console.WriteLine("Requesting: \n"+ JObject.FromObject(Message).ToString());
        string SerialKey = Put(Handle);
        var RequestMessage = new DataRequestMessage() {
            SerialKey = SerialKey,
            //MessageObject = Message,

            //TODO:
            ActionName = "",

            //TODO:
            AccessToken = ""
        };
        string RequestText = JObject.FromObject(RequestMessage).ToString();        
        await Connection.InvokeAsync("Request", RequestText);
        Console.WriteLine("Requested: \n" + RequestText);
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}
