using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



/// <summary>
/// Сервер приложений.
///     Просматривает локальную файловую систему, либо получает мета-информацию 
/// приложений. Выполняет функции управления  и контроля связывания процессов с локальной и
/// сетевой средой.
/// </summary>
public class AppServer: CancellationTokenSource, IServer, IDisposable
{
    private CancellationTokenSource Cts;
    private ConcurrentQueue<RequestMessage> Input;
    
    private FormOptions form = new FormOptions();
    public IFeatureCollection Features { get; set; } = new AppServerFeatures();
    public ConcurrentDictionary<Type, ConcurrentBag<object>> Apps { get; private set; } = new ConcurrentDictionary<Type, ConcurrentBag<object>>();

    private ConcurrentDictionary<int, HttpClientApp> HttpListeners = new ConcurrentDictionary<int, HttpClientApp>();
   

    public AppServer()
    {
    
        //var factory = new DefaultHttpContextFactory(AppScopeProvider.GetServiceProvider());
        //this.Input = new ConcurrentQueue<RequestMessage>();
        //this.Runtime = Task.Run(OnActivate, this.Token);
    }

    private IFeatureCollection GetAppServerFeatures()
        => new AppServerFeatures();
    

    public async Task<IDictionary<string, Task>> StartAsync(string[] apps)
    {
        IDictionary<string, Task> tasks =  new ConcurrentDictionary<string, Task>();
      
        foreach (var app in apps)
        {            
            int port = GetFreePort();         
            HttpListeners[port] = new HttpClientApp(this, app, port);
            this.Info(app, port);
            tasks[app]=(StartAsync<ClientAppContext>(HttpListeners[port], Token));
        }
      
        await Task.CompletedTask;
        return tasks;
    }

 
    private int GetFreePort()
    {
        for (int i = 13000; i < 16000; i++)
            if (NetworkInfoProvider.IsFreePort(i) &&  HttpListeners.Keys.Contains(i)==false)
                return i;
        throw new Exception("Нет свободных портов");
    }

    private Task StartClientAppAsync(string app, int port)
    {
        string command =
            $"/C \"{app.Substring(0, 2)} && cd {app.Substring(0, app.LastIndexOf("\\"))} && ng serve --port {port} \"";
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
    private void OnActivate()
    {
        this.Info("Activated()");
        while(this.Token.IsCancellationRequested == false)
        {
            Input.TryDequeue(out var input);
            if(input != null)
            {
                OnMessage(input);
            }
            Task.Delay(100);
        }
    }

    private void OnMessage(RequestMessage input)
    {
    }
   
    public Task StartAsync<TContext>(IHttpApplication<TContext> application, CancellationToken cancellationToken)
    {
        
        return Task.Run(() => {
            if (Apps.ContainsKey(typeof(TContext)) == false)
            {
                Apps[typeof(TContext)] = new ConcurrentBag<object>();

            }
            Apps[typeof(TContext)].Add(application.CreateContext(Features));
        },cancellationToken);
        
        
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
            //TODO

    }




}