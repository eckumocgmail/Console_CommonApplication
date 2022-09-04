using Microsoft.EntityFrameworkCore;

public interface IAnaliticsDataModel: IDbContext
{

    [NotNullNotEmpty]
    public DbSet<DataInput> DataInput { get; set; }

    [NotNullNotEmpty]
    public DbSet<Granularity> Granularities { get; set; }

    [NotNullNotEmpty]
    public DbSet<Indicator> Indicators { get; set; }

    [NotNullNotEmpty]
    public DbSet<Location> Locations { get; set; }

    [NotNullNotEmpty]
    public DbSet<Monitoring> Monitorings { get; set; }

    [NotNullNotEmpty]
    public DbSet<News> News { get; set; }
}