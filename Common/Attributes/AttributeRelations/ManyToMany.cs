
/// <summary>
/// Маркер свойств навигации, определяющие отношения много-ко-многим
/// </summary>
public class ManyToMany: BaseValidationAttribute
{
    private readonly string _includeToProperty;

    /// <param name="includeToProperty">
    /// Имя свойства коллекцией связанных обьектов
    /// </param>
    public ManyToMany( string includeToProperty )
    {
        _includeToProperty = includeToProperty;
    }

    public override string Validate(object model, string property, object value)
    {
        throw new System.NotImplementedException();
    }

    public override string GetMessage(object model, string property, object value)
    {
        throw new System.NotImplementedException();
    }
}