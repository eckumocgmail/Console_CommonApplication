using System;
using System.Diagnostics;
public class Git 
{
    private readonly string _wrk;
    private readonly CmdService _cmd;

    public Git( ):this(System.IO.Directory.GetCurrentDirectory())
    {
 
    }
    public Git(string wrk)
    {
        if (System.IO.Directory.Exists(wrk) == false)
        {
            throw new Exception($"Не существует директории: {wrk}");
        }
        _wrk = wrk;
        _cmd = new CmdService();
    }


    public string Init()
    {
        ProcessStartInfo info = new ProcessStartInfo("CMD.exe", "/C " +
                    @$"cd {_wrk} && git init");

        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;
        System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
        return process.StandardOutput.ReadToEnd();
    }





    public string Commit(string message)
    {
        ProcessStartInfo info = new ProcessStartInfo("CMD.exe", "/C " +
                    @$"cd {_wrk} && git add * && git commit -m \'{message}'");

        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;
        System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
        while( process.StandardOutput.EndOfStream == false)
        {
           
        }
        return "";
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