
public interface IValidationModel 
{
    public string ValidationName { get; set; }
    public string JavaScript { get; set; }
}

[Label("Проверка достоверности данных")]
public class ValidationModel: BaseEntity, IValidationModel
{
    public string ValidationName { get; set; }
    public string JavaScript { get; set; }
}