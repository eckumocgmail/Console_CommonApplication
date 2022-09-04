 

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Collections.Generic;

/// <summary>
/// Модуль сегмента данных. Тип модулей выполняющих регистрацию контекста данных EntityFramework
/// </summary>
/// <typeparam name="TDbContext">Тип контекста данных</typeparam>
[Icon("")]
[Label("")]
[Description("")]
public abstract class DatabaseModule<TDbContext>: Module where TDbContext : DbContext
{
    public  DatabaseModule()
    {
        CurrentType = typeof(DatabaseModule<TDbContext>);
    }
     

    /// <summary>
    /// Настройка соединения СУБД с контекстом данных
    /// </summary>        
    protected  abstract void ConfigureDbContext(DbContextOptionsBuilder builder);


    /// <summary>
    /// Регистрация сервиса
    /// </summary>        
    public override void OnConfigureServices(IServiceCollection services)
    {
        this.Info($"OnConfigureServices()");        
        FactoryUtils.Get().AddDataModel(typeof(TDbContext));
        services.AddDbContext<TDbContext>(ConfigureDbContext);
    }


    /// <summary>
    /// Опускаем компоненты промежуточного ПО
    /// </summary>        
    public override void OnConfigureMiddleware(IApplicationBuilder app)
    {
        this.Info($"OnConfigureMiddleware()");
    }
}

public class DataModuleUnit : TestingUnit
{
    public DataModuleUnit(TestingUnit p):base(p)
    {
        Push(new DataInMemoryModuleTest());
        Push(new DataMysqlModuleTest());
        Push(new DataOracleModuleTest());
        Push(new DataPostgreSqlModuleTest());
        Push(new DataSqlLiteModuleTest());
        Push(new DataSqlServerModuleTest());
    }
}