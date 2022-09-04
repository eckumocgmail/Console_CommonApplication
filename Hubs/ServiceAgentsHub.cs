using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 
public class ServiceAgentsHub  : Hub,DoCheck
{
    [Inject()]
    APIAuthorization authorization { get; set; }

    public ServiceAgentsHub(IServiceProvider provider)
    {
        this.Init(provider);
    }
    

    public string Login(string key)
    {
        var api = this.authorization.Signin(key);
        if (api != null)
        {
            return api.SecretKey;
        }
        else
        {
            return "";
        }
    }



    /// <summary>
    /// Выполнение запроса
    /// </summary>
    public string Request(string RequestText)
    {
        this.Info("Requesting: \n" + RequestText);
        DataRequestMessage RequestMessage = Deserrialize(RequestText);

        DataResponseMessage ResponseMessage = ExecuteRequest(RequestMessage);
        string ResponseText = JObject.FromObject(ResponseMessage).ToString();
        Clients.Caller.SendAsync("Response", ResponseText);
        return RequestText;
    }

    public object GetActionResult(string actionName, Dictionary<string, object> messageObject)
    {
        try
        {
            this.Info($"{actionName}\n(\n{(messageObject==null?"":messageObject.ToJsonOnScreen().ReplaceAll("\n","\n\t"))}\n)");

            if (messageObject == null)
                messageObject = new Dictionary<string, object>();
            var method = GetType().GetMethod(actionName);
            if(method == null)
            {
                return new
                {
                    
                };
            }
            else
            {
                object result = method.Invoke(this, messageObject.Values.ToArray());
                return new
                {
                    ActionName = actionName,
                    Parameters = messageObject,
                    Result = result
                };
            }
            
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }




    private DataRequestMessage Deserrialize(string json)
    {
        try
        {
            this.Info(json);

            return JsonConvert.DeserializeObject<DataRequestMessage>(json);
        }
        catch (Exception ex)
        {
            this.Error("Не удалось сериализовать сообщение с параметрами запроса: " + ex.Message);
            throw;
        }
    }

    public async Task DoCheck(long timeout)
    {
        Console.WriteLine(timeout);
        this.Log();
        if (this.authorization.IsSignin())
        {
            this.Info("Аутентификация выполнена");
        }
        else
        {
            this.Info("Аутентификация не выполнена");
        }
        //Clients.Caller.Invoke();
        await Task.CompletedTask;
    }
    


    /// <summary>
    /// 
    /// </summary>
    /// <param name="RequestMessage"></param>
    /// <returns></returns>
    public DataResponseMessage ExecuteRequest(DataRequestMessage RequestMessage)
    {
        this.Info(RequestMessage.ToJsonOnScreen());

        object MessageObject = GetActionResult(RequestMessage.ActionName, RequestMessage.ParametersMap);
        return new DataResponseMessage()
        {
            ActionStatus = "Success",
            SerialKey = RequestMessage.SerialKey,
            RequestMessage = RequestMessage,
            MessageObject = MessageObject
        };
    }
}