
/// <summary>
/// Маркер свойств навигации, определяющие отношения один-к-одиному
/// </summary>
public class OneToOne : ConstraintAttribute
{

    /// <param name="includeToProperty">
    /// Имя свойства коллекцией связанных обьектов
    /// </param>
    public OneToOne(string includeToProperty)
    {

    }
}