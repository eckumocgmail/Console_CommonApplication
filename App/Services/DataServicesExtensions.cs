 
 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCoreConstructorAngular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

public static class DataServicesExtensions
{

    public static IServiceCollection AddSqlDataContext<T>(this IServiceCollection services, string connectionString) where T: DbContext
    {                
        services.AddDbContext<T>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        return services;
    }
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
     

        services.AddTransient<DataControl>();
        services.AddTransient<DataValidationService>();
        services.AddScoped<UserBusinessResourcesService>();
        services.AddScoped<UserGroupsService>();

        services.AddDataConverters();
        services.AddScoped<ActionService>();
         
        services.AddSqlDataContext<AuthorizationDataModel>(AuthorizationDataModel.DEFAULT_CONNECTION_STRING);
        return services;
    }
}