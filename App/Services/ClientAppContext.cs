using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading.Tasks;

public class ClientAppContext
{
    private HttpClientApp httpClientApp;
    private  AppServer server;
    //private TcpListener tcpServer;

    public ClientAppContext(AppServer server, HttpClientApp httpClientApp)
    {
        this.httpClientApp = httpClientApp;
        this.server = server;

        this.Start($"cd {httpClientApp.ContentsRoot} && ng serve --port {httpClientApp.Port} --open");

        /*this.tcpServer = new TcpListener();
        this.tcpServer.Launch((text) => {
            //TODO:
            this.Info(text);
        });*/
    }

    /// <summary>
    /// Новый процесс
    /// </summary>
    /// <param name="url"></param>
    /// <exception cref="NotImplementedException"></exception>
    private Task Start(string url)
    {
        string command =
                   $"/C \"{httpClientApp.ContentsRoot.Substring(0, 2)} && cd {httpClientApp.ContentsRoot.Substring(0, httpClientApp.ContentsRoot.LastIndexOf("\\"))} && ng serve --port {httpClientApp.Port} \"";
        Console.WriteLine(command);
        ProcessStartInfo info = new ProcessStartInfo("CMD.exe", command);

        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;
        System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
        System.IO.StreamReader reader = process.StandardOutput;
        return Task.Run(() =>
        {
            while (process.HasExited == false)
            {
                Console.WriteLine(reader.ReadLine());
            }

        });
    }

    public void Apply(Type key, string url)
    {
        //TODO:  
    }

    public void OnHttpRequest(HttpClientApp networkApplication)
    {
        this.Info("OnHttpRequest");
    }

    public void OnError(Exception exception)
    {
        this.Info("OnError => "+exception);
    }
}