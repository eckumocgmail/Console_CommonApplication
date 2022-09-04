using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Реестр атрибутов
/// </summary>
public class AttributeRegistry
{
    private static List<string> INPUT_TYPES = null;
    private static List<string> CONTROL_TYPES = null;

    /// <summary>
    /// Список наименований атрибутов ввода
    /// </summary>    
    public static List<string> GetInputTypes()
    {
        if (INPUT_TYPES == null)
        {
            INPUT_TYPES = new List<string>();
            foreach (var type in typeof(DataInputTypes).Assembly.GetTypes())
            {
                if (TypeUtils.IsExtendedFrom(type, nameof(InputTypeAttribute)))
                {
                    INPUT_TYPES.Add(type.Name);
                }               
            }
           
        }
        return INPUT_TYPES;
    }


    /// <summary>
    /// Список наименований атрибутов управления
    /// </summary>    
    public static List<string> GetControlTypes()
    {
        if (CONTROL_TYPES == null)
        {
            CONTROL_TYPES = new List<string>();
            foreach (var type in typeof(ControlAttribute).Assembly.GetTypes())
            {
                if (TypeUtils.IsExtendedFrom(type, nameof(ControlAttribute)))
                {
                    CONTROL_TYPES.Add(type.Name);
                }
            }

        }
        return CONTROL_TYPES;
    }

}


public class AttributeRegistryTest: TestingElement
{
    public override List<string> OnTest()
    {
        if((AttributeRegistry.GetInputTypes().Count() == 0) || (AttributeRegistry.GetControlTypes().Count() == 0))
        {
            Messages.Add("Не удалось получить классификацию элементов управления: " + AttributeRegistry.GetControlTypes().ToJsonOnScreen());
            Messages.Add("Не удалось получить классификацию функций ввода данных: " + AttributeRegistry.GetInputTypes().ToJsonOnScreen());
        }
        else
        {
            Messages.Add("Классификация элементов управления: " + AttributeRegistry.GetControlTypes().ToJsonOnScreen());
            Messages.Add("Классификация функций ввода данных: " + AttributeRegistry.GetInputTypes().ToJsonOnScreen());
        }
        return Messages;
    }
}