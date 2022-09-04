using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

 
using static System.Console;
using static Newtonsoft.Json.JsonConvert;
 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json.Linq;

public static class HttpExtensions
{
    public static object CopyData(this object named, object data)
    {
        named.GetType().GetProperties().ToList().ForEach(p => data.GetType().GetProperties().Where(namedProp => namedProp.Name == p.Name).First().SetValue(named, p.GetValue(data)));
        return named;
    }
}


public interface IUnitOfWork : IEntityFasade<BaseEntity>
{

}
public interface IEntityFasade
{
    JArray SelectAll();
}
public interface IEntityFasade<TEntity> where TEntity : BaseEntity
{
    void Configure(EntityTypeBuilder<TEntity> builder);
    int Count(string entity);
    int Create(params TEntity[] items);
    Task<int> Create(TEntity model);
    Task<int> CreateAsync(params TEntity[] items);
    Task<int> Delete(int id);
    Task<TEntity> Find(int id);
    IEnumerable<TEntity> Get(params int[] ids);
    IEnumerable<TEntity> GetAll();
    DbSet<TEntity> GetDbSet();
    IEnumerable<string> GetOptions(string query);
    IEnumerable<TEntity> GetPage(int page, int size);
    IEnumerable<TEntity> GetPage(int[] ids, int page, int size);
    Task<TEntity[]> List();
    Task<TEntity[]> Page(int page, int size);
    Task<TEntity[]> Page(int page, int size, params string[] sorting);
    int Remove(params int[] ids);
    IEnumerable<TEntity> Search(string query);
    IEnumerable<object> SearchColumnsInPropertiesPage(string query, string[] properties, string[] columns, int page, int size);
    IEnumerable<object> SearchInProperties(string query, string[] properties);
    IEnumerable<object> SearchInPropertiesPage(string query, string[] properties, int page, int size);
    IEnumerable<TEntity> SearchPage(string query, int page, int size);
    int TotalPages(string query, int size);
    int TotalResults(string query);
    int Update(params TEntity[] items);
    Task<int> Update(TEntity model);
}
/// <summary>
/// 
/// </summary>
/// <typeparam name="TEntity"></typeparam>

public class EntityFasade<TEntity> :  IEntityFasade<TEntity>
    where TEntity : BaseEntity
{

    protected IDbContext _context;
    public DbSet<TEntity> _dbSet;

    public EntityFasade(IDbContext context)
    {
        _context = context;
        if ((_dbSet=GetDbSet()) == null)
            throw new Exception("Сущность " + nameof(TEntity) + " не определена в констексте " + context.GetType().Name);
    }


    /// <summary>
    /// Добавление записей в таблицу
    /// </summary>
    public int Create(params TEntity[] items)
    {
        this.Info($"Create({items.ToJson()})...");

        foreach (var item in items)        
            GetDbSet().Add(item);        
        int result = _context.SaveChanges();
        return result;
    }


    /// <summary>
    /// Добавление записей в таблицу
    /// </summary>
    public async Task<int> CreateAsync(params TEntity[] items)
    {
        this.Info($"Create({items.ToJson()})...");

        foreach (var item in items)        
            GetDbSet().Add(item);        
        int result = await _context.SaveChangesAsync();
        return result;
    }

    public IEnumerable<TEntity> Get(params int[] ids)
        => GetDbSet().Where(item => ids.Contains(int.Parse(item.GetType().GetProperty("ID").ToString())));

    public IEnumerable<TEntity> GetPage(int[] ids, int page, int size)
        => GetDbSet().Where(item => ids.Contains(int.Parse(item.GetType().GetProperty("ID").ToString()))).Skip((page - 1) * size).Take(size);

    public IEnumerable<TEntity> GetAll() => GetDbSet();

    public IEnumerable<TEntity> GetPage(int page, int size) => GetDbSet().Skip((page - 1) * size).Take(size);

    public int Remove(params int[] ids)
    {
        Get(ids).ToList( ).ForEach(item => GetDbSet().Remove(item));
        return _context.SaveChanges();
    }

    public int Update(params TEntity[] items)
    {
        foreach (var item in items)
            GetDbSet().Update(item);
        return _context.SaveChanges();
    }


    //TODO: нужно реализовать разбаение по словам
    public IEnumerable<TEntity> Search(string query)
    {
        List<TEntity> result = new List<TEntity>();
        GetDbSet().ToList().ForEach(item =>
        {
            string json = SerializeObject(item);
            if (json.ToLower().Contains(query.ToLower()))
            {
                result.Add(item);
            }
        });

        return result;
    }



    public IEnumerable<TEntity> SearchPage(string query, int page, int size)
    {
        List<TEntity> result = new List<TEntity>();

        GetDbSet().ToList().ForEach(item =>
        {
            if (String.IsNullOrEmpty(query) || SerializeObject(item).Contains(query))
            {
                result.Add(item);
            }
        });

        WriteLine(SerializeObject(result.Skip((page - 1) * size).Take(size).ToArray()));
        return result.Skip((page - 1) * size).Take(size).ToArray();
    }

    public IEnumerable<object> SearchColumnsInPropertiesPage(string query, string[] properties, string[] columns, int page, int size)
        => SearchInPropertiesPage(query, properties, page, size).Select(next => next.SelectProperties(columns));


    


    public IEnumerable<object> SearchInPropertiesPage(string query, string[] properties, int page, int size)
        => GetDbSet().Select(item => item.ToDictionary().Where(kv => properties.Contains(kv.Key))).Skip((page - 1) * size).Take(size);

    public IEnumerable<object> SearchInProperties(string query, string[] properties)
        => GetDbSet().Select(item => item.ToDictionary()).Where(dic => SerializeObject(dic.Values).ToLower().Contains(query.ToLower()));

    public int TotalPages(string query, int size)
    {
        List<TEntity> result = new List<TEntity>();
        GetDbSet().ToList().ForEach(item =>
        {
            if (String.IsNullOrEmpty(query) || SerializeObject(item).Contains(query))
            {
                result.Add(item);
            }
        });
        return 1 + (int)Math.Floor((decimal)result.Count() / size);
    }

    public interface IKeywordsParserService
    {
        public IDictionary<string, int> ParseKeywords(string Resource);
    }
    public class StupidKeywordsParserService : IKeywordsParserService
    {


        private IDictionary<string, int> keywords = new Dictionary<string, int>();

        public StupidKeywordsParserService()
        {
        }

        public IDictionary<string, int> ParseKeywords(string Resource)
        {
            var statisticsForThisRecord = new Dictionary<string, int>();
            foreach (string text in SplitWords(Resource))
            {
                string word = text.ToUpper();
                if (keywords.ContainsKey(word))
                {
                    keywords[word]++;
                }
                else
                {
                    keywords[word] = 1;
                }

                if (statisticsForThisRecord.ContainsKey(word))
                {
                    statisticsForThisRecord[word]++;
                }
                else
                {
                    statisticsForThisRecord[word] = 1;
                }
            }
            return statisticsForThisRecord;
        }

        private IEnumerable<string> SplitWords(string resource)
        {
            var words = new List<string>();
            string word = "";
            foreach (char ch in resource.ToCharArray())
            {
                if ((ch + "").IsEng() || (ch + "").IsRus())
                {
                    word += ch;
                }
                else
                {
                    if (String.IsNullOrEmpty(word) == false)
                    {
                        words.Add(word);
                    }
                    word = "";
                }
            }
            if (String.IsNullOrEmpty(word) == false)
            {
                words.Add(word);
            }

            return words;
        }
    }


    public int TotalResults(string query)
    {
        List<TEntity> result = new List<TEntity>();
        GetDbSet().ToList().ForEach(item =>
        {
            if (String.IsNullOrEmpty(query) || SerializeObject(item).Contains(query))
            {
                result.Add(item);
            }
        });
        return result.Count();
    }

    public IEnumerable<string> GetOptions(string query)
    {
        HashSet<string> result = new HashSet<string>();
        GetDbSet().ToList().ForEach(item =>
        {

            GetKeywords(item).ToList().ForEach(i => result.Add(i));

        });
        return result;
    }

    private IEnumerable<string> GetKeywords(TEntity item)
    {

        return new StupidKeywordsParserService().ParseKeywords(SerializeObject(item)).Keys;
    }

    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
       
    }

    public DbSet<TEntity> GetDataSet() => this.GetDbSet();

  

    public DbSet<TEntity> GetDbSet()
    {
        return ((DbContext)_context).Set<TEntity>();
    }

    public int Count(string entity) => _dbSet.Count();

    public Task<int> Create(TEntity model)
    {
        _dbSet.Add(model);
        return _context.SaveChangesAsync();
    }

    public Task<int> Delete(int id)
    {
        _dbSet.Remove(_dbSet.Find(id));
        return _context.SaveChangesAsync();
    }

    public async Task<TEntity> Find(int id) =>await  _dbSet.FindAsync(id);

    public Task<TEntity[]> List()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public async Task<TEntity[]> Page(int page, int size)
    {
        var result =_dbSet.GetPage(page, size).ToArray();
        await Task.CompletedTask;
        return result;
    }

    public async Task<TEntity[]> Page(int page, int size, params string[] sorting)
    {
        var p = _dbSet.AsQueryable();
        foreach(var sort in sorting)
        {
            //TODO
        }
        var result = p
            .GetPage(page, size).ToArray();
        await Task.CompletedTask;
        return result;
    }

    public Task<int> Update(TEntity model)
    {
        var target = _dbSet.Find(model.ID);

        target.CopyData(model);
        return _context.SaveChangesAsync();
    }
}
public static class WebAppExtensions
{
    public static T GetService<T>(this WebApplication app, IServiceProvider sp)
    {
        return (T)sp.GetService(typeof(T));
    }
}

public class WebApplication
{
}