using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Collections.Generic;

/// <summary>
/// Регистрирует соединение SQLServer для контекста данных
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class DataSqlServerModule<TDbContext>: DatabaseModule<TDbContext> where TDbContext : DbContext
{
    protected string _instance;
    protected string _database;
    protected bool _trusted;
    protected string _username;
    protected string _password;

    public DataSqlServerModule(string instance="AGENT\\KILLER", string database="tempdb")
    {
        CurrentType = typeof(DataSqlServerModule<TDbContext>);
        _instance = instance;
        _database = typeof(TDbContext).Name;
        _trusted = true;
    }

    public DataSqlServerModule(string instance, string database, string username, string password )
    {
        _instance = instance;
        _database = typeof(TDbContext).Name;
        _trusted = false;
        _username = username;
        _password = password;
        
    }

    protected  override void ConfigureDbContext(DbContextOptionsBuilder builder)
    {
        if(builder.IsConfigured == false)
        {

            if (_trusted)
            {
                string connectionString = $@"Server={_instance};Database={_database};Trusted_Connection=True;MultipleActiveResultSets=true;";
                builder.UseSqlServer(connectionString);
            }
            else
            {

                string connectionString = $@"Server={_instance};Database={_database};user id={_username};password={_password};MultipleActiveResultSets=true;";
                builder.UseSqlServer(connectionString);
            }
        }


    }
}

public class DataSqlServerModuleTest : TestingElement
{
    public override List<string> OnTest()
    {
        var host = new TestCommonApplication().Build<DataSqlServerModule<BaseDbContext>>();
        using (var scope = host.Services.CreateScope())
        {
            var data = scope.ServiceProvider.GetService<BaseDbContext>();
            if (data == null)
                Messages.Add("Модуль данных SqlServer не корректно работает");
            else Messages.Add("Модуль данных SqlServer работает корректно");
        }
        return Messages;
    }
}