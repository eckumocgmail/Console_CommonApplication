using System.Collections.Generic;

/// <summary>
/// Тестиротироование приложения на уровне данных/
/// -сохраняемость CRUD, поиск, навигация
/// -функциональность пользователи, операции, права, логи, журналы
/// </summary>
[Label("Тестирование слоя данных")]
[Description(@"  +
    Тестиротироование приложения на слое данных 
    -сохраняемость CRUD, поиск, навигация 
    -функциональность пользователи, операции, права, логи, журналы")]
public class DataUnit : TestingUnit
{
    public DataUnit(TestingUnit parent) : base(parent)
    {
        Push(new EntityFasadeTest(this));    
        Push(new DataModelsUnit(this));      
        Push(new DataModelsUnit(this));
    }
     
}
