using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class HierDictionaryExtensions
{

    /// <summary>
    /// 
    /// </summary>    
    public static IEnumerable<ValidationResult> Validate<T>(this HierDictionary<T> target,ValidationContext context) where T : BaseEntity
    {
        if (target.GetDbSet().Where(p => ((HierDictionary<T>)p).ParentID == null).Count() > 0)
        {
            if (target.ParentID == null)
                return new List<ValidationResult>() {
                    new ValidationResult("Иерархический справочник должен иметь единтсвуенный узел не уимеющих указателя на предка, в данный момент такой узел уже существует")
                };
        }
        return new List<ValidationResult>();
    }





    /// <summary>
    /// Получение пути от истока
    /// </summary>        
    public static string GetPath<T>(this HierDictionary<T> target,string separator) where T : BaseEntity
    {
        HierDictionary<T> parentHier = ((HierDictionary<T>)((object)target.Parent));
        return (target.Parent != null) ? parentHier.GetPath(separator) + separator + target.Name : target.Name;
    }



    /// <summary>
    /// Получение всех узлов по пути к корню, начинаю с вызывающего узла.
    /// </summary>        
    public static List<HierDictionary<T>> GetRootNodes<T>(this HierDictionary<T> target) where T : BaseEntity
    {
        var res = new List<HierDictionary<T>>();
        res.Add(target);
        HierDictionary<T> parentHier = ((HierDictionary<T>)((object)target.Parent));
        while (parentHier != null)
        {
            res.Add(parentHier);
            parentHier.Join("Parent");
            parentHier = ((HierDictionary<T>)((object)parentHier.Parent));
        }
        return res;
    }
    /// <summary>
    /// Исток
    /// </summary>
    /// <returns></returns>
    public static BaseEntity GetRoot<T>(this HierDictionary<T> target) where T : BaseEntity
    {
        BaseEntity p = target;
        while (p.GetValue("ParentID") != null && p.GetValue("ParentID") != p.GetValue("ID"))
        {
            p.Join("Parent");
            p = (BaseEntity)p.GetValue("Parent");
        }
        return p;
    }


    /// <summary>
    /// Потомки
    /// </summary>
    /// <returns></returns>
    public static List<HierDictionary<T>> GetChildren<T>(this HierDictionary<T> target) where T : BaseEntity
    {
        var children = new List<HierDictionary<T>>();
        using (var db = new AuthorizationDataModel())
        {
            children = ((IQueryable<HierDictionary<T>>)(db.GetDbSet(typeof(T).Name))).Where(p => p.ParentID == target.ID).ToList();
        }
        return children;
    }



    /// <summary>
    /// Модель представления иерархии
    /// </summary>
    /// <returns></returns>
    public static Tree ToTree<T>(this HierDictionary<T> target) where T: BaseEntity
    {
        var ChildNodes = new List<ViewNode>();
     
        //target.GetChildren<T>().ForEach(p => ChildNodes.Add(p.ToTree()));
        return new Tree()
        {
            Item = target,
            Children = ChildNodes
        };
    }
}

