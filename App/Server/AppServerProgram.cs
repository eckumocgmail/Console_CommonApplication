 using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static Api.Utils;
 
using static System.IO.Directory;

public class AppServerProgram: ConsoleProgram
{

    /// <summary>
    /// Сервер приложений предоставляет интерфейс для запуска приложений
    /// </summary>        
    public static void Run(params string[] applications)
    {
        Info($"Run({applications.ToJson()})");   
        if (applications.Length == 0)
        {
            
            IEnumerable<string> selected = SelectClientApps();
            Run(selected.Select(path => path.Replace("\\\\","\\")).ToArray());
        }
        else
        {
            Start(applications.ToArray()).GetAwaiter().GetResult();
        }

    }

    /// <summary>
    /// Запуск выбранных приложений
    /// </summary>
    private static async Task   Start(string[] apps)
    {
        Info($"Start({apps.ToJson()})");

        var server = new AppServer();
        await server.StartAsync(apps);
       
    }

        

    /// <summary>
    /// Выбор клиентских приложений
    /// </summary>        
    private static IEnumerable<string> SelectClientApps()
    {
        
        string[] apps = AppServerProgram.SearchClientAppsAsync().ToArray();


        IEnumerable<string> selected = Api.Utils.CheckListTitle<string>(
            "   Модули приложения", apps, (application) => application
        );
        return selected;
    }

    /// <summary>
    /// Просматривает файловую систему на предмет каталогов с
    /// содержанимаем файла angular.json.
    /// Условно считаем что это и есть клиентское приложение.
    /// </summary>        
    public static IEnumerable<string> SearchClientApps()
    {
        var clientApps = new List<string>();
        foreach (var dir in GetSubDirs(@"D:\"))
        {
            if (dir.IndexOf("node_modules") == -1) 
            {
                string filepath = Path.Combine(dir, "angular.json").ToString();
                if (System.IO.File.Exists(filepath))
                {
                    clientApps.Add(filepath);
                }
            }                
        }
        return clientApps;
    }

    /// <summary>
    /// Поиск клиентских приложений
    /// </summary>        
    public static IEnumerable<string> SearchClientAppsAsync()
    {
        Clear();
        Info($"\nВыполняю поиск приложений... \nМожет занять некоторое время... \nПожалуйста ждите... \n ");
        var clientApps = new List<string>();
        foreach (var dir in GetSubDirsAsync(@"D:\\"))
        {
            if (dir.IndexOf("node_modules") == -1)
            {
                string filepath = Path.Combine(dir, "angular.json").ToString();
                if (System.IO.File.Exists(filepath))
                {
                    clientApps.Add(filepath);
                }
            }
        }
        return clientApps;
    }




    //
    public static HashSet<string> GetSubDirs(string path)
    {
        //Console.WriteLine(path);
        var dirs = GetDirectories(path);
        var subdirs = path.ToCharArray().Where(ch=>ch == '\\').Count()<3?
                dirs.SelectMany(d => GetSubDirs(d)).ToList(): new List<string>();
        var all = new HashSet<string>();
        dirs.ToList().ForEach(d=>all.Add(d));
        subdirs.ToList().ForEach(d=>all.Add(d));

        return all;
            //.Where(d => System.IO.File.Exists(Path.Combine(d, "angular.json").ToString()));
    }
    public static HashSet<string> GetSubDirsAsync(string path)
    {


        Console.WriteLine();
        var all = new HashSet<string>();

        var dirs = GetDirectories(path);
        var subdirs = new ConcurrentBag<string>();
        if (path.ToCharArray().Where(ch => ch == '\\').Count() < 3)
        {
            //1)dirs.SelectMany(d => GetSubDirs(d)).ToList().ForEach(subdirs.Add);
            var tasks = new List<Task>();
            foreach (var dir in dirs)
            {
                string pdir = dir;
                tasks.Add(Task.Run(() => {
                    try
                    {
                        GetSubDirsAsync(pdir).ToList().ForEach(subdirs.Add);
                    }
                    catch (Exception)
                    {
                            
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }
        dirs.ToList().ForEach(d => all.Add(d));
        subdirs.ToList().ForEach(d => all.Add(d));

        return all;
        //.Where(d => System.IO.File.Exists(Path.Combine(d, "angular.json").ToString()));
    }

    
}