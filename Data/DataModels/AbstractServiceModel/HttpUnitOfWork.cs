using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class HttpUnitOfWork<T>: IEntityFasade<T> where T : BaseEntity
{
    private readonly HttpClient _http;
    private readonly string _url;
    private readonly ServiceCertificate _certificate;

    public HttpUnitOfWork( HttpClient http, string url, ServiceCertificate certificate )
    {
        this._http = http;
        this._url = url;
        this._certificate = certificate;
    }

    public void Configure(EntityTypeBuilder<T> builder)
    {
        throw new System.NotImplementedException();
    }

    public int Count(string entity)
    {
        string url = $"{_url}/Count?entity={entity}";
        var response = _http.GetAsync(url).Result;
        response.EnsureSuccessStatusCode();
        string json = response.Content.ReadAsStringAsync().Result;
        return int.Parse(json);
    }

    public int Create(params T[] items)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> Create(T model)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> CreateAsync(params T[] items)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> Delete(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task<T> Find(int id)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<T> Get(params int[] ids)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<T> GetAll()
    {
        throw new System.NotImplementedException();
    }

    public DbSet<T> GetDataSet()
    {
        throw new System.NotImplementedException();
    }

    public DbSet<T> GetDbSet()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<string> GetOptions(string query)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<T> GetPage(int page, int size)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<T> GetPage(int[] ids, int page, int size)
    {
        throw new System.NotImplementedException();
    }

    public Task<T[]> List()
    {
        throw new System.NotImplementedException();
    }

    public Task<T[]> Page(int page, int size)
    {
        throw new System.NotImplementedException();
    }

    public Task<T[]> Page(int page, int size, params string[] sorting)
    {
        throw new System.NotImplementedException();
    }

    public int Remove(params int[] ids)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<T> Search(string query)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<object> SearchColumnsInPropertiesPage(string query, string[] properties, string[] columns, int page, int size)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<object> SearchInProperties(string query, string[] properties)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<object> SearchInPropertiesPage(string query, string[] properties, int page, int size)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<T> SearchPage(string query, int page, int size)
    {
        throw new System.NotImplementedException();
    }

    public int TotalPages(string query, int size)
    {
        throw new System.NotImplementedException();
    }

    public int TotalResults(string query)
    {
        throw new System.NotImplementedException();
    }

    public int Update(params T[] items)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> Update(T model)
    {
        throw new System.NotImplementedException();
    }
}
