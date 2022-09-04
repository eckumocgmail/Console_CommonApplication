
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Diagnostics;
using NetCoreConstructorAngular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 
/// <summary>3
/// Аналитическая модель многомерных данных,
/// частный случай фиксированное кол-во измерений
/// </summary>
[Label("Аналитическая модель")]
public sealed class AnaliticsDataModel: BaseDbContext, IAnaliticsDataModel
{
    public DbSet<Monitoring> Monitorings { get; set; }
    public DbSet<DataInput> DataInput { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<Granularity> Granularities { get; set; }
    public DbSet<Indicator> Indicators { get; set; }    
    public DbSet<Location> Locations { get; set; }

    public AnaliticsDataModel() : base() { }
    public AnaliticsDataModel(DbContextOptions<AnaliticsDataModel> options) : base(options) { }

    protected override void InitDbSets()
    {
        using (var common = new CommonDataModel())
        {
            
            foreach(IDbContext context in common.list)
            {

                var monitoring = new Monitoring();
                monitoring.Name = "Рейтинг источника "+ context.GetTypeName();
                this.Add(monitoring);
                this.SaveChanges();


                foreach(var eventLogType in context.GetEntityTypes().Where(et => et.IsExtends(typeof(EventLog)))){
                    var indicator = new Indicator();
                    indicator.Name = "Вероятность наступления события " + eventLogType.GetTypeName();
                    this.Add(indicator);
                    indicator.MonitoringID = monitoring.ID;
                    this.SaveChanges();
                }






            }
        }
    }
}
 
