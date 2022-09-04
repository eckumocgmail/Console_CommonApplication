using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DOS
{
   private static readonly string DEFAULT_BAT_FILENAME = "DOS.BAT";
    private static readonly string DEFAULT_OUTPUT_FILENAME = "DOS.LOG";
    private readonly string _wrk;
    private readonly string batFilePath;
    private readonly string outputFilePath;

    public DOS(string wrk)
    {
        this._wrk = wrk;
        this.batFilePath = Path.Combine(wrk,DEFAULT_BAT_FILENAME);
        this.outputFilePath = Path.Combine(wrk,DEFAULT_OUTPUT_FILENAME);
    }

    public DOS(string batFilePath, string outputFilePath)
    {
        this.batFilePath = batFilePath;
        this.outputFilePath = outputFilePath;
    }

    public string RunAsDOS(string command)
    {
        System.IO.File.WriteAllText(batFilePath, command+" > "+ outputFilePath);
        

        ProcessStartInfo info = new ProcessStartInfo("CMD.exe", "/C " + batFilePath);

        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;
        if (string.IsNullOrEmpty(this._wrk) == false)
        {
            info.WorkingDirectory = this._wrk;
        }
        System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
        process.WaitForExit();
        string result = System.IO.File.ReadAllText(outputFilePath);
        return result;
    }

}