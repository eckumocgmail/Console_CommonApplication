using Microsoft.Extensions.DependencyInjection;


namespace DataConverter.Generators
{
    public static class GeneratorsServiceCollectionExtensions
    {

        public static IServiceCollection AddCodeGenerators( this IServiceCollection services)
        {
            services.AddScoped<ControllerGenerator>();
            services.AddScoped<DbcontextGenerator>();
            services.AddScoped<ModelGenerator>();
            services.AddScoped<RepositoryGenerator>();
            services.AddScoped<TableGenerator>();
            services.AddScoped<WebapiGenerator>();
            return services;
        }
    }
}
