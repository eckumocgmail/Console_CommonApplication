using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

    public class AgregatedDataSet 
    {
        private static readonly string DefaultConnectionString =
    @"Server=DESKTOP-I4N78PV\SQLEXPRESS;Database=Catalog;Trusted_Connection=True;MultipleActiveResultSets=true";

        private readonly DataSet dataset;

        public AgregatedDataSet() 
        {
            SqlConnection connect = new SqlConnection(DefaultConnectionString);

            string sqlCat = "SELECT CategoryID, CategoryName FROM Categories";
            string sqlProd = "SELECT ProductName, CategoryID, UnitPrice FROM Products";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCat, connect);
            this.dataset = new DataSet();
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
        }


        public string ToXml()
        {
            using (var sw = new StringWriter())
            {
                dataset.WriteXml(sw);
                sw.Flush();
                string xml = sw.ToString();
                return xml;
            }
        }

        public JArray GetData()
        {
            List<Dictionary<string, object>> listRow = new List<Dictionary<string, object>>();
            foreach (DataRow row in dataset.Tables[1].Rows)
            {
                Dictionary<string, object> rowSet = new Dictionary<string, object>();
             
                foreach (DataColumn column in dataset.Tables[0].Columns)
                {
                    rowSet[column.Caption] = row[column.Caption];
                }
                listRow.Add(rowSet);
            }
            JArray arr = (JArray)JObject.FromObject(new { dataRows= listRow })["dataRows"];
            return arr;
        }
 
    }
