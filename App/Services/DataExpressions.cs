

using DataCommon.DatabaseMetadata;

using DataConverter.Generators;

using System;
using System.Collections.Generic;
using System.Text;


public class DataExpressions
{


    /// <summary>
    /// Создать внешний ключ
    /// </summary>
    /// <returns></returns>
    public string CreateForeignkey(string relativeTable, string table, string column,  bool? onDeleteCascade=false, bool? onUpdateCascade=null )
    {
        return $"ALTER TABLE {table} ADD CONSTRAINT {table+relativeTable} FOREIGN KEY {column} REFERENCES ({relativeTable})" + " ON DELETE " + (onDeleteCascade == true ? "CASCADE" : "NO ACTION ") + " ON UPDATE " + (onUpdateCascade == true ? "CASCADE" : "NO ACTION ");
        
    }


    /// <summary>
    /// Создать таблицу
    /// </summary>
    /// <param name="metadata"></param>
    /// <returns></returns>
    public string CreateTable( TableMetaData metadata)
    {
        string sql = $"create table {metadata.TableName}\n";
        sql += "(";
        foreach(var p in metadata.columns)
        {
            sql += $"\n  {p.Key} {p.Value.type} ";
            if(p.Key.ToLower() == metadata.pk.ToLower())
            {
                if (p.Value.incremental)
                {
                    sql += " identity(1,1) ";
                } 
                sql += " primary key,";
            }
            else
            {
                sql += ",";
            }
        }
        if (metadata.columns.Count > 0)
        {
            sql = sql.Substring(0, sql.Length - 1);
        }
        sql += "\n)\n";
        return sql;
    }

    /*private object toSqlType(string type)
    {
        switch (type.ToLower())
        {
            case "int": return "int";
            case "string": return "nvarchar(max)";
            case "date": return "date";
            case "datetime": return "datetime";
            case "text": return "nvarchar(80)";
            case "multitext": return "nvarchar(max)";
            case "email": return "nvarchar(80)";
            case "number": return "float";
            default: throw new Exception("Unsupported type: "+type);
        }
    }*/
}
