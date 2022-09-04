using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Collections.Generic;

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class DataInMemoryModule<TDbContext> : DatabaseModule<TDbContext> where TDbContext : DbContext
{
    public DataInMemoryModule()
    {
        CurrentType = typeof(DataInMemoryModule<TDbContext>);
    }

    protected  override void ConfigureDbContext(DbContextOptionsBuilder builder)
    {
        builder.UseInMemoryDatabase(typeof(TDbContext).Name);
    }
}


public class DataInMemoryModuleTest: TestingElement
{
    public override List<string> OnTest()
    {
        var host = new TestCommonApplication().Build<DataInMemoryModule<BaseDbContext>>();
        using(var scope = host.Services.CreateScope())
        {
            var data = scope.ServiceProvider.GetService<BaseDbContext>();
            if (data == null)
                Messages.Add("Модуль данных в общей памяти не корректно работает");
            else Messages.Add("Модуль данных в общей памяти работает корректно");
        }
        return Messages;
    }
}