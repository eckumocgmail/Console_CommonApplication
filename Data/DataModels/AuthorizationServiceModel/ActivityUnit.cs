using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Функциональная модель бизнес процессов.
/// Анализ предметной области:
/// -производители регистрируются в каталогах по типам продукции
/// -покупатели регистрируются в свои каталогах 

/// </summary>
public class ActivityUnit: TestingUnit
{
    public ActivityUnit(TestingUnit parent) : base(parent)
    {
    }

    
}
 
