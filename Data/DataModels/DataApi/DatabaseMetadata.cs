using DataCommon.DatabaseMetadata;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class DatabaseMetadata: IDatabaseMetadata
{
    public string driver;
    public string database;
    public string serverVersion;
    public string connectionString;

    public Dictionary<string, TableMetaData> Tables = new Dictionary<string, TableMetaData>();
    public Dictionary<string, object> Metadata = new Dictionary<string, object>();

    public DatabaseMetadata() { }

    string IDatabaseMetadata.serverVersion { get; set; }
    string IDatabaseMetadata.database { get; set; }
    string IDatabaseMetadata.driver { get; set; }
    string IDatabaseMetadata.connectionString { get; set; }

    public Dictionary<string, IDataTable> GetTables()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public Dictionary<string, IDataFunction> GetFunctions()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public Dictionary<string, IStoredProcedure> GetProcedures()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public void Validate()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}
