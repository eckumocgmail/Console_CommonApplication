using Microsoft.AspNetCore.SignalR;

public class AgentsController
{

    public void StartModel() { }

    public void GetStateChart() { }

    public void Ping([Microsoft.AspNetCore.Mvc.FromServices] IHubContext<UserAgentsHub> useragents)
    {
        useragents.Clients.All.Invoke("Ping");
    }


}
