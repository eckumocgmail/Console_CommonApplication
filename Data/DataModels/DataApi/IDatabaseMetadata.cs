using System.Collections.Generic;

public interface IDatabaseMetadata
{
    public Dictionary<string, IDataTable> Tables
    {
        get => GetTables();
    }
    string serverVersion { get; set; }
    string database { get; set; }
    string driver { get; set; }
    string connectionString { get; set; }

    Dictionary<string, IDataTable> GetTables();
    Dictionary<string, IDataFunction> GetFunctions();
    Dictionary<string, IStoredProcedure> GetProcedures();
    void Validate();
}