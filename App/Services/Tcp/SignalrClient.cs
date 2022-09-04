using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http.Connections.Client;
using Microsoft.AspNetCore.SignalR.Client;
//using Microsoft.AspNetCore.Http.Connections.Client;
//using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;


[Icon("")]
[Description("Контроллер предназначен для .")]
public interface IMessageHandler
{
    public Task<string> OnMessage(string message);

}

[Icon("")]
[Description("Контроллер предназначен для .")]
public interface IMessageHandlerService
{

    /// <summary>
    /// При
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public RequestMessage GetRequest(string message);
}

[Icon("")]
[Description("Контроллер предназначен для .")]
public interface IMessageClient
{
    Task Request(DataRequestMessage message);
}



[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class AppRootTransportSignalrClient : AsyncContext
{

    protected  HubConnection Connection;


    //public event Func<string, Task> Connected;
    //public event Func<string, Task> Terminated;

    /// <summary>
    /// Корневой сертификат
    /// </summary>
    protected string _Url;
    protected string Token;
    protected bool _Logging = true;
    protected byte[] PrivateKey;
    protected byte[] PublicKey;

    

    public HashSet<string> Public { get; set; } = new HashSet<string>();

    /*public AppRootTransportSignalrClient( byte[] protected Key, byte[] publicKey )
    {
        this.protected Key = protected Key;
        this.publicKey = publicKey;
        
    }*/

    public virtual async Task Connect( string url)
    {
        if (_Logging)
            this.LogInformation("Connecting to URL: "+_Url);
        Connection =
            new HubConnectionBuilder()
            .WithUrl(_Url = url, ConfigureHttpConnection)
            .Build();
        await Connection.StartAsync().ContinueWith((result)=> {

           
            return Task.Run(()=> { 
                Connection.On<string>("Response", OnResponse);
        
                var ctrl = this;
                foreach(string action in Public)
                {
                    var method = GetType().GetMethod(action);
                    Connection.On<object>(action, (args)=> {
                        method.Invoke(ctrl, new object[] { args.ToString() });
                    });
                }
                Connection.Closed += async (Exception exception) =>
                {
                    this.LogInformation(exception);
                    await Task.Delay(new Random().Next(0, 5) * 1000);
                    await Connection.StartAsync();
                };
            });
        });
        
        
        if (_Logging)
            this.LogInformation("Connected to URL: " + _Url);
    }


     



    public virtual void ConfigureHttpConnection(HttpConnectionOptions options)
    {
        this.Info($"ConfigureHttpConnection()");
        options.SkipNegotiation = true;
        options.Transports = HttpTransportType.WebSockets;
    }


    protected  virtual void OnResponse(string ResponseText)
    {
        try
        {
            if (_Logging)
                this.LogInformation("Handling Response: \n" + ResponseText);
            DataResponseMessage ResponseMessage = ResponseText.FromJson<DataResponseMessage>();
            var Todo = Take(ResponseMessage.SerialKey);
            if (ResponseMessage.ActionStatus == "Success")
            {
                if (_Logging)
                    this.LogInformation("Handled Response: \n" + ResponseText);
                if(Todo!=null)
                    Todo(ResponseMessage.MessageObject);
            }
            else
            {
                this.LogInformation("Операция не выполнена: " + ResponseMessage.SerialKey);
            }
        } 
        catch (Exception exception)
        {
            this.Error(exception);
        }
    }



    public async Task Request(Action<object> Handle, string Action, Dictionary<string, object> Message = null)    
        => await Request(Action,Message,Handle); 
    

    public virtual async Task Request(string Action, Dictionary<string,object> Message, Action<object> Handle)
    {

      
        if(_Logging)
            this.LogInformation("Requesting: \n"+ Message.ToJson());

        if (Connection == null)        
            await Connect(this._Url);
        if(Message == null)        
            Message = new Dictionary<string, object>();
        
        string SerialKey = Put(Handle);
        var RequestMessage = new DataRequestMessage() {

            AccessToken = Token,
            SerialKey = SerialKey,
            ParametersMap = Message,            
            ActionName = Action,            
        };
        string RequestText = RequestMessage.ToJson();
        if(_Logging)
            this.Info(RequestText);
        if (Connection != null)
        {
            await Connection.InvokeAsync("Request", RequestText);
            if (_Logging)
                this.LogInformation("Requested: \n" + RequestText);

        }
    }


    public virtual async Task InvokeAsync(string action, params object[] args)
    {
        this.LogInformation($"InvokeAsync({action}, ... )");
        if(Connection == null || Connection.State != HubConnectionState.Connected)
        {
            throw new Exception("Is not connected now");
        }
        else
        {
            await Connection.InvokeAsync(action, args);
        }
        
    }

    public Task Request(DataRequestMessage message)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}
