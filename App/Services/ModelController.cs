using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


public class ModelController: Controller
{

        
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="hubContext"></param>
    /// <param name="groupName"></param>
    /// <param name="requestMessage"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task Publish( [FromServices] IHubContext<UserAgentsHub> hubContext, string groupName, DataRequestMessage requestMessage, CancellationToken cancellationToken)
    {
        this.Info("Publish()");

        IClientProxy proxy = hubContext.Clients.Group(groupName);
        await proxy.SendCoreAsync(requestMessage.ActionName, requestMessage.ParametersMap.Values.ToArray(), cancellationToken);
        await Task.CompletedTask;
    }
}
