
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 
 
public class ColumnMetadata: MyValidatableObject
{
    

    public string name { get => TableName; set => TableName = value; }
    public string description { get => TableDescription; set => TableDescription = value; }
    public string type { get => DataType; set => DataType = value; }
    public bool nullable { get => IsNullable!=null&&IsNullable.ToLower()=="true"; set => IsNullable = value.ToString(); }
    public bool primary { get; set; }
    public bool incremental { get; set; }
    

    public ColumnMetadata() { }
    public ColumnMetadata(ColumnMetaData columnMetaData)
    {
        DataType = columnMetaData.type;
        ColumnName = columnMetaData.name;
    }

    public int ID { get; set; }

    //[NotNullNotEmpty]
    public string TableCatalog { get; set; }

    //[NotNullNotEmpty]
    public string TableSchema { get; set; }
        
    //[NotNullNotEmpty]
    public string TableName { get; set; }

    //[NotNullNotEmpty]
    public string ColumnName { get; set; }

    //[InputNumber]
    //[IsPositiveNumber]
    //[NotNullNotEmpty]
    public int OrdinalPosition { get; set; }
    public bool IsComputed { get; set; } = false;
    public string IsNullable { get; set; }
    public string DataType { get; set; }

    //[Label("Параметр сортировки")]
    public string CollationName { get; set; }

        
    public string CharacterSetName { get; set; }
    public string TableDescription { get; private set; }
} 