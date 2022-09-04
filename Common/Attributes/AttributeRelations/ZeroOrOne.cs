
/// <summary>
/// Маркер свойств навигации, определяющие отношения ноль-или-один
/// </summary>
public class ZeroOrOne : ConstraintAttribute
{

    /// <param name="includeToProperty">
    /// Имя свойства коллекцией связанных обьектов
    /// </param>
    public ZeroOrOne(string includeToProperty)
    {

    }
}