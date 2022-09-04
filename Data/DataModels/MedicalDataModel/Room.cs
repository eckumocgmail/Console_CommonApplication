namespace ApplicationDb.Types { }

[Label("Помещение")]
public class Room : DictionaryTable 
{
    [Label("Этаж")]
    [NotNullNotEmpty("Необходимо указать этаж")]
    public int Floor { get; set; } = 1;
}