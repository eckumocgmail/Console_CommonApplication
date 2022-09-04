using Microsoft.AspNetCore.Mvc;

using System;
using System.Diagnostics;


using System;
using System.Diagnostics;
using System.Threading;

public class CmdService : Cmd
{
    public CmdService()
    {
    }

    /// <summary>
    /// Выполнение инструкции через командную строку
    /// </summary>
    /// <param name="command"> команда </param>
    /// <returns></returns>
    public static string CmdExec(string command)
    {
        command = command.ReplaceAll("\n", "").ReplaceAll("\r", "").ReplaceAll(@"\\", @"\").ReplaceAll(@"//", @"/");

        Api.Utils.Info(command);


        ProcessStartInfo info = new ProcessStartInfo("CMD.exe", "/C " + command);

        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;
        System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
        string response = process.StandardOutput.ReadToEnd();
        string result = response.ReplaceAll("\r", "\n");
        result = result.ReplaceAll("\n\n", "\n");
        while (result.EndsWith("\n"))
        {
            result = result.Substring(0, result.Length - 1);
        }
        return result;
    }

    public static string Search(string path, string pattern)
    {
        return CmdService.CmdExec(@$"{path.Substring(0, 2)} && cd {path} && dir /b /s *.sln");
    }


    /// <summary>
    /// Выполнение инструкции через командную строку
    /// </summary>
    /// <param name="command"> команда </param>
    /// <returns></returns>
    public static void StartProcess(string command)
    {
        Thread work = new Thread(new ThreadStart(() => {
            ProcessStartInfo info = new ProcessStartInfo("CMD.exe", "/C " + command);

            info.RedirectStandardError = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
            string response = process.StandardOutput.ReadToEnd();

        }));
        work.IsBackground = true;
        work.Start();
    }
}


public class CmdController: Controller, ICmd
{
    private readonly ICmd _cmd;

    public CmdController(ICmd cmd)
    {
        this._cmd = cmd;
    }

    public MethodResult<object> Execute(string command)
        => this._cmd.Execute(command);
}

public interface ICmd
{
    MethodResult<object> Execute(string command);
}

/// <summary>
/// Отвечает за исполнение команд полученных от клиента
/// </summary>
[Route("[controller]/[action]")]
public class Cmd : ICmd
{

    public MethodResult<object> Execute(string command)
    {
        MethodResult<object> result = null;
        try
        {
            result = MethodResult.OnResult(Exec(command));
        }
        catch (Exception ex)
        {
            result = MethodResult<object>.OnError(ex);


        }
        finally
        {
            Console.WriteLine(result.ToJsonOnScreen());
        }
        return result;
    }

  

    public static string Exec(string command)
    {
        ProcessStartInfo info = new ProcessStartInfo("CMD.exe", "/C " + command);

        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;
        System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
        string response = process.StandardOutput.ReadToEnd();
        return response;
    }

    public static string ExecFromDirectory(string directory, string command)
    {
        ProcessStartInfo info = new ProcessStartInfo("CMD.exe", "/C " + $" {directory.Substring(0, 2)}" + $" && cd \"{directory}\" && " + command);

        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;
        System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
        string response = process.StandardOutput.ReadToEnd();
        return response;
    }
}
