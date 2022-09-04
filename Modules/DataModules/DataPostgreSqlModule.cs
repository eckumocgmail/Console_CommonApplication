using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Collections.Generic;

/// <summary>
/// Регистрирует соединение PGSQL для контекста данных
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class DataPostgreSqlModule<TDbContext> : DatabaseModule<TDbContext> where TDbContext : DbContext
{
    protected string _host;
    protected int _port;
    protected string _database;
    protected string _username;
    protected string _password;
    //private DbContextOptionsBuilder _pgsqlBuilder;


    public DataPostgreSqlModule(string host="127.0.0.1", int port=5432, string database="db", string username="postgres", string password="sgdf1423")
    {
        CurrentType = typeof(DataPostgreSqlModule<TDbContext>);
        _host = host;
        _port = port;
        _database = database;
        _username = username;
        _password = password;
    }

   
    protected  override void ConfigureDbContext(DbContextOptionsBuilder builder)
    {
        //_pgsqlBuilder = builder.UseNpgsql($"Host={_host};Port={_port};Database={_database};Username={_username};Password={_password}");            
    } 
}


public class DataPostgreSqlModuleTest : TestingElement
{
    public override List<string> OnTest()
    {
        var host = new TestCommonApplication().Build<DataPostgreSqlModule<BaseDbContext>>();
        using (var scope = host.Services.CreateScope())
        {
            var data = scope.ServiceProvider.GetService<BaseDbContext>();
            if (data == null)
                Messages.Add("Модуль данных PostgreSql не корректно работает");
            else Messages.Add("Модуль данных PostgreSql работает корректно");
        }
        return Messages;
    }
}