using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class SignalrServer: Hub   
{

 
    protected  IHttpContextAccessor _accessor;


    public SignalrServer(
            IHttpContextAccessor accessor )
    {
         
        _accessor = accessor;
        this.LogInformation("Created");
    }


    /// <summary>
    /// 
    /// </summary>
    public override Task OnConnectedAsync()
    {
        this.LogInformation("OnConnectedAsync()");
        return Task.Run(() => {
            _accessor.HttpContext.User.Identities.ToList().ForEach(i => {
                this.LogInformation(JsonConvert.SerializeObject(i, new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                }));
            });

        });
    }


    /// <summary>
    /// 
    /// </summary>
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await Task.Run(() => {
            this.LogInformation("OnDisconnectedAsync");
            
        });
    }



    /// <summary>
    /// 
    /// </summary>
    public Task OnActivated(MyApplicationModel app)
    {
        this.LogInformation("OnActivated");
        return Task.Run(() => {

            foreach (var pair in app.controllers)
            {
                this.LogInformation($"OnActivated() => ${pair.Value.Name + "/" + pair.Value.Path}");
                 
            }

        });
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
        Clients.Caller.SendAsync("Response", ResponseText);
        return RequestText;
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
        }catch (Exception ex)
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
}
 