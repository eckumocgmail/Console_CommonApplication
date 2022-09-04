
/// <summary>
/// Маркер свойств навигации, определяющие отношения один-ко-многим
/// </summary>
public class OneToMany : ConstraintAttribute
{

    /// <param name="includeToProperty">
    /// Имя свойства коллекцией связанных обьектов
    /// </param>
    public OneToMany(string includeToProperty)
    {

    }
}