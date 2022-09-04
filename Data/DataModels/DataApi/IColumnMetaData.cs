public interface IColumnMetaData
{
    public string name { get; set; }
    public string type { get; set; }

    public bool primary { get; set; }
    public bool nullable { get; set; }
    string description { get; set; }
    bool incremental { get; }
}
public class ColumnMetaData : IColumnMetaData
{
    public ColumnMetaData()
    {
    }

    public string name { get; set; }
    public string type { get; set; }

    public bool primary { get; set; }
    public bool nullable { get; set; }
    public bool unique { get; set; }
    public string description { get; set; }
    public bool incremental { get; set; }

    public string GetTypeName()
    {
        throw new System.NotImplementedException();
    }
}