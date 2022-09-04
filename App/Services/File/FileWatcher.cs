using System;
using System.Diagnostics;
using System.IO;


[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class FileWatcherService   

{
    private static string service;

    public FileWatcherService( ) : base(  )
    {
    }

    private static void OnChanged(object source, FileSystemEventArgs e) =>
        Execute($"{service} {e.FullPath} {e.ChangeType}");

    private static void OnRenamed(object source, RenamedEventArgs e) =>
        Execute($"{service} {e.OldFullPath} renamed to {e.FullPath}");

    public static void Watch(string dir, string filter, string service)
    {
        FileWatcherService.service = service;
        using (FileSystemWatcher watcher = new FileSystemWatcher(dir))
        {
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.FileName
                                    | NotifyFilters.DirectoryName;
            watcher.Filter = filter;

            // Add event handlers.
            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press 'q' to quit the sample.");
            while (Console.Read() != 'q') ;
        }
    }


    public static string Execute(string command)
    {
        Console.WriteLine( "exec=>"+command );
        ProcessStartInfo info = new ProcessStartInfo("CMD.exe", "/C " + command);

        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;
        System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
        string response = process.StandardOutput.ReadToEnd();
        return response;
    }



}
 