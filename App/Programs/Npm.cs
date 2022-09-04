using System;
using System.Collections.Generic;

public interface INpm
{
 
    public string Init(string dir, string scope );
    public string Pack(string dir);
    public string Publish(string dir, string name);
    public string Publish(string dir, string name, string version);
    public string Login(string email, string password);
    public string Logout();
    public IDictionary<string, string> GetPackages(string dir);
    public void AddPackage(string dir, string package, string version);
    public void UpdatePackage(string dir, string package);
    public void RemovePackage(string dir, string package);
    public void InstallPackages(string dir);
    public void Run(string file);
}



public class Npm: ProcessManager, INpm
{
    public string Init(string dir, string scope )
    {
        return Exec($"npm init --force --scope {scope}", $"{dir}");
    }

  
    public string Pack(string dir)
    {
        throw new System.NotImplementedException();
    }

    public string Publish(string dir, string name)
    {
        throw new System.NotImplementedException();
    }

    public string Publish(string dir, string name, string version)
    {
        throw new System.NotImplementedException();
    }

    public string Login(string email, string password)
    {
        throw new System.NotImplementedException();
    }

    public string Logout()
    {
        throw new System.NotImplementedException();
    }

    public IDictionary<string, string> GetPackages(string dir)
    {
        throw new System.NotImplementedException();
    }

    public void AddPackage(string dir, string package, string version)
    {
        throw new System.NotImplementedException();
    }

    public void UpdatePackage(string dir, string package)
    {
        throw new System.NotImplementedException();
    }

    public void RemovePackage(string dir, string package)
    {
        throw new System.NotImplementedException();
    }

    public void InstallPackages(string dir)
    {
        throw new System.NotImplementedException();
    }

    public void Run(string file)
    {
        throw new System.NotImplementedException();
    }
}


