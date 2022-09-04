using DataConverter.Generators;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
 
public static class DataConvertersExtension
{
    public static IServiceCollection AddDataConverters(this IServiceCollection services)
    {
        services.AddScoped<ModelConverter>();
        services.AddScoped<MyApplicationModelController>();
        return services;
    }

}
 