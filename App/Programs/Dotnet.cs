
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Нехватает tool-manifest, nunit-test
/// </summary>
public enum DotnetTemplates
{
    nunitTest,
    toolManifest,

    wpf,
    wpflib,
    wpfcustomcontrollib,
    wpfusercontrollib,
    winforms,
    winformscontrollib,
    winformslib,
    worker,
    mstest,
    nunit,
    xunit,
    razorcomponent,
    page,
    viewimports,
    viewstart,
    blazorserver,
    blazorwasm,
    web,
    webapp,
    react,
    reactredux,
    razorclasslib,
    webapi,
    grpc,
    gitignore,
    mvc,
    angular,
    razor,
    console,
    classlib,
    proto,
    sln,
    webconfig,
    nugetconfig,
    globaljson



}
/// <summary>
/// Фоновая служба сообщения с корневым узлом
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class DotnetBackground : BackgroundService
{
    protected bool _logging;
    protected ConcurrentQueue<DotnetRunParameters> Incomming =
        new ConcurrentQueue<DotnetRunParameters>();
    public DotnetBackground() : base()
    {
        _logging = false;
    }

    /// <summary>
    /// Постановка задачи на выполнение
    /// </summary> 
    public void AddToQueue(DotnetRunParameters todo)
    {
        Incomming.Enqueue(todo);
    }



    /// <summary>
    /// Выполнение приложение ASP NET CORE
    /// </summary>
    /// <param name="options"></param>
    public void DotnetRun(DotnetRunParameters options)
    {
        ProcessStartInfo info = new ProcessStartInfo(
            "CMD.exe", "/C " + @$"dotnet run {options.Path}");
        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;
        System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
        process.WaitForExit();

    }


    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var task = new Task(() => {
            this.LogInformation("ExecuteAsync()");
            while (stoppingToken.IsCancellationRequested == false)
            {

                if (_logging) this.LogInformation("Waiting for tasks ... ");
                DotnetRunParameters options;
                if (!Incomming.TryDequeue(out options))
                {
                    if (_logging) Console.WriteLine("CQ: TryPeek failed when it should have succeeded");
                }
                else if (options != null)
                {
                    if (_logging) this.LogInformation($"Create a single job for task");
                    bool complete = false;
                    try
                    {
                        if (options != null)
                        {
                            Task.Run(() =>
                            {
                                DotnetRun(options);
                            });
                            complete = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        complete = false;
                        this.LogError(ex.Message);
                    }
                    finally
                    {
                        if (complete)
                        {
                            this.LogInformation($"I completed task success");
                        }
                        else
                        {
                            this.LogInformation($"Something go wrong");
                            Thread.Sleep(1000);
                        }
                    }
                }
                else
                {
                    if (_logging) this.LogInformation($"Nothing to do");
                    Thread.Sleep(1000);
                }
            }

        });
        task.Start();
        return task;
    }
}


[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class DotnetRunParameters
{
    /// <summary>
    /// УНикальное наименование
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Порт TCP
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// Путь к исходным файлым
    /// </summary>
    public string Path { get; set; }

}

public interface IDotnetToolEF
{
    string CreateMigration(string context, string name);
    string UpdateDatabase(string context, string name);
}

/// <summary>
/// Выполнение инструкции через командную строку
/// </summary>
public class Dotnet 
{
    
  
    private readonly string _wrk;
    private readonly DOS _dos;

    public Dotnet(string wrk)
    {
        if (System.IO.Directory.Exists(wrk) == false)
        {
            System.IO.Directory.CreateDirectory(wrk);
        }
        _wrk = wrk;
        _dos = new DOS(_wrk);
    }

    public string CreateApplication(DotnetTemplates template)
    {
        string result = ExecCommand($"dotnet new {ToString(template)} --force");
        return result;
    }

    public static string ToString(DotnetTemplates template)
    {
        switch (template)
        {            
            case DotnetTemplates.nunitTest: return "nunit-test";
            case DotnetTemplates.toolManifest: return "tool-manigest";
            default: return template.ToString();
        }
    }

    public string ExecCommand(string command)
    {
        //@$"cd {_wrk} && {command}"
        string message = _dos.RunAsDOS(command);
        return message;
    }



    public string ListMigrations(string context )
    {
        string command = $@"dotnet ef migrations list --no-build --context {context}";
        return ExecCommand(command);
    }

    public Task Run()
    {
        string command = $@"dotnet run";
        return Task.Run(()=> {
            ExecCommand(command);
        });
    }

    public string CreateMigration(string context, string name)
    {
        string command = $@"dotnet ef migrations add {name} --context {context} --no-build";
        return ExecCommand(command);
    }

    public string Build()
    {
        string command = $@"dotnet build";
        return ExecCommand(command);
    }

    public void CreateRazorComponent(string componentNamer)
    {
        string command = $@"dotnet new razorcomponent -o {componentNamer} --no-build";
        ExecCommand(command);
    }
    public string DropDatabase(string context)
    {
        ProcessStartInfo info = new ProcessStartInfo("CMD.exe", "/C " +
                    @$"cd {_wrk} && dotnet ef database drop --context {context} --no-build");

        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;
        System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
        return process.StandardOutput.ReadToEnd();
    }
    public string UpdateDatabase(string context, string name)
    {
        ProcessStartInfo info = new ProcessStartInfo("CMD.exe", "/C " +
                    @$"cd {_wrk} && dotnet ef database update --context {context} --no-build");

        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;
        System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
        return process.StandardOutput.ReadToEnd();
    }

}

public class DotnetServiceTests : TestingElement
{
    public override List<string> OnTest()
    {
        var dotnet = new Dotnet(@"D:\WRK\TestDotnetTool");
        dotnet.CreateApplication(DotnetTemplates.console);
        return Messages;
    }
}