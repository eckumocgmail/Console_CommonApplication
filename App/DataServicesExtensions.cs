
using ApplicationCore.Converter;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;

using static Api.Utils;



/// <summary>
/// 
/// </summary>
public static class Extensions2
{


    public static void AddUserServices(IWebHostBuilder webBuilder)
    {
        webBuilder.LogActionInfo();

        webBuilder.ConfigureServices(services => services.AddTransient<IEmailService, UserEmailService>());
        webBuilder.ConfigureServices(services => services.AddTransient<ITokenStorage, FileTokenStorage>());
        webBuilder.ConfigureServices(services => services.AddTransient<IUserNotificationsService, UserNotificationsService>());




    }

    public static void AddBusinessServiceModel(IWebHostBuilder webBuilder)
    {
        webBuilder.ConfigureServices(services => services.AddFileDatabase<BusinessDataModel>());
        webBuilder.AddEntityFasade<BusinessResource, BusinessDataModel>();
    }

    public static void AddAppDbContext(IWebHostBuilder webBuilder)
    {
        webBuilder.ConfigureServices(services => services.AddFileDatabase<AppDbContext>());
    }

    public static void AddAuthorizationServiceModel(IWebHostBuilder webBuilder)
    {
        webBuilder.ConfigureServices(services => services.AddFileDatabase<AuthorizationDataModel>());
        webBuilder.ConfigureServices(services => services.AddScoped<ReCaptchaService>());
        AddFilesServiceModel(webBuilder);
        webBuilder.AddEntityFasade<UserMessage, AuthorizationDataModel>();
        webBuilder.AddEntityFasade<UserGroups, AuthorizationDataModel>();
        webBuilder.AddEntityFasade<UserAccount, AuthorizationDataModel>();
    }

    public static void AddAnaliticsServiceModel(IWebHostBuilder webBuilder)
    {
        webBuilder.ConfigureServices(services => AddAnaliticsServices(services));
    }

    public static void AddAnaliticsServices(IServiceCollection services)
    {
        services.AddFileDatabase<AnaliticsDataModel>();
    }

    public static void AddManagmentServiceModel(IWebHostBuilder webBuilder)
    {
        webBuilder.ConfigureServices(services => AddManagmentServices(services));
    }

    public static void AddManagmentServices(IServiceCollection services)
    {
        services.AddFileDatabase<ManagmentDataModel>();
    }

    public static void AddMarketServiceModel(IWebHostBuilder webBuilder)
    {
        webBuilder.ConfigureServices(services => AddMarketServices(services));
    }

    public static void AddMarketServices(IServiceCollection services)
    {
        services.AddFileDatabase<MarketDataModel>();
    }

    public static void AddMedicalServiceModel(IWebHostBuilder webBuilder)
    {
        webBuilder.ConfigureServices(services => services.AddFileDatabase<MedicalDataModel>());
    }

    public static void AddCustomerServiceModel(IWebHostBuilder webBuilder)
    {
        webBuilder.ConfigureServices(services => services.AddFileDatabase<CustomerDataModel>());
    }

    public static void AddDeployServiceModel(IWebHostBuilder webBuilder)
    {
        webBuilder.ConfigureServices(services => services.AddFileDatabase<DeployDataModel>());
    }

    public static void AddFilesServiceModel(IWebHostBuilder webBuilder)
    {
        webBuilder.ConfigureServices(services =>
            services.AddFileDatabase<FilesDataModel>());

        webBuilder.AddEntityFasade<FileCatalog, FilesDataModel>();
        webBuilder.AddEntityFasade<TextResource, FilesDataModel>();
        webBuilder.AddEntityFasade<AudioResource, FilesDataModel>();
        webBuilder.AddEntityFasade<VideoResource, FilesDataModel>();
        webBuilder.AddEntityFasade<PhotoResource, FilesDataModel>();
    }
}

/// <summary>
/// 
/// </summary>
public static class ProgramExtensions
{

    public static void AddEntityFasade<Entity, Context>(this IWebHostBuilder builder)
        where Entity : BaseEntity
        where Context : IDbContext
    {
        builder.ConfigureServices(services => services.AddScoped(typeof(IEntityFasade<Entity>), sp =>
               new EntityFasade<Entity>(sp.GetService<Context>())));
        //typeof(Entity).IsExtendsFrom()
    }

    public static void AddConfiguration<Options>(this IWebHostBuilder builder)
        where Options : class
    {
        builder.ConfigureServices((context, services) =>
            services.AddScoped(typeof(Options),
            sp =>
                context.Configuration.GetSection(typeof(Options).GetNameOfType()).Get<Options>()
            )
        );

    }


  

    private static void Start(Action<object> p, string[] args)
    {
        throw new NotImplementedException($"{typeof(DataServicesExtensions).GetTypeName()}");
    }
}
