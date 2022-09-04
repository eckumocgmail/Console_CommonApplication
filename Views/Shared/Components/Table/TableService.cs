 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

 
public class TableService
{

    public Table ForBusinessDataset(BusinessDataset dataset)
    {

        var table = new Table();        
        dataset.Join("Datasource");        
        /*if( dataset.Datasource != null)
        {
            var odbc = dataset.Datasource.GetOdbcDatabaseManager();
            try
            {
                odbc.Execute(dataset.Expression);
            }catch(Exception ex)
            {

            }
        }*/
        return table;
    }
    public Table ForCollectionProperty(object target, string property)
    {
        string typeName = 
            Typing.ParseCollectionType(target.GetType().GetProperty(property).PropertyType);
        if (Typing.IsPrimitive(typeName))
        {
            return ForPrimitiveCollection(
                        target.GetType().GetProperty(property).GetValue(target),
                        ReflectionService.TypeForName(typeName),
                        AttrsUtils.DescriptionFor(target.GetType(), property));
        }
        else
        {
            return ForCollection(
                        target.GetType().GetProperty(property).GetValue(target),
                        ReflectionService.TypeForName(typeName));
        }
        
    }

    public global::Table ForPrimitiveCollection(dynamic items, Type type, string caption)
    {
        global::Table tm = new global::Table();
        tm.type = type;
        tm.IsPrimitive = true;
        tm.Columns = new List<string> { caption };
        tm.Cells = new List<List<object>>();
        foreach (var item in items)
        {
            tm.Cells.Add(new List<object> { item });
        }
        tm.Editable = true;
        return tm;
    }

    public global::Table ForCollection(dynamic items, Type type)
    {
        global::Table tm = new global::Table();
        tm.type = type;
        tm.Columns = (from p in ReflectionService.GetOwnPropertyNames(type) select p).ToList();
        foreach (var item in items)
        {
            try
            {
                tm.Cells.Add(ReflectionService.Values(item, tm.Columns));
            }
            catch (Exception)
            {
                tm.Cells.Add(new List<object>() { "Ошибка при получении значения" });
            }
            
        }
        return tm;
    }

    public global::Table ForTableManager(IEntityFasade manager)
    {
        global::Table tm = new global::Table();
        Dictionary<string, ColumnMetaData> columns = new Dictionary<string, ColumnMetaData>();// manager.GetMetadata().columns;
        tm.Columns = new List<string>(columns.Keys).ToList();
        List<object[]> rows = new List<object[]>();
        /*foreach(var token in manager.SelectAll())
        {
            token.Value<object>();
        }*/
        tm.Cells = new List<List<object>>();
        return tm;
    }

    
    public Table ForDictionary(IDictionary<string,object> properties, string title)
    {
        var table = new Table();
        table.Title = title;
        table.Searchable = true;
        table.Columns = new List<string> { "Ключ","Значение"};
        table.Cells = new List<List<object>>();
        foreach (var p in properties)
        {
            table.Cells.Add(new List<object> { p.Key, p.Value });
        }
        return table;
    }


    /// <summary>
    /// Создание модели табличного представления из свойств обьекта
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public global::Table ForDictionary(object model)
    {

        /*global::Table tm = new global::Table();

        tm.Columns = ReflectionService.GetOwnMethodNames(model.GetType());
        List<object[]> cells = new List<object[]>();

        //cells
        object[] row = new object[cells.Count()];
        int i = 0;
        foreach (string column in tm.Columns)
        {
            row[i++] = GetValue(model, column);
        }
        cells.Add(row);

        //tm.Cells = cells.ToArray();
        tm.Cells = new List<List<object>>();// new Newtonsoft.Json.Linq.JArray();
        return tm;*/
        return ForDictionary(Formating.ToDictionaryLabels(model), AttrsUtils.LabelFor(model.GetType()));
    }


    /// <summary>
    /// Извлекает значение свойства из обьекта по наименованию
    /// </summary>
    /// <param name="model"></param>
    /// <param name="property"></param>
    /// <returns></returns>
    private object GetValue(object model, string property)
    {
        PropertyInfo propertyInfo = model.GetType().GetProperty(property);
        FieldInfo fieldInfo = model.GetType().GetField(property);
        return
            fieldInfo != null ? fieldInfo.GetValue(model) :
            propertyInfo != null ? propertyInfo.GetValue(model) :
            null;

    }
}
 