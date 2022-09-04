




using ApplicationDb.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Даталогическая модель сущности "Должность".
/// </summary>
 
[SearchTerms(nameof(Name) + "," + nameof(Description))]
[Label("Должность")]
public class Position : DictionaryTable 
{



    public virtual List<PositionFunction> PositionFunctions { get; set; }
}