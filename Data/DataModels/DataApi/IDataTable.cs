using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Collections.Concurrent;
using System.Collections.Generic;

public interface IDataTable
{
    public string TableName { get; set; }
    public string pk { get; set; }
    public string singlecount_name { get; set; }
    public IDictionary<string, MessageProperty> Properties { get; }
    public IDictionary<string, string>  fk { get; set; }
    public List<string> references { get; set; }
    public string multicount_name { get; set; }

    public bool ContainsBlob();
    public void Create(Dictionary<string, object> record);
    public IDataTable GetMetadata();
    public int Count();
    public string getPrimaryKey();
    public IColumnMetaData[] GetColumnMetaDataArray();
    public string GetSingleCountName();
    public IColumnMetaData GetColumnMetaData(string columnName);
    public string getTableNameCamelized();
    public string GetTableNameCapitalized();
    public string GetTableNameKebabed();
    public JArray SelectAll();
    public List<string> GetKeywords(string entity, string keywordsQuery);
    public JArray Search(string entity, string searchedQuery);
    void Delete(int deleteid);
    public object Select(int findid);
    public void Update(Dictionary<string, object> dictionary);
    public object SelectPage(int page, int size);
    public string ToSql();
    public IEnumerable<object> GetAnnotations(string columnName);
    public List<string> GetTextColumns();

    public IDictionary<string, IColumnMetaData> columns { get; }
    string description { get; set; }
}

 