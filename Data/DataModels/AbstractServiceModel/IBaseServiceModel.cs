public interface IModel : IDictionaryTable
{

    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public MyApplicationModel Model { get; set; }
}
