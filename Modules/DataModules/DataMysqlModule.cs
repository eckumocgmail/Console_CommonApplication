using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Регистрирует соединение MYSQL для контекста данных
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class DataMysqlModule<TDbContext> : DatabaseModule<TDbContext> where TDbContext : DbContext
{
    protected string _host;
    protected int _port;
    protected string _database;
    protected string _username;
    protected string _password;

    public DbContextOptionsBuilder _mysqlBuilder;

    public DataMysqlModule(string host, int port, string database, string username, string password)
    {
        CurrentType = typeof(DataMysqlModule<TDbContext>);
        _host = host;
        _port = port;
        _database = database;
        _username = username;
        _password = password; 
    }
        

    protected  override void ConfigureDbContext(DbContextOptionsBuilder builder)
    {
        //_mysqlBuilder = builder.UseMySql($"server={_host};port={_port};database={_database};user={_username};password={_password};", ConfigureMySql);
        _mysqlBuilder.EnableSensitiveDataLogging();
        _mysqlBuilder.EnableDetailedErrors();
    }

    private void ConfigureMySql(MySqlDbContextOptionsBuilder mySqlOptions)
    {
        //mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend);
    }
}



public class DataMysqlModuleTest : TestingElement
{
    public override List<string> OnTest()
    {
        var host = new TestCommonApplication().Build<DataMysqlModule<BaseDbContext>>();
        using (var scope = host.Services.CreateScope())
        {
            var data = scope.ServiceProvider.GetService<BaseDbContext>();
            if (data == null)
                Messages.Add("Модуль данных Mysql не корректно работает");
            else Messages.Add("Модуль данных Mysql работает корректно");
        }
        return Messages;
    }
}