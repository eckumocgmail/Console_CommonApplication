using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
 
[Label("Исходные данные")]
public class DataInput: BaseEntity
{
    [SelectDataDictionary("Dataset,Name")]
    public int DatasetID { get; set; }
    [SelectDataDictionary("Indicator,Name")]
    public int IndicatorID { get; set; }

    [SelectDataDictionary("Granularity,Name")]
    public int GranularityID { get; set; }

    [SelectDataDictionary("Location,Name")]
    public int LocationID { get; set; }
  
    public virtual Indicator Indicator { get; set; }
    public virtual Granularity Granularity { get; set; }
    public virtual Location Location { get; set; }

    [InputNumber("")]
    [NotNullNotEmpty()]
    public float Value { get; set; }

    [Column(TypeName = "DateTime")]
    public DateTime Changed { get; set; }
}

