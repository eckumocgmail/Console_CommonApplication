using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AnaliticsServiceHttp: BaseDbContext, IAnaliticsServiceModel
{
 

    public object MoreUsableSkills()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public object CreateReport(DateTime begin, int time, int[] locations, int[] indicators)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public IDimFasade<Location, Indicator, TimePoint> DataInputFasade { get; set; }
    public IHierDictionaryFasade<Indicator> IndicatorsFasade { get; set; }
    public IHierDictionaryFasade<Location> LocationsFasade { get; set; }
    public IGroupFasade<Monitoring, Indicator> MonitoringsFasade { get; set; }
    public IEntityFasade<Granularity> GranularitiesFasade { get; set; }
    public IEntityFasade<News> NewsFasade { get; set; }
    MyApplicationModel IModel.Model { get; set; }
    public string Description { get; set; }
    public object Item { get; set; }
    public string Name { get; set; }

    public RequestMessage ActionEvent(ResponseMessage message)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public Task<RequestMessage> ActionEventAsync(ResponseMessage message)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public int LoginCount { get; set; }
    public ServiceCertificate ServiceCertificate { get; set; }
    public string Url { get; set; }

    public Task DoCheck(long timeout)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public Task Request(DataRequestMessage message)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    protected override void InitDbSets()
    {
    }
}
