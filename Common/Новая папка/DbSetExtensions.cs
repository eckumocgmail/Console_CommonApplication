﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Расширения наборов данных
/// </summary>
public static class DbSetExtensions
{

    #region Typing
    public static string GetName(this Type propertyType)
    {
        string name = propertyType.Name.IndexOf("`") == -1 ? propertyType.Name : propertyType.Name.Substring(0, propertyType.Name.IndexOf("`"));
        if (propertyType.GenericTypeArguments != null && propertyType.GenericTypeArguments.Length > 0)
        {
            string suffix = "";
            foreach (var parType in propertyType.GenericTypeArguments)
            {
                suffix += "," + parType.GetNameOfType();
            }
            suffix = suffix.Replace(",", "<") + ">";
            name += suffix;
        }
        return name;
    }
    public static Dictionary<string, string> GetUtils(this Type type)
    {
        return Utils.ForType(type);
    }


    public static HashSet<string> PRIMITIVE_TYPES = new HashSet<string>() {
            "Byte[]", "System.Byte[]", "String", "Boolean", "System.String", "string", "int","long","float",
        "Nullable<System.Boolean>", "Double", "Nullable<System.Double>",
        "Int16", "Nullable<Int16>", "Int32", "Nullable<System.Int32>",
        "Int64", "Nullable<System.Int64>", "UInt16", "UInt32", "UInt64",
        "DateTime", "Nullable<System.DateTime>" };
    public static readonly IEnumerable<string> INPUT_TYPES = new HashSet<string>(ReflectionService.GetPublicStaticFieldNames(typeof(InputTypes)));

    public static readonly IEnumerable<string> NUBMER_TYPES = new HashSet<string>() {
              "System.Decimal",  "Decimal", "Nullable<System.Decimal>", "System.Float",
        "Float", "Nullable<System.Float>", "System.Double",  "Double", "Nullable<System.Double>",
        "Int16", "System.Int16", "Nullable<System.Int16>",
        "Int32", "System.Int32", "Nullable<System.Int32>",
        "Int64", "System.Int64", "Nullable<System.Int64>",
        "UInt16", "System.UInt16", "Nullable<System.UInt16>",
        "UInt32", "System.UInt32", "Nullable<System.UInt32>",
        "UInt64", "System.UInt64", "Nullable<System.UInt64>"  };
    public static readonly IEnumerable<string> TEXT_TYPES = new HashSet<string>() {
            "String,System.String" };
    public static readonly IEnumerable<string> LOGICAL_TYPES = new HashSet<string>() {
            "Boolean","System.Boolean","Nullable<System.Boolean>", };
    public static bool IsExtendedFrom(Type targetType, Type baseType)
    {
        return IsExtendedFrom(targetType, baseType.GetNameOfType());
    }
    public static bool IsExtendedFrom(Type targetType, string baseType)
    {
        Type typeOfObject = new object().GetType();
        Type p = targetType;
        while (p != typeOfObject && p != null)
        {
            if (p.Name == baseType)
            {
                return true;
            }
            p = p.BaseType;
        }
        return false;
    }
    public static void ForEachType(Type targetType, Action<Type> todo)
    {
        Type typeOfObject = new object().GetType();
        Type p = targetType;
        while (p != typeOfObject && p != null)
        {
            todo(p);
            p = p.BaseType;
        }
    }

    public static bool IsImplementedFrom(Type targetType, string interfaceType)
    {
        Type typeOfObject = new object().GetType();
        if (IsExtendedFrom(targetType, interfaceType))
            return true;
        Type p = targetType;
        while (p != typeOfObject && p != null)
        {
            if (p.GetInterfaces().Any(x => x.GetNameOfType() == interfaceType))
            {
                return true;
            }
            p = p.BaseType;
        }
        return false;
    }


    public static bool IsActiveObject(Type type)
    {
        return IsExtendedFrom(type, "ActiveObject");
    }

    public static bool IsDailyStatsTable(Type type)
    {
        return IsExtendedFrom(type, "DailyStatsTable");
    }

    public static bool IsDictionaryTable(Type type)
    {
        return IsExtendedFrom(type, "DictionaryTable");
    }

    public static bool IsDimensionTable(Type type)
    {
        return IsExtendedFrom(type, "DimensionTable");
    }

    public static bool IsFactsTable(Type type)
    {
        return IsExtendedFrom(type, "EventsTable");
    }

    public static bool IsPublicEntity(Type type)
    {
        return IsExtendedFrom(type, "PublicEntity");
    }

    public static bool IsStatsTable(Type type)
    {
        return IsExtendedFrom(type, "StatsTable");
    }

    public static bool IsWeeklyStatsTable(Type type)
    {
        return IsExtendedFrom(type, "WeeklyStatsTable");
    }

    public static bool IsYearlyStatsTable(Type type)
    {
        return IsExtendedFrom(type, "YearlyStatsTable");
    }



    public static bool IsHierDictinary(Type entityType)
    {
        bool isHier = false;
        Type p = entityType;
        while (p != typeof(Object) && p != null)
        {
            if (p.Name.StartsWith("HierDictionaryTable"))
            {
                isHier = true;
                break;
            }
            p = p.BaseType;
        }

        return isHier;
    }
    public static string ParseCollectionType(Type type)
    {
        string text = type.AssemblyQualifiedName;
        text = text.Substring(text.IndexOf("[[") + 2);
        text = text.Substring(0, text.IndexOf(","));
        return text.Substring(text.LastIndexOf(".") + 1);
    }


    public static bool HasBaseType(Type targetType, Type baseType)
    {
        if (targetType == null)
            throw new Exception("Тип не определён");
        Type p = targetType.BaseType;
        while (p != typeof(Object) && p != null)
        {
            if (p.Name == baseType.Name)
            {
                return true;
            }
            p = p.BaseType;
        }
        return false;
    }



    public static bool IsDateTime(PropertyInfo property)
    {
        var ptype = property.PropertyType;
        return IsDateTime(ptype);
    }

    public static bool IsDateTime(Type ptype)
    {
        string propertyType = ParsePropertyType(ptype);
        if (propertyType == "System.DateTime" || propertyType == "DateTime" || propertyType == "Nullable<DateTime>" || propertyType == "Nullable<System.DateTime>")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool IsNullable(PropertyInfo property)
    {
        var ptype = property.PropertyType;

        return IsNullable(ptype);
    }

    public static bool IsNullable(Type ptype)
    {
        string propertyType = ParsePropertyType(ptype);
        return propertyType.StartsWith("Nullable");
    }

    /*
* public static string ParseCollectionType(Type model, string propertyName)
{
   return ParseProperty(model, model.GetProperty(propertyName)).Type;
}

public static List<MyMessageProperty> ParseProperties(Type type)
{
   List<MyMessageProperty> props = new List<MyMessageProperty>();
   foreach (var property in type.GetProperties())
   {
       MyMessageProperty prop = ParseProperty(type, property);
       props.Add(prop);
   }
   return props;
}
public static MyMessageProperty ParseProperty(Type type, PropertyInfo property)
{
   string TypeName = property.PropertyType.Name;
   bool IsCollection = false;
   if (property.PropertyType.Name.StartsWith("List"))
   {
       IsCollection = true;
       string text = property.PropertyType.AssemblyQualifiedName;
       text = text.Substring(text.IndexOf("[[") + 2);
       text = text.Substring(0, text.IndexOf(","));
       TypeName = text.Substring(text.LastIndexOf(".") + 1);
       Api.Utils.Info(property.Name + " " + text);
   }
   MyMessageProperty prop = new MyMessageProperty
   {
       Name = property.Name,
       IsCollection = IsCollection,
       Type = TypeName,
       Attributes = Utils.ForProperty(type, property.Name)
   };
   return prop;
}
public static List<MyMessageProperty> ParseActions(Type type)
{
   List<MyMessageProperty> props = new List<MyMessageProperty>();
   foreach (var property in type.GetProperties())
   {
       MyMessageProperty prop = ParseProperty(type, property);
       props.Add(prop);
   }
   return props;
}

*/
    public static bool IsCollectionType(Type type)
    {
        Type p = type;
        while (p != typeof(Object) && p != null)
        {
            if ((from pinterface in new List<Type>(p.GetInterfaces()) where pinterface.Name.StartsWith("ICollection") select p).Count() > 0)
            {
                return true;
            }
            p = p.BaseType;
        }
        return false;
    }


    public static string ParsePropertyType(Type propertyType)
    {
        string name = propertyType.Name;

        if (name.Contains("`"))
        {
            string text = propertyType.AssemblyQualifiedName;
            text = text.Substring(text.IndexOf("[[") + 2);
            text = text.Substring(0, text.IndexOf(","));
            name = name.Substring(0, name.IndexOf("`")) + "<" + text + ">";
        }
        return name;
    }



    /// <summary>
    /// Метод получения описателя вызова статических методов 
    /// </summary>
    /// <param name="type"> тип </param>
    /// <returns> описание статических методов </returns>
    public static Dictionary<string, object> GetStaticMethods(Type type)
    {
        Dictionary<string, object> actionMetadata = new Dictionary<string, object>();
        foreach (MethodInfo info in type.GetMethods())
        {
            if (info.IsPublic && info.IsStatic)
            {
                Dictionary<string, object> args = new Dictionary<string, object>();
                foreach (ParameterInfo pinfo in info.GetParameters())
                {
                    args[pinfo.Name] = new
                    {
                        type = pinfo.ParameterType.Name,
                        optional = pinfo.IsOptional,
                        name = pinfo.Name
                    };
                }
            }
        }
        return actionMetadata;
    }
    /*public List<string> GetEvents()
    {
        List<string> listeners = new List<string>();
        foreach (EventInfo evt in GetType().GetEvents())
        {
            listeners.Add(evt.Name.ToLower());
        }
        return listeners;
    }*/
    public static bool IsNumber(PropertyInfo propertyInfo)
    {
        return NUBMER_TYPES.Contains(ParsePropertyType(propertyInfo.PropertyType));
    }

    public static bool IsNumber(Type ptype)
    {
        return NUBMER_TYPES.Contains(ParsePropertyType(ptype));
    }

    public static bool IsText(PropertyInfo propertyInfo)
    {
        return TEXT_TYPES.Contains(ParsePropertyType(propertyInfo.PropertyType));
    }

    public static bool IsText(Type ptype)
    {
        return TEXT_TYPES.Contains(ParsePropertyType(ptype));
    }

    public static bool IsPrimitive(string propertyType)
    {
        Type type = ReflectionService.TypeForName(propertyType);

        return PRIMITIVE_TYPES.Contains(ParsePropertyType(type));
    }

    public static bool IsPrimitive(Type propertyType)
    {
        return PRIMITIVE_TYPES.Contains(ParsePropertyType(propertyType));
    }

    public static bool IsPrimitive(Type modelType, string property)
    {
        return PRIMITIVE_TYPES.Contains(ParsePropertyType(modelType.GetProperty(property).PropertyType));
    }

    public static bool IsBoolean(PropertyInfo propertyInfo)
    {
        return LOGICAL_TYPES.Contains(ParsePropertyType(propertyInfo.PropertyType));
    }

    public static bool ReferenceIsDictionary(object properties)
    {
        return properties.GetType().Name.Contains("Dictionary");
    }
    #endregion

    /// <summary>
    /// Нехороший способ извеления наименований сущностей
    /// </summary>
    /// <param name="subject"> контекст данных </param>
    /// <returns> множество наименований сущностей </returns>
    public static HashSet<Type> GetEntitiesTypes(this DbContext subject)
    {
        Type type = subject.GetType();
        HashSet<Type> entities = new HashSet<Type>();
        foreach (MethodInfo info in type.GetMethods())
        {
            if (info.Name.StartsWith("get_") == true && info.ReturnType.Name.StartsWith("DbSet"))
            {
                if (info.Name.IndexOf("MigrationHistory") == -1)
                {
                    entities.Add(info.ReturnType);
                }
            }
        }
        return entities;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static HashSet<string> GetEntityTypeNames(this Type type)
    {       
        HashSet<string> entities = new HashSet<string>();
        foreach (MethodInfo info in type.GetMethods())
        {
            if (info.Name.StartsWith("get_") == true && info.ReturnType.Name.StartsWith("DbSet"))
            {
                if (info.Name.IndexOf("MigrationHistory") == -1)
                {
                    entities.Add(ParseCollectionType(info.ReturnType));
                }
            }
        }
        return entities;
    }


    /// <summary>
    /// Получение наборов данных
    /// </summary> 
    public static Dictionary<string, object> GetDbSets(this DbContext _context)
    {
        var res = new Dictionary<string, object>();
        foreach (MethodInfo info in _context.GetType().GetMethods())
        {
            if (info.Name.StartsWith("get_") == true && info.ReturnType.Name.StartsWith("DbSet"))
            {
                if (info.Name.IndexOf("MigrationHistory") == -1)
                {
                    string displayName = info.ReturnType.ShortDisplayName();
                    string entityTypeName = displayName.Substring(displayName.IndexOf("<") + 1);
                    entityTypeName = entityTypeName.Substring(0, entityTypeName.IndexOf(">"));
                    res[entityTypeName] = (dynamic)info.Invoke(_context, new object[0]);
                }

            }
        }
        return res;
    }
 

    /// <summary>
    /// Получение набора по имени сущности
    /// </summary>
    public static dynamic GetDbSet(this DbContext _context, string entityTypeShortName)
    {
        try
        {
            foreach (MethodInfo info in _context.GetType().GetMethods())
            {
                if (info.Name.StartsWith("get_") == true && info.ReturnType.Name.StartsWith("DbSet"))
                {
                    if (info.Name.IndexOf("MigrationHistory") == -1)
                    {
                        string displayName = info.ReturnType.ShortDisplayName();
                        string entityTypeName = displayName.Substring(displayName.IndexOf("<") + 1);
                        entityTypeName = entityTypeName.Substring(0, entityTypeName.IndexOf(">"));
                        if (entityTypeShortName == entityTypeName)
                        {
                            return (dynamic)info.Invoke(_context, new object[0]);
                        }
                    }

                }
            }
        }
        catch (Exception)
        {
            return (dynamic)null;
        }
        

        throw new Exception($"Сущность [{entityTypeShortName}] не определена в контексте базы данных "+_context.GetType().Name);
    }


    /// <summary>
    /// Получение набора по типу сущности
    /// </summary>
    public static DbSet<T> GetDbSet<T>(this DbContext _context) where T: class
    {
        return (DbSet<T>)_context.GetDbSet(typeof(T).GetNameOfType());
    }
}
 