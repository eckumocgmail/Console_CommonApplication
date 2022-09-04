using System;
using System.Collections.Generic;

public interface IDatabaseManager
{
    public Dictionary<string, object> statistics { get; }
    public Dictionary<string, IUnitOfWork> fasade { get; }

    public IEntityFasade GetTableManager(string tableName);
    public IDataSource GetDataSource();
    public Dictionary<string, int> GetKeywords();
    public void discovery();
  
}

 