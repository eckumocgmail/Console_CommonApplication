using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.Features;

using System;
using System.Threading.Tasks;

 
public class HttpClientApp: NgApp, IHttpApplication<ClientAppContext>
{
    public string ContentsRoot { get; }

    private readonly AppServer server;

    public int Port { get; }

    public HttpClientApp(AppServer server, string path, int port)  
    {
        this.ContentsRoot = path;
        this.server = server;
        this.Port = port;
    } 
    public ClientAppContext CreateContext(IFeatureCollection features)
    {
        var result = new ClientAppContext(server, this);
        foreach(var feature in features)
        {
            Console.WriteLine($"{feature.Key}={feature.Value}");
            result.Apply(feature.Key, feature.Value.ToString());
        }
        return result; ;
    }

    public Task ProcessRequestAsync(ClientAppContext context)
    {
        context.OnHttpRequest( this );
        return Task.CompletedTask;
    }

    public void DisposeContext(ClientAppContext context, Exception exception)
    {
        context.OnError(exception);
    }
}
 