 
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

public class ComponentFactory: IComponentFactory
{

    private List<Assembly> imported = new List<Assembly>() {
        
     
        typeof(System.Data.DataColumn).Assembly
    };


    /// <summary>
    /// Анализ информации полученной из XML документа 
    /// для создание модели компонента представления    
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="Parent"></param>
    /// <returns></returns>
    public object Create(InputParams parameters, ComponentModel Parent, global::ReportItem Root)
    {

        try
        {


            this.Info("\n\n Переход к контейнеру: ");
            //Api.Utils.Info(parameters);
            string TypeName = TextNaming.ToCapitalStyle(parameters.Tag);
            this.Info("TypeName=" + TypeName);
            
            if (parameters.GetNameAttribute() != null)
            {
                this.Info(parameters.GetNameAttribute());
                Type parentType = Parent.Target.GetType();
                string property = TextNaming.ToCapitalStyle(parameters.GetNameAttribute());
                PropertyInfo info = parentType.GetProperty(property);
                if( info == null)
                {
                    throw new Exception("Класс " + parentType.Name + " не обяьвляет свойство " + property);
                }
                object value = info.GetValue(Parent.Target);
                if (value != null)
                {
                    return value;
                }
                else
                {
                    object current = Create(TypeName, parameters.Attrs, Parent, Root);
                    info.SetValue(Parent.Target, current);
                    return current;
                }
            }

            if (Parent != null)
            {

                //если существует свойство с одноимённым идентификатором, то 
                //компонент является указателем на это свойство в случае
                //если свойство определено в единственном числе,
                //если свойство определено во множественном числе( т.е. как коллекция )
                //ссылка будет добавлена в коллекцию
                /*if (Typing.IsCollectionType(Parent.Target.GetType()))
                {
                    object current = Create(TypeName, parameters.Attrs, Parent, Root);
                    if (Parent.Target is DataColumnCollection)
                    {
                        DataColumnCollection col = (DataColumnCollection)Parent.Target;
                        col.Add((DataColumn)current);
                        return current;
                    }
                    else
                    {
                        dynamic collection = Parent.Target;
                        collection.Add(current);
                        return current;

                    }
                }*/
                PropertyInfo info = Parent.Target.GetType().GetProperty(TypeName);
                if (info != null)
                {
                    if (Typing.IsCollectionType(Parent.Target.GetType().GetProperty(info.Name).PropertyType))
                    {
                        object current = new List<object>();
                        info.SetValue(Parent.Target, current);
                        return current;

                    }
                    else
                    {
                        object current = Create(TypeName, parameters.Attrs, Parent, Root);
                        if (Parent.Target.GetType().Name.StartsWith("List"))
                        {
                            dynamic collection = info.GetValue(Parent.Target);
                            collection.Add(current);
                            return current;
                        }
                        else
                        {

                            info.SetValue(Parent.Target, current);
                            return current;
                        }

                    }
                }
                else
                {
                    object current = Create(TypeName, parameters.Attrs, Parent, Root);
                    if (Parent.Target.GetType().Name.StartsWith("List"))
                    {
                        dynamic collection = Parent.Target;
                        collection.Add(current);
                        return current;
                    }
                    else
                    {
                        throw new Exception("Свойство " + TypeName + " не определено в типе " + Parent.Target.GetType().Name);
                    }

                }
            }
            else
            {
                object current = Create(TypeName, parameters.Attrs, Parent, Root);
                return current;
            }
        }catch(Exception ex)
        {
            throw new Exception($"Ошибка: {ex.Message}"+Formating.ToJson(parameters) ,ex);
        }
    }


    /// <summary>
    /// Получение значения из свойства с указанным именем
    /// </summary>
    /// <param name="i"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    public object GetValue(object i, string v)
    {
        PropertyInfo propertyInfo = i.GetType().GetProperty(v);
        FieldInfo fieldInfo = i.GetType().GetField(v);
        return
            fieldInfo != null ? fieldInfo.GetValue(i) :
            propertyInfo != null ? propertyInfo.GetValue(i) :
            null;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="PropertyName"></param>
    /// <param name="Attrs"></param>
    /// <param name="Parent"></param>
    /// <returns></returns>
    private object Create(string PropertyName, Dictionary<string, string> Attrs, ComponentModel Parent, global::ReportItem Root)
    {
        
        Type type = FindTypeForShortName(PropertyName);
        if (type == null)
        {
            throw new Exception("Не найден класс с именем " + PropertyName);
        }
        else
        {            
            object Target = ReflectionService.CreateWithDefaultConstructor<object>(type);
            Target = Apply(Target, Attrs, Parent, Root);
            return Target;
        }
        throw new Exception("Не найден класс с именем " + PropertyName);
    }


    /// <summary>
    /// Поиск типа в сборках звестных приложению
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    private Type FindTypeForShortName(string typeName)
    {
        foreach(var mod in imported)
        {
            Type t = (from p in mod.GetTypes() where p.Name == typeName select p).FirstOrDefault();         
            if (t != null)
            {
                return t;
            }
        }
        return null;      
    }

     
    /// <summary>
    /// Создание предварительных параметров связывания
    /// </summary>
    /// <param name="target"></param>
    /// <param name="attrs"></param>
    /// <param name="parent"></param>
    private static object Apply(object target, Dictionary<string, string> attrs, ComponentModel parent, ReportItem Root)
    {
        if(attrs != null)
        {
            
            if (target is ViewItem)
            {
                ((ViewItem)target).Bindings = attrs.Expect(  "name", "id", "Name", "Id");
                //((ViewItem)target).Init();
                ((ViewItem)target).Compile();
            }









            
            /*
            if (target.GetType().Name == nameof(AgregatedDataSet))
            {
                target.GetType().GetProperty("TableName").SetValue(target, attrs["TableName"]);
            }
            
            if (target.GetType().Name == "OdbcDataSource")
            {
                OdbcDataSource ds = ((OdbcDataSource)target);
                ds.Alias = attrs["Alias"];
                ds.connectionString = attrs["ConnectionString"];

            }
            if (target.GetType().Name == "DataTable")
            {
                string TableName = attrs["TableName"];
                string DataSource = attrs["DataSource"];
                object pds = (from p in Root.DataSources where ((OdbcDataSource)p).Alias == DataSource select p).FirstOrDefault();
                OdbcDataSource ds = ((OdbcDataSource)pds);
                System.Data.DataTable table = ds.CreateDataTable("select * from "+ TableName);
                table.TableName = TableName;
                return table;
            }
            if ( target.GetType().Name=="DataList" )
            {
                int x = 0;
                string dataset = attrs["Dataset"];
                string bind = attrs["Bind"];
                object table = (from p in Root.DataSets where ((DataTable)p).TableName == dataset select p).FirstOrDefault();
                if(table is AgregatedDataSet)
                {
                    ((DataList)target).Dataset = ((AgregatedDataSet)table).GetData();
                    ((DataList)target).Bindings = JsonConvert.DeserializeObject<Dictionary<string, string>>(bind);
                }
                else
                {
                    System.Data.DataTable dataTable = ((DataTable)table);
                    JArray jarray = convert(dataTable);
                    ((DataList)target).Dataset = jarray;
                    ((DataList)target).Bindings = JsonConvert.DeserializeObject<Dictionary<string, string>>(bind);
                }
            }*/
        }


        
        return target;
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataTable"></param>
    /// <returns></returns>
    public static JArray convert(System.Data.DataTable dataTable)
    {
        Dictionary<string, object> resultSet = new Dictionary<string, object>();
        List<Dictionary<string, object>> listRow = new List<Dictionary<string, object>>();
        foreach (DataRow row in dataTable.Rows)
        {
            Dictionary<string, object> rowSet = new Dictionary<string, object>();
            foreach (DataColumn column in dataTable.Columns)
            {
                rowSet[column.Caption] = row[column.Caption];
            }
            listRow.Add(rowSet);
        }
        resultSet["rows"] = listRow;

        JObject jrs = JObject.FromObject(resultSet);
        return (JArray)jrs["rows"];
    }
}

