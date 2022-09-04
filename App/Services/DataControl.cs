

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
 

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


public class DataObject
{

    public DataSet DataSet { get; }


    public DataObject()
    {
        this.DataSet = new DataSet();
    }
}
public class DataControl
{
    private static string CONNECTION_STRING = @"Server=CCPL-1728\SQLExpress;Database=Marketplace;Trusted_Connection=True;MultipleActiveResultSets=true";

    private IDatabaseMetadata MetaData;

    public DataObject DataObject { get; private set; }

    public DataControl(){}

    public void Init() {
        //DatabaseManager.GetAdoDataSource("AdwewntureWorks",CONNECTION_STRING);
       // MetaData = DatabaseManager.GetOdbcDatabaseManager(CONNECTION_STRING).GetMetadata();
       // DataObject = new DataObject();
    }

    public List<string> GetDimensions()
    {
        return (from p in this.MetaData.Tables.Keys where p.StartsWith("Dim") select p).ToList();
    }

    public List<string> GetFacts()
    {
        return (from p in this.MetaData.Tables.Keys where p.StartsWith("Dim") select p).ToList();
    }



    public static List<Dictionary<string, object>> GetSeries()
    {
        SqlConnection connect = new SqlConnection(@"Server=CCPL-1728\SQLSERVER;Database=PivotTable;Trusted_Connection=True;MultipleActiveResultSets=true");

        string sqlCat = "SELECT CategoryID, CategoryName FROM Categories";
        string sqlProd = "SELECT ProductName, CategoryID, UnitPrice FROM Products";
        
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCat, connect);
        DataSet dataset = new DataSet();
        adapter.Fill(dataset, "Categories");

        adapter.SelectCommand.CommandText = sqlProd;
        adapter.Fill(dataset, "Products");

        // Связать таблицы Categories и Products в DataSet
        DataRelation relation = new DataRelation("CatProds",
            dataset.Tables["Categories"].Columns["CategoryID"],
            dataset.Tables["Products"].Columns["CategoryID"]);

        dataset.Relations.Add(relation);

        // Создать вычисляемые столбцы
        DataColumn count = new DataColumn(
         "Кол-во связанных продуктов", typeof(int), "COUNT(Child(CatProds).CategoryID)");
        DataColumn max = new DataColumn(
          "Самый дорогой продукт: стоимость", typeof(decimal), "MAX(Child(CatProds).UnitPrice)");
        DataColumn min = new DataColumn(
          "Самый дешевый продукт: стоимость", typeof(decimal), "MIN(Child(CatProds).UnitPrice)");

        // Добавить столбцы
        dataset.Tables["Categories"].Columns.Add(count);
        dataset.Tables["Categories"].Columns.Add(max);
        dataset.Tables["Categories"].Columns.Add(min);
        using (var sw = new StringWriter())
        {
            dataset.WriteXml(sw);
            sw.Flush();
            string xml = sw.ToString();
            Api.Utils.Info(xml);
        }

        List<Dictionary<string, object>> listRow = new List<Dictionary<string, object>>();
        foreach (DataRow row in dataset.Tables[0].Rows)
        {
            Dictionary<string, object> rowSet = new Dictionary<string, object>();
           
            foreach (DataColumn column in dataset.Tables[0].Columns)
            {
                rowSet[column.Caption] = row[column.Caption];
            }
            listRow.Add(rowSet);
        }
        return listRow;
    }
}
