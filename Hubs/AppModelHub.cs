using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;


 

public class AppModelHub : Hub<CommonApplication>
{
    public AppModelHub( )
    {
    }
    public override Task OnConnectedAsync()
    {
        this.LogInformation($"OnConnectedAsync()");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {

        this.LogInformation($"OnDisconnectedAsync() => {exception.Message}\n{exception.StackTrace.ToString()}");
        return base.OnDisconnectedAsync(exception);
    }
}
