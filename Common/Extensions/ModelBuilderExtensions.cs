 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
public static class ModelBuilderExtensions
{

    /// <summary>
    /// Учёт постоянных затрат на оплату труда
    /// </summary>   
    public static void UseFile(this DbContextOptionsBuilder builder, string filepath)
    {
        
        if (System.IO.File.Exists(filepath) == false)
        {
            using (Stream fs = System.IO.File.Create(filepath))
            {
                fs.Flush();
            }
        }
        builder.Info($"Прикрепляем файл: " + filepath + " " + filepath.FileSize());
        builder.UseSqlite($"DataSource={filepath};Cache=Shared");
    }

    /// <summary>
    /// Связывание контекста данных с базой SQL-Lite, представленной в виде файлового источника.
    /// Если файла не существует, то будет создан новый
    /// </summary>
    public static void AddFileDatabase<DbContextType>(this IServiceCollection services, string filepath = null)
        where DbContextType : DbContext
    {
        if (filepath == null)
            filepath = typeof(DbContextType).GetNameOfType().ToKebabStyle() + ".db";
        string filename = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data", typeof(DbContextType).GetNameOfType().ToKebabStyle() + ".db");
        if(System.IO.File.Exists(filename)==false)
        {
            System.IO.File.Create(filename);
        }
        filename.Info($"Контекст базы данных " +
            $"{typeof(DbContextType).GetNameOfType()} связан с " +
            $"файлом {filename} ( размер {new FileInfo(filename).Length} )");
        services.AddDbContext<DbContextType>(options =>

            options.UseFile(filename)
        );

        using (var db = typeof(DbContextType).New().Casts<BaseDbContext>())
        {
            db.GetContentStatistics().ToJsonOnScreen().WriteToConsole();
        }

        foreach (string entity in GetEntityTypeNames(typeof(DbContextType)))
        {
            var entityType = entity.ToType();
            if( entityType.GetExtendingTypeNames().Any(e => e.IndexOf("HierDictionary")!=-1))
            {
                var fasadeType = typeof(IHierDictionaryFasade<>).MakeGenericType(entityType);

                services.AddScoped
                (
                    fasadeType, //IEntityFasade<TEntity>
                    sp =>
                    {
                        var result = typeof(DbHierDictionaryFasade<>).MakeGenericType(entity.ToType()).Create(new object[] { sp.GetService<DbContextType>() });
                        return result;
                    }
                    );
            }
            else
            {
                if (entityType == null)
                    continue;
                var fasadeType = typeof(IEntityFasade<>).MakeGenericType(entityType);
                if(services.Any(s => s.ServiceType == fasadeType) == false)
                services.AddScoped
                (
                    fasadeType, //IEntityFasade<TEntity>
                    sp =>
                    {
                        var result = typeof(EntityFasade<>).MakeGenericType(entity.ToType()).Create(new object[] { sp.GetService<DbContextType>() });
                        return result;
                    }
                    );
            }
            

           
        }
    }

    private static IEnumerable<string> GetEntityTypeNames(Type type)
    {
        return type.GetProperties().Where(p => p.PropertyType.GetTypeName().IndexOf("DbSet") != -1).Select(p => p.Name);
    }

    /// <summary>
    /// Применение атрибутов
    /// </summary>
    public static void ApplyAnnotations( this ModelBuilder builder, DbContext context )
    {   
        foreach (var type in GetEntitiesTypes(context))
        {
            Dictionary<string, string> dictionary = GetEntityContrainsts(type);
            foreach (var p in dictionary)
            {
                switch (p.Key)
                {                    
                    case nameof(UniqValueAttribute):
                        builder.Entity(type).HasIndex(p.Value.Split(",")).IsUnique();
                        break;
                    case nameof(SearchTermsAttribute):
                        builder.Entity(type).HasIndex(p.Value.Split(",")).IsUnique();
                        break;
                    default:
                        break;
                }
            }
        }       
    }

    private static IEnumerable<Type> GetEntitiesTypes(DbContext context)
    {
        throw new NotImplementedException($"{typeof(ModelBuilderExtensions).GetTypeName()}");
    }


    /// <summary>
    /// Считывание атрибутов
    /// </summary>
    public static Dictionary<string, string> GetEntityContrainsts(Type type)
    {
        Dictionary<string, string> attrs = new Dictionary<string, string>();
        foreach (var data in type.GetCustomAttributesData())
        {
            if (data.AttributeType.IsExtendsFrom(typeof(ConstraintAttribute).Name))
            {
                foreach (var arg in data.ConstructorArguments)
                {
                    string value = arg.Value.ToString();
                    attrs[data.AttributeType.Name] = value;
                }
            }

        }
        return attrs;
    }
}
 