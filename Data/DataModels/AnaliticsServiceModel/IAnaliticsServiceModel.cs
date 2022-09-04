using Microsoft.EntityFrameworkCore;

using System;

public interface IAnaliticsServiceModel: IModel
{
    public IDimFasade<Location, Indicator, TimePoint> DataInputFasade { get; set; }
    public IHierDictionaryFasade<Indicator> IndicatorsFasade { get; set; }
    public IHierDictionaryFasade<Location> LocationsFasade { get; set; }
    public IGroupFasade<Monitoring, Indicator> MonitoringsFasade { get; set; }
    public IEntityFasade<Granularity> GranularitiesFasade { get; set; }
    public IEntityFasade<News> NewsFasade { get; set; }


    //наиболее востребованные таланты
    public object MoreUsableSkills();


    //анализ эффективности продаж в разрезе продуктов
    public object CreateReport(DateTime begin, int time, int[] locations, int[] indicators);

}