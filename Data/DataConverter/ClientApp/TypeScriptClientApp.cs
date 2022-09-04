using ApplicationCore.Converter.ClientApp;

using System;
 
public class NgApp: TypeScriptProject
{

    private static NgApp global = new NgApp();

    private TypeScriptClientAppModule app; 
    private TypeScriptClientAppModule core;
    private TypeScriptClientAppModule components;
    private TypeScriptClientAppModule pages;
    private TypeScriptClientAppModule projects;
         

    protected NgApp() : base()
    {
    }


    public NgApp( string dir ) : base()
    {
        this.dir = dir;
        while(!System.IO.File.Exists(dir + @"\angular.json"))
        {
            Console.WriteLine(dir + @"\angular.json");
            if (dir.LastIndexOf(@"\") == -1)
            {
                throw new Exception("angular.json not found");
            }
            dir = dir.Substring(0,dir.LastIndexOf("\\"));
        }
        this.app = new TypeScriptClientAppModule(dir + @"\src\app",this);
        this.projects = new TypeScriptClientAppModule(dir + @"\projects", this);
        this.app.import(this.projects);
        this.core = new TypeScriptClientAppModule(dir + @"\src\app-core",this);   
        this.components = new TypeScriptClientAppModule(dir + @"\src\app-components",this);
        this.components.import(this.core);
        this.pages=new TypeScriptClientAppModule(dir + @"\src\app-pages",this);
        this.pages.import(this.components);
        this.app.import(this.pages);
        this.names = this.Concat(this.names, this.app.GetImportedNames());  
        this.AddSourcesFiles(dir + @"\app");
    }


    public override int Replace(string oldName, string newName)
    {
        return this.app.Replace( oldName, newName );
    }


    public void PatchImports()
    {
        this.app.PatchImports();
    }
}
 