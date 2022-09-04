using Newtonsoft.Json.Linq;

using System.Collections.Generic;
using System.Data;

public interface IDataSource
{

 
    bool canConnect();
    bool canReadAndWrite();
    bool canCreateAlterTables();
    string GetConenctionString();
    IDatabaseMetadata GetDatabaseMetadata();
    Dictionary<string, IDataTable> GetTables();
    JObject ExecuteSingle(string p);
    JArray Execute(string p);
    void InsertBlob(string sql, string v, byte[] data);
    DataTable ExecuteDT(string sql);
 
    object SingleSelect(string sql);
    object MultiSelect(string sql);
    object Exec(string sql);
    object Prepare(string sql);
    JArray GetJsonResult(string sql);
}