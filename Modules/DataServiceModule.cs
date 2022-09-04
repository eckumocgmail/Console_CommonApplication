
using DataEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IDataServiceModule
{
    void ConfigureServices(IConfiguration configuration, IServiceCollection services);
}


public class DataServiceModule : IServiceModule, IDataServiceModule
{
    ILogger<DataServiceModule> Logger = OverrideLogging.GetLogger<DataServiceModule>();
    public void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        Logger.LogInformation($"ConfigureServices(..)");
        string DefaultConnectionString = configuration.GetConnectionString("DefaultConnection");

        Logger.LogInformation($"DefaultConnection = {DefaultConnectionString}");
        services.AddDbContext<CatalogDataModel>(options => options.UseSqlite(DefaultConnectionString));
        services.AddScoped(typeof(DbContext), sp => sp.GetService<CatalogDataModel>());

    }
}