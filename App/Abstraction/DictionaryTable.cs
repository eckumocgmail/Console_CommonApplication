using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;


/// <summary>
/// Модель абстрактной сущности "Cправочник".
/// </summary>
public interface IDictionaryTable
{
    string Description { get; set; }
    object Item { get; set; }
    string Name { get; set; }
}


[Icon("")]
[Label("")]

[SearchTerms("Name,Description")]
public class DictionaryTable : BaseEntity, IDictionaryTable
{


    [InputIcon()]
    [Label("Иконка на панель инструментов")]
    public string Icon { get; set; }

    [Label("Наименование")]
    [NotNullNotEmpty("Необходимо указать наименование")]
    [UniqValue("Имя должно иметь уникальное значение")]
    [InputText()]
    public virtual string Name { get; set; }


    [Icon("home")]
    [Label("Наименование")]
    [InputMultilineText()] 
    public virtual string Description { get; set; }

    [NotMapped]
    [InputHidden(true)]
    [JsonIgnore()]
    public object Item { get; set; }


    public DictionaryTable()
    {
        Name = Description = "";
    }

}
 