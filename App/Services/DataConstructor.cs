using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

public class DatasetConstructor
{
    private static readonly string DefaultConnectionString =
            @"Server=DESKTOP-I4N78PV\SQLEXPRESS;Database=Catalog;Trusted_Connection=True;MultipleActiveResultSets=true";
    private static readonly string DefaultSelectCategoryQuery =
            @"SELECT CategoryID FROM Categories";
    private static readonly string DefaultSelectCategoryTableName =
            @"Categories";
    private readonly string _categorySelectTableName;
    private readonly string _connectionString;
    private readonly SqlConnection _connection;
    private readonly SqlDataAdapter _adapter;
    private readonly DataSet _dataSet;


    public DatasetConstructor() : this(DefaultConnectionString, DefaultSelectCategoryTableName, DefaultSelectCategoryQuery) { }
    public DatasetConstructor(
            string connectionString,
            string categorySelectTableName,
            string categorySelectQuery)
    {
        _categorySelectTableName = categorySelectTableName;
        _connectionString = connectionString;
        _connection = Connect();
        _adapter = new SqlDataAdapter(categorySelectQuery, _connection);
        _dataSet = new DataSet();
        _adapter.Fill(_dataSet, DefaultSelectCategoryTableName);
    }


    private void AddFunctions()
    {
        // Создать вычисляемые столбцы
        DataColumn count = new DataColumn(
         "Кол-во связанных продуктов", typeof(int), "COUNT(Child(CatProds).CategoryID)");
        DataColumn max = new DataColumn(
          "Самый дорогой продукт: стоимость", typeof(decimal), "MAX(Child(CatProds).UnitPrice)");
        DataColumn min = new DataColumn(
          "Самый дешевый продукт: стоимость", typeof(decimal), "MIN(Child(CatProds).UnitPrice)");

        // Добавить столбцы
        _dataSet.Tables[_categorySelectTableName].Columns.Add(count);
        _dataSet.Tables[_categorySelectTableName].Columns.Add(max);
        _dataSet.Tables[_categorySelectTableName].Columns.Add(min);
    }


    public DatasetConstructor AddTestRelation()
    {
        AddRelation("CatProds", "SELECT ProductName, CategoryID, UnitPrice FROM Products", "Products", "CategoryID");
        return this;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="relationName"></param>
    /// <param name="selectDimensionQuery">"SELECT ProductName, CategoryID, UnitPrice FROM Products"</param>
    /// <param name="selectDimensionTableName">Products</param>
    /// <param name="key"></param>
    //key="CategoryID"
    public void AddRelation(string relationName, string selectDimensionQuery, string selectDimensionTableName, string key)
    {
        _adapter.SelectCommand.CommandText = selectDimensionQuery;
        _adapter.Fill(_dataSet, selectDimensionTableName);

        // Связать таблицы Categories и Products в DataSet
        DataRelation relation = new DataRelation(relationName,
            _dataSet.Tables[_categorySelectTableName].Columns[key],
            _dataSet.Tables[selectDimensionTableName].Columns[key]);
        _dataSet.Relations.Add(relation);
    }

    public List<Dictionary<string, object>> GetData()
    {
        List<Dictionary<string, object>> listRow = new List<Dictionary<string, object>>();
        foreach (DataRow row in _dataSet.Tables[0].Rows)
        {
            Dictionary<string, object> rowSet = new Dictionary<string, object>();
          
            foreach (DataColumn column in _dataSet.Tables[0].Columns)
            {
                rowSet[column.Caption] = row[column.Caption];
            }
            listRow.Add(rowSet);
        }
        return listRow;
    }


    private SqlConnection Connect()
    {
        return new SqlConnection(_connectionString);
    }
}