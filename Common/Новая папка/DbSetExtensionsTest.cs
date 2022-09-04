 
using Microsoft.EntityFrameworkCore;

public class DbSetExtensionsTest : TestingElement
{

    /// <summary>
    /// Сущность для теста
    /// </summary>
    public class Message { }
    

    /// <summary>
    /// Получение типов сущностей
    /// </summary>
    public void GetEntitiesTypesTest(DbContext dbContext) {

        try
        {
            if (dbContext.GetEntitiesTypes().Contains(typeof(Message)) == false)
            {
                throw new System.Exception("Не удалось получить набор сущностей определённых в контексте EF");
            }
            Messages.Add("Удалось получить набор сущностей определённых в контексте EF");

        }
        catch (System.Exception ex)
        {
            Messages.Add(ex.Message);
        }
    }
 
 
    /// <summary>
    /// Получение DbSet по имени сущности
    /// </summary>
    public void GetDbSetTest(DbContext dbContext) {
        try
        {
            if (dbContext.GetDbSet(typeof(Message).GetNameOfType()) == null)
            {
                throw new System.Exception("Не удалось получить набор данных");
            }
            Messages.Add("Удалось получить набор данных");

        }
        catch (System.Exception ex)
        {
            Messages.Add(ex.Message);
        }
    }


    /// <summary>
    /// Тестирование 
    /// </summary>
    public override System.Collections.Generic.List<string> OnTest()
    {
        using(var db = new AppDbContext())
        {
            GetEntitiesTypesTest(db);
            GetDbSetTest(db);
        }
        return Messages;
    }
}
