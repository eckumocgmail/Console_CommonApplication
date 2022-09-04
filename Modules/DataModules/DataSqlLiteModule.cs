using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Collections.Generic;
using System.IO;

/// <summary>
/// Регистрирует соединение SQLServer для контекста данных
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class DataSqlLiteModule<TDbContext>: DatabaseModule<TDbContext> where TDbContext : DbContext
{ 
    protected string _filepath;

    public DataSqlLiteModule() : this("AppDb") { }
    public DataSqlLiteModule(string filepath ="AppDb")
    {
        CurrentType = typeof(DataSqlServerModule<TDbContext>);
        _filepath = typeof(TDbContext).GetNameOfType().ToKebabStyle()+".db";  
    } 

    protected  override void ConfigureDbContext(DbContextOptionsBuilder builder)
    {
        if(builder.IsConfigured == false)
            builder.UseFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data", typeof(AnaliticsDataModel).GetNameOfType().ToKebabStyle() + ".db"));
    }
}
public class DataSqlLiteModuleTest : TestingElement
{
    public override List<string> OnTest()
    {
        var host = new TestCommonApplication().Build<DataSqlLiteModule<BaseDbContext>>();
        using (var scope = host.Services.CreateScope())
        {
            var data = scope.ServiceProvider.GetService<BaseDbContext>();
            if (data == null)
                Messages.Add("Модуль данных SqlLite не корректно работает");
            else Messages.Add("Модуль данных SqlLite работает корректно");
        }
        return Messages;
    }
}