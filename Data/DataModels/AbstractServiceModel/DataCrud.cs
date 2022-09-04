using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

public interface IDataCrud<TModel> where TModel : BaseEntity
{

    Task<List<TModel>> GetAll();
    Task<TModel> Get(int ID);
    Task<TModel> Find(int ID);
    Task<TModel> Find(string key, object value);
    Task<int> Remove(int ID);
    Task<int> Update(TModel Item);
    Task<int> Create(TModel Item);
}





public interface IDataCrud
{
    int Count(string entity);
    void Create(object target);
    void Delete(object target);
    object Find(string entity, int id);
    HashSet<string> GetKeywords(string entity, string query);
    object[] List(string entity);
    object[] List(string entity, int page, int size);
    IQueryable<dynamic> Page(IQueryable<dynamic> items, int page, int size);
    dynamic Page(string entity, int page, int size);
    int PagesCount(string entity, int size);
    void Update(string name, object targetData);
    object Where(string entity, string expression);
    object Where(string entity, string key, object value);
}


public class DataCrud : IDataCrud
{
    private readonly IDbContext _db;

    public DataCrud(IDbContext db)
    {
        _db = db;
    }
    
    public IDictionary<string,int> Statistics()
    {
        Dictionary<string, int> res = new Dictionary<string, int>();
        foreach (var entity in _db.GetEntityTypes<BaseEntity>())
        {
            res[entity.GetTypeName()] = Count(entity.GetTypeName());            
        }
        return res;
    }












    public int Count(string entity)
    {
        return (from p in ((IQueryable<dynamic>)GetDbSet(_db, entity)) select p).Count();
    }

    public int PagesCount(string entity, int size)
    {
        int c = this.Count(entity);
        return ((c % size) == 0) ? ((int)(c / size)) : (1 + ((int)((c - ((c % size))) / size)));
    }

    public dynamic Page(string entity, int page, int size)
    {
        return (from p in ((IQueryable<dynamic>)GetDbSet(_db, entity)) select p).Skip((page - 1) * size).Take(size).ToList();
    }

    public void Create(object target)
    {
        _db.GetDbSet(target.GetType().GetNameOfType()).Add(target);
        _db.SaveChanges();
    }

    public object[] List(string entity)
    {
        return (from p in ((IQueryable<dynamic>)GetDbSet(_db, entity)) select p).ToArray<object>();
    }

    public object[] List(string entity, int page, int size)
    {
        return (from p in ((IQueryable<dynamic>)GetDbSet(_db, entity)) select p).Skip((page - 1) * size).Take(size).ToArray<object>();
    }

    private object GetDbSet(object db, string entityTypeShortName)
    {
        DbContext _context = (DbContext)db;
        foreach (MethodInfo info in _context.GetType().GetMethods())
        {
            if (info.Name.StartsWith("get_") == true && info.ReturnType.Name.StartsWith("DbSet"))
            {
                if (info.Name.IndexOf("MigrationHistory") == -1)
                {

                    string displayName = info.ReturnType.ShortDisplayName();
                    string entityTypeName = displayName.Substring(displayName.IndexOf("<") + 1);
                    entityTypeName = entityTypeName.Substring(0, entityTypeName.IndexOf(">"));
                    //Api.Utils.Info("Ищем " + entityTypeShortName + " в контексте данных. ");
                    //Api.Utils.Info(" проверяем " + entityTypeName + " является ли " + entityTypeShortName + "? ");
                    if (entityTypeShortName == entityTypeName)
                    {
                      
                        return (dynamic)info.Invoke(_context, new object[0]);
                    } 
                }

            }
        }
        db.Warn("Набор данных " + entityTypeShortName + " не найден в " + db.GetTypeName());
        throw new Exception("Набор данных " + entityTypeShortName + " не найден в " + db.GetTypeName());
    }

    public object Find(string entity, int id)
    {
        return _db.GetDbSet(entity).Find(id);
    }

    public object Where(string entity, string expression)
    {
        return (from p in ((IQueryable<BaseEntity>)(GetDbSet(_db,entity))) select p).ToList();
    }
    public object Where(string entity, string key, object value)
    {
        return (from p in ((IQueryable<BaseEntity>)(GetDbSet(_db,entity))) where p.GetValue(key) == value select p).ToList();
    }

    public void Update(string name, object targetData)
    {
        object targetInstance = Find(name, ((dynamic)targetData).ID);
        foreach (PropertyInfo propertyInfo in targetInstance.GetType().GetProperties())
        {
            if (TypeUtils.IsPrimitive(propertyInfo.PropertyType))
            {
                propertyInfo.SetValue(targetInstance, propertyInfo.GetValue(targetData));
            }
        }
        _db.SaveChanges();
    }

    public void Delete(object target)
    {
        //GetDbSet(_db,target.GetType().GetNameOfType()).Remove(target);

        _db.SaveChanges();
    }


 
    public dynamic GetDbSet (DbContext db, string name) 
    {
        return null;
    }










    public IQueryable<dynamic> Page(IQueryable<dynamic> items, int page, int size)
    {
        return items.Skip((page - 1) * size).Take(size);
    }

    public HashSet<string> GetKeywords(string entity, string query)
    {

        IQueryable<object> q = ((IQueryable<object>)(_db.GetDbSet(entity)));

        HashSet<string> keywords = GetKeywords(q, entity, query);
        return keywords;
    }

    private HashSet<string> GetKeywords(IQueryable<object> q, string entity, string query)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    /* public JArray Search(string entity, string query)
     {

         DatabaseManager dbm = _db.GetDatabaseManager();
         TableManager tm = dbm.fasade[Counting.GetMultiCountName(entity)];


         return tm.Search(GetIndexes(entity), query);
     }*/

    private object GetValue(object i, string v)
    {
        PropertyInfo propertyInfo = i.GetType().GetProperty(v);
        FieldInfo fieldInfo = i.GetType().GetField(v);
        return
            fieldInfo != null ? fieldInfo.GetValue(i) :
            propertyInfo != null ? propertyInfo.GetValue(i) :
            null;
    }

 
}


 