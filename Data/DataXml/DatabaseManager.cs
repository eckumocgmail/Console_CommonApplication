using System;
using System.Collections.Generic;

public class DatabaseManager
{
    private IDataSource source;
    internal Dictionary<string, object> statistics;
    internal Dictionary<string, IEntityFasade> fasade;
 

    public DatabaseManager()
    {
    }

    public DatabaseManager(IDataSource source)
    {
        this.source = source;
    }
    public DatabaseManager(string source)
    {
        this.source = CreateDataSource(source);
    }

    private IDataSource CreateDataSource(string source)
    {
        throw new NotImplementedException();
    }

    internal Dictionary<string, int> GetKeywords()
    {
        throw new NotImplementedException();
    }

    internal void discovery()
    {
        throw new NotImplementedException();
    }

    internal object Execute(string sqlQuery)
    {
        throw new NotImplementedException();
    }

    internal object GetFasade(string v1, string v2)
    {
        throw new NotImplementedException();
    }

    internal IDataSource GetDataSource()
    {
        throw new NotImplementedException();
    }
}