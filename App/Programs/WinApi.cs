using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

 
public static class WinApi
{

    [DllImport("User32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr h, string m, string c, int type);


    public static string GetUsername()
    {
        return CmdService.CmdExec("set USERNAME");
    }

    public static string GetUsernameProfile()
    {
        return CmdService.CmdExec("set USERPROFILE");
    }

    public static string SearchAppsInUserDir()
    {
        string userProfile = GetUsernameProfile();
        userProfile = userProfile.ReplaceAll("\n", "").ReplaceAll("\r", "").ReplaceAll(@"\\", @"\").ReplaceAll(@"//", @"/");
        return CmdService.CmdExec(@$"cd {userProfile.Substring("USERPROFILE=".Length)} && dir /b /s *.sln") ;
    }

    public static void EditTextFile(string filepath)
    {
        filepath = filepath.Trim();
        if (System.IO.File.Exists(filepath)) 
        {
            var p = Process.Start("notepad", new string[] { filepath });
            p.WaitForExit();
            p.Kill();
        }
        
    }


    public static void CloseWindow(string title)
    {
        Process.GetProcesses().ToList().ForEach(p => {
            if (p.MainWindowTitle.IndexOf(title) != -1)
            {
                Console.WriteLine(p.MainWindowHandle.GetType().GetMembers().ToArray());
                p.CloseMainWindow();
            }
        });
    }

    public static string SearchApps(string path)
    {
        string userProfile = GetUsernameProfile();
        userProfile = userProfile.ReplaceAll("\n", "").ReplaceAll("\r", "").ReplaceAll(@"\\", @"\").ReplaceAll(@"//", @"/");
        string result = CmdService.CmdExec(@$"{path.Substring(0,2)} && cd {path} && dir /b /s *.sln");
        return result;
    }

    public static string SearchSPAs(string dir)
    {
        string userProfile = GetUsernameProfile();
        userProfile = userProfile.ReplaceAll("\n", "").ReplaceAll("\r", "").ReplaceAll(@"\\", @"\").ReplaceAll(@"//", @"/");
        return CmdService.CmdExec(@$"{dir.Substring(0, 2)} && cd {dir} && dir /b angular.json");
    }
    public static IEnumerable<string> GetWindowTitles()
    {
        
        return Process.GetProcesses().Select(p=>p.MainWindowTitle);
    }

    public static void OpenCodeEditor(string filepath)
    {
        CmdService.StartProcess($"vscode {filepath}");
    }


   
    public static void InfoDialog(string title, string text)
    {
        MessageBox((IntPtr)0, text, title, 0);
    }

    public static void Info(string text)
    {
        InfoDialog(Process.GetCurrentProcess().ProcessName, text);
    }
}
 