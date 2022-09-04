
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public class ProcessController : Controller
{
    public bool Grid([FromServices] ProcessManager manager)
    {

        bool Completed = false;
        manager.Start("ng serve", @"D:\AngularProjects\Angular_Grid", (message) => {
            this.Info(message);
        });
        while (!Completed)
        {
            Thread.Sleep(100);
        }
            
        return true;
    }
}


/// <summary>
/// 
/// </summary>
public class ProcessManager : BackgroundService
{
    private ConcurrentQueue<RequestMessage> Commands = new ConcurrentQueue<RequestMessage>();
    private CancellationTokenSource cts = new CancellationTokenSource();

    public string Exec( string command, string wrk)
    {
        ProcessStartInfo info = new ProcessStartInfo("CMD.exe", $"/C {wrk.Substring(0, 2)} && cd \"{wrk}\" && " + command);
        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;

        Process process = System.Diagnostics.Process.Start(info);
        return process.StandardOutput.ReadToEnd();
    }
    public Task Start( string command, string wrk, Action<string> on )
    {

        return Task.Run(() => {

            ProcessStartInfo info = new ProcessStartInfo("CMD.exe", $"/C {wrk.Substring(0, 2)} && cd \"{wrk}\" && " + command);
            info.RedirectStandardError = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;

            Process process = System.Diagnostics.Process.Start(info);

            while (process.HasExited == false)
            {
                Thread.Sleep(100);


                string line = null;
                while ((line = process.StandardOutput.ReadLine()) != null)
                {
                    on(line);
                }
            }            
        }, cts.Token);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var context = new ActionInvokeContext();
        while (!stoppingToken.IsCancellationRequested)
        {
            Commands.TryDequeue(out var message);
            if(message == null)
            {
                try
                {
                    object result = this.Invoke(message.ActionName, message.GetArguments());
                }
                catch(Exception ex)
                {
                    this.Error(ex);
                }
            }
            Thread.Sleep(100);
        }
        await Task.CompletedTask;
    }
}
 