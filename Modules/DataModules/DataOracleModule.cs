using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/// <summary>
/// Регистрирует соединение Oracle для контекста данных
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class DataOracleModule<TDbContext> : DatabaseModule<TDbContext> where TDbContext : DbContext
{
    protected string _datasource;
    protected string _username;
    protected string _password;
        
    public DataOracleModule(string datasource, string username, string password)
    {
        CurrentType = typeof(DataOracleModule<TDbContext>);
        _datasource = datasource;
        _username = username;
        _password = password;
    }

    public override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
    }

    protected  override void ConfigureDbContext(DbContextOptionsBuilder builder)
    {
        //builder.UseOracle($@"User Id={_username};Password={_password};DataSource={_datasource};");
    }
}



public class DataOracleModuleTest : TestingElement
{
    public override List<string> OnTest()
    {
        var host = new TestCommonApplication().Build<DataOracleModule<BaseDbContext>>();
        using (var scope = host.Services.CreateScope())
        {
            var data = scope.ServiceProvider.GetService<BaseDbContext>();
            if (data == null)
                Messages.Add("Модуль данных Oracle не корректно работает");
            else Messages.Add("Модуль данных Oracle работает корректно");
        }
        return Messages;
    }
}