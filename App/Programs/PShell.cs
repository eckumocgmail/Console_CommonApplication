using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PShell
{
    public string Execute(string command)
    {
        Console.WriteLine("Execute command: "+command);

        ProcessStartInfo info = new ProcessStartInfo("PowerShell.exe", "/C " + command);
        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;
                    
        System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
        System.IO.StreamReader reader = process.StandardOutput;

        string result = reader.ReadToEnd();
        return result;
    }
}