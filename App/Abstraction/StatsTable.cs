using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

 
/// <summary>
/// Сущность реализующая данный клас хранит 
/// колличественные характеристики выполнения 
/// бизнес функций обьектами информационного взаимодействия
/// за оределённый промежуток времени, заданный 
/// свойствами [Begin, EndDate).
/// 
/// Важно! 
/// Обратите внимание что конечный точка EndDate исключена из промежутка.
/// </summary>
public class StatsTable
{
    [DisplayName("Начало периода")]
    [DataType(DataType.Date)]
    public DateTime BeginDate { get; set; }

    [DisplayName("Начало периода")]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
}
 