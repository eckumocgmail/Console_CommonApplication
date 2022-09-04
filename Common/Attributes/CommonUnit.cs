using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Тетсирование уровня исполнения асинхронных операций
/// </summary>
public class CommonUnit : TestingUnit
{
    public CommonUnit(TestingUnit parent): base(parent)
    {
        //Push(new AsyncContextTest());
    }

   
}
