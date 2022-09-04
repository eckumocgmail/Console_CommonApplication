
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CreateViewModule
{
    private string _rootDir;

    public CreateViewModule(string rootDir)
    {
        _rootDir = rootDir;
    }

    public string CreeateViewModule( string viewName )
    {
        
        string message = Cmd.Exec($"cd {_rootDir} && dotnet new classlib -o {viewName}Module");
        return message;
    }
}
