using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.IO;

public class AnaliticsServiceModule: IServiceModule
{

    
    public void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        this.Info("ConfigureServices()");

        services.AddScoped(typeof(IAnaliticsDataModel),
            sp => sp.GetService<AnaliticsDataModel>());
        services.AddScoped(typeof(IAnaliticsServiceModel),
            sp => new AnaliticsServiceLocal(sp.GetService<IAnaliticsDataModel>()));
        services.AddDbContext<AnaliticsDataModel>(options => 
        options.UseFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(),"Data",typeof(AnaliticsDataModel).GetNameOfType().ToKebabStyle()+".db")));
        services.AddScoped(typeof(IEntityFasade<DataInput>), sp => new EntityFasade<DataInput>(sp.GetService<AnaliticsDataModel>()));
        services.AddScoped(typeof(IEntityFasade<Indicator>), sp => new EntityFasade<Indicator>(sp.GetService<AnaliticsDataModel>()));
        services.AddScoped(typeof(IEntityFasade<Monitoring>), sp => new EntityFasade<Monitoring>(sp.GetService<AnaliticsDataModel>()));
        services.AddScoped(typeof(IEntityFasade<Location>), sp => new EntityFasade<Location>(sp.GetService<AnaliticsDataModel>()));
    
    }
}
