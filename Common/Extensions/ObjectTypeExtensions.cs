using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Расширения объекта через тип
/// </summary>
public static class ObjectTypeExtensions
{

    public static IEnumerable<string> GetBaseTypesNames(this object target)
    {
        var result = new List<string>();
        Type typeOfObject = new object().GetType();
        Type p = target is Type? ((Type)target): target.GetType();
        while (p != typeOfObject && p != null)
        {
            result.Add(p.BaseType.GetNameOfType());
            p = p.BaseType;
        }
        return result;            
    }
    public static bool IsPrimitiveType(this object target)
    {
        return Typing.IsPrimitive(target.GetType());
    }

    public static TService Casts<TService>(this object target)
    {
        try
        {
            return (TService)target;
        }
        catch(Exception ex)
        {
            throw new Exception("Не удалось привести к типу " + typeof(TService).GetNameOfType() + " объект типа: " + target.GetTypeName(),ex);
        }
    }

    public static bool Is<TService>(this object target) =>
        target.IsExtends(typeof(TService)) || target.IsImplements(typeof(TService));
 
    /*public static IEnumerable<string> GetOwnMethodNames( this object target) => 
        target == null? throw new ArgumentNullException(nameof(target)):
        target.GetType().GetOwnMethodNames();

    public static IEnumerable<string> GetOwnPropertyNames( this object target) =>
        target == null ? throw new ArgumentNullException(nameof(target)) : 
        target.GetType().GetOwnPropertyNames();*/

}



