using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EntityUtils
{
    public static IEnumerable<INavigation> GetNavigation(Type type)
    {
        IEnumerable<INavigation> result = null;
        using (var _context = new CommonDataModel())
        {
            result =  new AppDbContext().GetNavigationPropertiesForType(type);
        }
        if (result == null)
        {
            return new List<INavigation>();
        }
        else
        {
            return result;
        }
    }


    public static INavigation GetNavigationKeyFor(string instance, Type targetEntityType)
    {
        Type entityType = ReflectionService.TypeForName(instance);
        var navs = GetNavigation(entityType);
        foreach (var nav in navs)
        {
            var type = entityType.GetProperty(nav.Name).PropertyType;
            if (TypeUtils.IsCollectionType(type))
            {
                if(TypeUtils.ParseCollectionType(type) == targetEntityType.Name)
                {
                    return nav;
                }
            }
            else
            {
                if(TypeUtils.ParsePropertyType(type) == targetEntityType.Name)
                {
                    return nav;
                }
            }
                
                
        }
        throw new Exception($"Не найдено свойство навигации {entityType.Name} {targetEntityType.FullName}"); 
    }

    public static List<string> GetTables( object context )
    {
        return ((DbContext) context).GetEntitiesTypes().Select(t => t.Name).ToList();
    }
}
