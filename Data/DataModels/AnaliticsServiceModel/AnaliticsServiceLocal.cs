
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AnaliticsServiceLocal: Local, IAnaliticsServiceModel
{
    private IAnaliticsDataModel analiticsDataModel;



    [NotNullNotEmpty]
    public IDimFasade<Location, Indicator, TimePoint> DataInputFasade { get; set; }

    [NotNullNotEmpty]
    public IHierDictionaryFasade<Indicator> IndicatorsFasade { get; set; }

    [NotNullNotEmpty]
    public IHierDictionaryFasade<Location> LocationsFasade { get; set; }

    [NotNullNotEmpty]
    public IGroupFasade<Monitoring, Indicator> MonitoringsFasade { get; set; }

    [NotNullNotEmpty]
    public IEntityFasade<Granularity> GranularitiesFasade { get; set; }

    [NotNullNotEmpty]
    public IEntityFasade<News> NewsFasade { get; set; }


    public AnaliticsServiceLocal(IAnaliticsDataModel analiticsDataModel): base(AppProviderService.GetInstance())
    {
        this.analiticsDataModel = analiticsDataModel;
        this.NewsFasade = new EntityFasade<News>( analiticsDataModel );
        this.GranularitiesFasade = new EntityFasade<Granularity>( analiticsDataModel );
        this.MonitoringsFasade = new GroupFasade<Monitoring,Indicator>( analiticsDataModel );

        this.EnsureIsValide();
    }



    public object MoreUsableSkills()
    {
        return new Dictionary<string, int>();
    }

    public object CreateReport(DateTime begin, int time, int[] locations, int[] indicators)
    {
        return new Dictionary<string, int>();
    }


    public object GetAbsolutelyValue(
        DateTime BeginDate,
        DateTime EndDate,
        string Item,
        string Indicator)
    {
        return 100;
    }


    public object GetSeriesValue(DateTime BeginDate, DateTime EndDate, string Item, string Indicator)
    {
        return JObject.FromObject(new
        {
            data = new float[] { 10, 20, 30, 40 }
        })["data"].Value<object>();
    }

    public string GetSeriesText(DateTime BeginDate, DateTime EndDate, string Item, string Indicator)
    {
        string text = "";
        foreach (var jval in ((JArray)GetSeriesValue(BeginDate, EndDate, Item, Indicator)))
        {
            text += jval + ", ";
        }
        if (text.EndsWith(", "))
            text = text.Substring(0, text.Length - 2);
        return text;
    }





    /// <summary>
    /// Модель диаграммы исп. для анализа затрат по статьям и 
    /// подразделениям
    /// </summary>
    /// <param name="Title">Заголовок</param>		
    /// <param name="Series">Данные</param>
    /// <returns></returns>
    public Highchart Create(string Title, Dictionary<string, List<Nullable<float>>> Series)
    {
        var result = new HighchartLineBasic()
        {
            Title = new HighchartLineBasicTitle()
            {
                Text = Title
            }
        };
        result.Series = new List<HighchartLineBasicSeriesItem>();
        foreach (var p in Series)
        {
            result.Series.Add(new HighchartLineBasicSeriesItem()
            {
                Name = p.Key,
                Data = p.Value
            });

        }
        return result;
    }



    /// <summary>
    /// Модель диаграммы исп. для анализа затрат по статьям и 
    /// подразделениям
    /// </summary>
    /// <param name="Title">Заголовок</param>
    /// <param name="Categories">Категории</param>
    /// <param name="Series">Данные</param>
    /// <returns></returns>
    public Highchart CreatePolarChart(string Title, List<string> Categories, Dictionary<string, List<Nullable<float>>> Series)
    {
        var result = new HighchartPolarSpider()
        {
            Title = new HighchartPolarSpiderTitle()
            {
                Text = Title
            }
        };
        result.XAxis.Categories = Categories;
        result.Series = new List<HighchartPolarSpiderSeriesItem>();
        foreach (var p in Series)
        {
            result.Series.Add(new HighchartPolarSpiderSeriesItem()
            {
                Name = p.Key,
                Data = p.Value
            });

        }
        return result;
    }

    /// <summary>
    /// Модель гистограммы
    /// </summary>
    /// <param name="Title">заголовок</param>
    /// <param name="Categories">категории</param>
    /// <param name="Source">источник</param>
    /// <returns></returns>
    public Highchart CreateBar(string Title, string Units, IDictionary<string, float> Dataset)
    {


        var chart = new HighchartBarBasic();

        chart.Title.Text = Title;
        chart.Subtitle.Text = "";
        chart.YAxis.Title.Text = Units;
        chart.XAxis.Categories = new List<string>(Dataset.Keys);
        chart.Series.Clear();
        foreach (var p in Dataset)
        {
            chart.Series.Add(new HighchartBarBasicSeriesItem()
            {
                Name = p.Key,
                Data = new List<float?>() { p.Value }
            });
        }
        return chart;
    }

    /// <summary>
    /// Создание модели столбчатой диаграммы
    /// </summary>
    /// <param name="Title">Заголовок диаграммы</param>
    /// <param name="Dataset">Данные для отображения</param>
    /// <returns>Модели столбчатой диаграммы</returns>
    public HighchartColumnBasic CreateColumnChart(string Title, string Units, IDictionary<string, float> Dataset)
    {
        var chart = new HighchartColumnBasic();
        chart.Title.Text = Title;
        chart.Subtitle.Text = "";
        chart.YAxis.Title.Text = Units;
        chart.XAxis.Categories = new List<string>(Dataset.Keys);
        chart.Series.Clear();
        foreach (var p in Dataset)
        {
            chart.Series.Add(new HighchartColumnBasicSeriesItem()
            {
                Name = p.Key,
                Data = new List<float?>() { p.Value }
            });
        }

        return chart;

    }

    public object Get()
    {
        return JObject.FromObject(new
        {
            data = new float[] { 10, 20, 30, 40 }
        })["data"].Value<object>();
    }


}
