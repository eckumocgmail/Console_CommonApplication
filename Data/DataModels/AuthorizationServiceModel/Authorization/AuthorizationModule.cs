

using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


using static Api.Utils;

public class AuthorizationModule: Module
{
    public void ConfigureBackgroundService(IServiceCollection services)
    {
 
        services.AddSingleton<APIUsers, AuthorizationUsers>();
        services.AddSingleton<EmailOptions>();
        services.AddSingleton<EmailOptions>();

        WriteLine("Настройка службы фонового управления сеансами...");
        services.AddSingleton<AuthorizationOptions>();
        services.AddHostedService<AuthorizationBackground>();
    }
    public override void OnConfigureServices(IServiceCollection services)
    {
        var builder = new SqlConnectionStringBuilder();
        builder.TrustServerCertificate = false;
        builder.IntegratedSecurity = true;
        builder.DataSource = "AGENT\\KILLER";
        builder.InitialCatalog = "AppHospital";

        services.AddDbContext<AuthorizationDataModel>(options => options.UseInMemoryDatabase(builder.ToString()));
        services.AddScoped(typeof(IEntityFasade<UserAccount>), sp =>
             new EntityFasade<UserAccount>(sp.GetService<AuthorizationDataModel>()));
        services.AddScoped(typeof(IEntityFasade<UserGroups>), sp =>
             new EntityFasade<UserGroups>(sp.GetService<AuthorizationDataModel>()));
        services.AddScoped(typeof(IEntityFasade<UserMessage>), sp =>
             new EntityFasade<UserMessage>(sp.GetService<AuthorizationDataModel>()));
        services.AddScoped(typeof(IEntityFasade<UserSettings>), sp =>
             new EntityFasade<UserSettings>(sp.GetService<AuthorizationDataModel>()));
        services.AddScoped(typeof(IEntityFasade<UserGroups>), sp =>
             new EntityFasade<UserGroups>(sp.GetService<AuthorizationDataModel>()));
        services.AddScoped<IEmailService, UserEmailService>();
        services.AddScoped<HttpCookieManager>();
        services.AddScoped<APIAuthorization, AuthorizationService>();

        services.AddHttpClient();
        services.AddHttpContextAccessor();
        services.AddSingleton<EmailOptions>();
        services.AddSingleton<APIUsers, AuthorizationUsers>();
        services.AddSingleton<AuthorizationOptions>();

       
    }

    

    public override void OnConfigureMiddleware(IApplicationBuilder app)
    {
    }
}