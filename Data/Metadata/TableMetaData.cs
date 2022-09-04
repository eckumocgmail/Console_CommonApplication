
using DataCommon.DatabaseMetadata;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


public class TableMetaData: MyValidatableObject
{
    [NotNullNotEmpty]
    [Display(Name = "Единственное число")]
    public string name { get => TableName; set => TableName = value; }
    [Display(Name = "Множественное число")]
    public string multicount_name { get => name.ToMultiCount(); set => name = value.ToSingleCount(); }

    [Display(Name = "Единственное число")]
    public string singlecount_name { get => name.ToSingleCount(); set => name = value.ToSingleCount(); }


    [Display(Name = "Схема")]
    public string schema { get; set; } = "dbo";



 
     

    [Display(Name = "Заголовок")]
    public string caption { get; set; }
     

    [Display(Name = "Описание")]
    public string description { get; set; }

    [NotNullNotEmpty]
    [Required(ErrorMessage = "Необходимо задать первичный ключ")]
    public string pk = "ID";


    // таблицы в которых возможны множественные ссылки на уникальный обьект тек. таблицы
    [Display(Name = "Ссылки")]
    public List<string> references { get; set; } = new List<string>();


    // ключ- наименование колонки внешнего ключа,  значение - наименование таблицы на которую ссылается ( на первичный ключ которой ссылается внешний)
    [Display(Name = "Внешние ключи")]
    public Dictionary<string, string> fk { get; set; } = new Dictionary<string, string>();

     
    public List<string> GetAnnotations(string column)
    {
        List<string> annotations = new List<string>();
        List<string> _ids = new List<string>(TextNaming.SplitName(this.name));
        List<string> ids = new List<string>();
        foreach (string id in _ids)
        {
            ids.Add(id.ToLower());
        }
        annotations.Add($"[System.ComponentModel.DataAnnotations.Schema.Column(\"{column}\")]");
        if (ids.Contains("url"))
        {
            annotations.Add("[System.ComponentModel.DataAnnotations.Url()]");
        }
        if (ids.Contains("email"))
        {
            annotations.Add("[System.ComponentModel.DataAnnotations.EmailAddress()]");
        }
        if (ids.Contains("phone") || ids.Contains("tel"))
        {
            annotations.Add("[System.ComponentModel.DataAnnotations.Phone()]");
        }
        if (ids.Contains("password"))
        {
            annotations.Add("[DataType(DataType.Password)]");
        }
        if (ids.Contains("image") || ids.Contains("imageurl"))
        {
            annotations.Add("[DataType(DataType.ImageUrl)]");
        }
        if (this.columns[column].type.ToLower() == "date")
        {
            annotations.Add("[DisplayFormat(DataFormatString = \"" + "{" + "0:dd.MM.yyyy" + "}" + "\", ApplyFormatInEditMode = true)]");
        }
        if (this.columns[column].name == this.getPrimaryKey() || this.columns[column].primary)
        {
            annotations.Add("[System.ComponentModel.DataAnnotations.Key()]");
        }
        if (this.columns[column].nullable == false)
        {
            annotations.Add("[System.ComponentModel.DataAnnotations.Required()]");
        }
        return annotations;
    }

    public string getPrimaryKey()
    {
        string primaryKey = this.name.ToUpper() + "ID";
        string singleIdName = this.singlecount_name.ToUpper() + "ID";
        string multiIdName = this.multicount_name.ToUpper() + "ID";
        if (this.pk == null)
        {

            foreach (var columnEntry in this.columns)
            {
                if (columnEntry.Value.primary == true)
                {
                    return this.pk = columnEntry.Value.name;

                }
                else if (columnEntry.Key.ToUpper() == "ID")
                {
                    return this.pk = columnEntry.Value.name;
                }
                else if (columnEntry.Key.ToUpper() == (singleIdName) || columnEntry.Key.ToUpper() == (multiIdName))
                {
                    return this.pk = columnEntry.Key;
                }

            }

        }
        else
        {
            return this.pk;
        }
        return "ID";
        //throw new Exception($"Метаданные талицы: {this.name} не содержат определние первичного ключа");        
    }


    public bool ContainsBlob()
    {

        foreach (var columnEntry in this.columns)
        {
            if (columnEntry.Value.type.ToLower() == "blob")
            {
                return true;
            }
        }
        return false;
    }

    public List<string> GetTextColumns()
    {
        List<string> textColumns = new List<string>();
        foreach (var columnEntry in this.columns)
        {
            List<string> types = new List<string>(new String[] { "nvarchar", "varchar", "ntext", "text", "char" });

            if (types.Contains(columnEntry.Value.type.ToLower()))
            {
                textColumns.Add(columnEntry.Value.name);
            }
        }
        return textColumns;
    }

    public string getTableNameKebabed()
    {
        string kebab = "";
        for (int i = 0; i < this.name.Length; i++)
        {
            if (i != 0 && this.name[i].ToString() == this.name[i].ToString().ToUpper())
            {
                kebab += "-" + this.name[i].ToString().ToLower();
            }
            else
            {
                kebab += this.name[i].ToString().ToLower();
            }
        }
        return kebab;
    }
    public IDictionary<string, ColumnMetadata> columns { get => ColumnsMetadata; set => ColumnsMetadata = value; }
    public TableMetaData()
    {
    }

    public TableMetaData(TableMetaData metadata)
    {
        TableName = metadata.name;
        TableSchema = metadata.schema;
        ColumnsMetadata = new Dictionary<string, ColumnMetadata>();
        foreach(var kv in metadata.columns)
        {
            ColumnsMetadata[kv.Key] = CreateColumnMetadata(metadata.columns[kv.Key]);
        }
    }

    private ColumnMetadata CreateColumnMetadata(ColumnMetadata columnMetadata)
    {
        throw new NotImplementedException();
    }

    public int ID { get; set; } = 1;
        
    public string TableCatalog { get; set; }
    public string TableSchema { get; set; }

    [NotNullNotEmpty]
    public string TableName { get; set; }
    public string TableType { get; set; }

    [NotNullNotEmpty]
    [NotMapped]
    public IDictionary<string, ColumnMetadata> ColumnsMetadata { get; set; }

    [NotNullNotEmpty]
    public string PrimaryKey { get; set; } = "ID";

    /// <summary>
    /// Внешние ключи
    /// Ключ = [ColumnName] 
    /// Значение = [TableName]
    /// </summary>
    public IDictionary<string, string> ForeignKeys { get; set; } = new Dictionary<string, string>();
} 