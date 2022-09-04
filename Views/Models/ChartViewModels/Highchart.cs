

using Newtonsoft.Json;

using System.Collections.Generic;

public class Highchart 
{

    [JsonIgnore]
    public static string[] Types = new List<string>() {
        "Highchart3dColumnInteractive",
        "Highchart3dColumnNullValues",
        "Highchart3dColumnStackingGrouping",
        //"Highchart3dScatterDraggable",
        "HighchartAccessibleLine",
        "HighchartAccessiblePie",
        "HighchartAnnotations",
        "HighchartAreaInverted",
        "HighchartAreaNegative",
        "HighchartAreaspline","HighchartAreaStacked","HighchartAreaStackedPercent","HighchartBarBasic","HighchartBarNegativeStack","HighchartBarStacked","HighchartChartUpdate","HighchartColumnBasic","HighchartColumnNegative","HighchartColumnStackedAndGrouped","HighchartColumnStackedPercent","HighchartCombo","HighchartComboDualAxes","HighchartComboMultiAxes","HighchartDynamicClickToAdd","HighchartErrorBar","HighchartLineBasic","HighchartLineLabels","HighchartLineLogAxis",
        //"HighchartPieDonut",
        "HighchartPieDrilldown","HighchartPolar","HighchartPolarRadialBar","HighchartPolarSpider"
    }.ToArray();
    
}