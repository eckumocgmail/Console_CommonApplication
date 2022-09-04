using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Net.Http;

/// <summary>
/// Регистрируем сервисы модули
/// </summary>
public class FilesServiceModule : DataSqlLiteModule<FilesDataModel>
{
    public override void OnConfigureMiddleware(IApplicationBuilder app)
    {
        base.OnConfigureMiddleware(app);
    }

    public override void OnConfigureServices(IServiceCollection services)
    {
        base.OnConfigureServices(services);
        services.AddScoped(typeof(IFilesDataModel), sp => sp.GetService<FilesDataModel>());
        services.AddScoped(typeof(IFilesServiceModel), sp => new FilesServiceLocal(
            sp.GetService<FilesDataModel>(),
            sp.GetService<HttpClient>(),
            "https://127.0.0.1"
        ));

        services.AddScoped(typeof(IEntityFasade<PhotoResource>), sp =>
            new EntityFasade<PhotoResource>(sp.GetService<FilesDataModel>()));
        services.AddScoped(typeof(IEntityFasade<AudioResource>), sp =>
            new EntityFasade<AudioResource>(sp.GetService<FilesDataModel>()));
        services.AddScoped(typeof(IEntityFasade<FileEntity>), sp =>
            new EntityFasade<FileEntity>(sp.GetService<FilesDataModel>()));
        services.AddScoped(typeof(IEntityFasade<FileCatalog>), sp =>
            new EntityFasade<FileCatalog>(sp.GetService<FilesDataModel>()));
        services.AddScoped(typeof(IEntityFasade<VideoResource>), sp =>
            new EntityFasade<VideoResource>(sp.GetService<FilesDataModel>()));

        services.AddScoped(typeof(DbSet<PhotoResource>), sp =>
            new EntityFasade<PhotoResource>(sp.GetService<FilesDataModel>()));
        services.AddScoped(typeof(DbSet<AudioResource>), sp =>
            new EntityFasade<AudioResource>(sp.GetService<FilesDataModel>()));
        services.AddScoped(typeof(DbSet<AudioResource>), sp =>
            new EntityFasade<AudioResource>(sp.GetService<FilesDataModel>()));
        services.AddScoped(typeof(DbSet<AudioResource>), sp =>
            sp.GetService<FilesDataModel>().AudioResources);
        services.AddScoped(typeof(DbSet<AudioResource>), sp =>
            sp.GetService<FilesDataModel>().AudioResources);
    }
}
