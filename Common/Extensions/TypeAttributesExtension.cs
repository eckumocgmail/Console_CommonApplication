using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Расширения для доступа к атрибутам
/// </summary>
public static class TypeAttributesExtension
{
    public static bool HasAttributeForField<T>( this Type type, string name ) where T: Attribute => Utils.HasAttribute<T>(Utils.ForField(type, name));
    public static bool HasAttributeForProperty<T>( this Type type, string name ) where T: Attribute => Utils.HasAttribute<T>(Utils.ForField(type, name));
    public static IEnumerable<Type> GetExtendingTypes(this Type type)
    {
        var types = new List<Type>();
        Typing.ForEachType(type, (next) =>
        {
            types.Add(next);
        });
        return types;
    }
    public static IEnumerable<string> GetExtendingTypeNames(this Type type)
    {
        var types = new List<string>();
        Typing.ForEachType(type, (next) =>
        {
            types.Add(next.GetNameOfType());
        });
        return types;
    }
    public static string GetExtendingPath(this Type type)
    {
        string path = "";
        Typing.ForEachType(type, (next) =>
        {
            path+="=>"+(next.GetNameOfType());
        });
        return path;
    }
    //public static bool IsComponent(this Type type) => type.Name.EndsWith("Component");
    //public static bool IsContainer(this Type type) => type.Name.EndsWith("Container");
    public static IDictionary<string,string> GetInputTypes(this Type type )
    {
        IDictionary<string, string> result = new Dictionary<string, string>();
        foreach(string property in type.GetOwnPropertyNames())
        {
            result[property] = type.GetInputType(property);
        }
        return result;
    }
    public static string GetInputType(this Type type, string property)
    {
        return Utils.GetInputType(Utils.ForProperty(type, property));
    }
    public static string Label(this Type type)
    {
        return Utils.LabelFor(type);
    }
    public static string Label(this Type type, string property)
    {
        return Utils.LabelFor(type, property);
    }    
    public static string Description(this Type type)
    {
        return Utils.DescriptionFor(type);
    }
    public static string Icon(this Type type)
    {
        return Utils.IconFor(type);
    }
    public static bool IsEntity(this Type type)
    {
        return Typing.IsExtendedFrom(type, "BaseEntity");
    }
}