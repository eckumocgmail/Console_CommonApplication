using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class UserAgentsHub : Hub, IUserAgent
{
    public IUserAgent GetApiUserAgent() => null;// Clients.Client(this.Context.ConnectionId);


    public UserAgentsHub()
    {
        this.Info(GetType().GetTypeName());
 
    }



     /// <summary>
    /// Выполнение запроса
    /// </summary>
    /// <param name="RequestText"></param>
    /// <returns></returns>
    public string Request(string RequestText)
    {
        Console.WriteLine("Requesting: \n" + RequestText);
        DataRequestMessage RequestMessage = Deserrialize(RequestText);

        DataResponseMessage ResponseMessage = ExecuteRequest(RequestMessage);
        string ResponseText = JObject.FromObject(ResponseMessage).ToString();
        
        return RequestText;
    }

    private object Invoke(string actionName, Dictionary<string, object> messageObject)
    {
        try
        {            
            object result = GetType().GetMethod(actionName)
                .Invoke(this, messageObject.Values.ToArray());
            return new
            {
                ActionName = actionName,
                Parameters = messageObject,
                Result = result
            };
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }




    private static DataRequestMessage Deserrialize(string json)
    {
        try
        {
            return JsonConvert.DeserializeObject<DataRequestMessage>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Не удалось сериализовать сообщение с параметрами запроса: " + ex.Message);
            throw;
        }
    }

    public async Task DoCheck(long timeout)
    {
        Console.WriteLine(timeout);
        await Task.CompletedTask;
    }

    private DataResponseMessage ExecuteRequest(DataRequestMessage RequestMessage)
    {
        object MessageObject = Invoke(RequestMessage.ActionName, RequestMessage.ParametersMap);
        return new DataResponseMessage()
        {
            ActionStatus = "Success",
            SerialKey = RequestMessage.SerialKey,
            RequestMessage = RequestMessage,
            MessageObject = MessageObject
        };
    }

    public bool InfoDialog(string Title, string Text, string Button)
    {
        return GetApiUserAgent().InfoDialog(Title, Text, Button);
    }

    public void ShowHelp(string Text)
    {
        GetApiUserAgent().ShowHelp(Text);
    }

    public bool RemoteDialog(string Title, string Url)
    {
        return GetApiUserAgent().RemoteDialog(Title, Url);
    }

    public bool ConfirmDialog(string Title, string Text)
    {
        return GetApiUserAgent().ConfirmDialog(Title, Text);
    }

    public bool CreateEntityDialog(string Title, string Entity)
    {
        return GetApiUserAgent().CreateEntityDialog(Title, Entity);
    }

    public object InputDialog(string Title, object Properties)
    {
        return GetApiUserAgent().InputDialog(Title, Properties);
    }

    public string Eval(string js)
    {
        return GetApiUserAgent().Eval(js);
    }

    public string HandleEvalResult(Func<object, object> handle, string js)
    {
        return GetApiUserAgent().HandleEvalResult(handle, js);
    }

    public string Callback(string action, params string[] args)
    {
        return GetApiUserAgent().Callback(action, args);
    }

    public bool AddEventListener(string id, string type, string js)
    {
        return GetApiUserAgent().AddEventListener(id, type, js);
    }

    public bool DispatchEvent(string id, string type, object message)
    {
        return GetApiUserAgent().DispatchEvent(id, type, message);
    }

    public override Task OnConnectedAsync()
    {
        this.Info("Соединение установлено ... ");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        this.Info("Соединение разорвано ... ");
        return base.OnDisconnectedAsync(exception);
    }
}