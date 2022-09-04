using ApplicationDb.Types;
using System.Collections.Generic;

[Label("Медицинский кабинет")]
public class MedicalRoom: DictionaryTable 
{

    [Label("Этаж")]
    [NotNullNotEmpty("Необходимо указать этаж")]
    public int Floor { get; set; } = 1;

    [InputNumber()]
    [Label("Номер кабинета")]
    public int Number { get; set; }

    [Label("Медицинские койки")]
    public virtual List<MedicalBed> Beds { get; set; }
}