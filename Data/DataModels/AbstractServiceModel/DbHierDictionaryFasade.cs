using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections;

 

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class DbHierDictionaryFasade<T> : EntityFasade<T>, IHierDictionaryFasade<T>  where T: HierDictionary<T>
{
    public TreeViewService treeViewService = new TreeViewService();

    public DbHierDictionaryFasade(IDbContext context) : base(context)
    {
    }
 
    public Tree GetRoot() => treeViewService.CreateFromHierDictionary(this.GetDbSet());
    public class Tree
    {

    }
    public class TreeViewService
    {
        public Tree CreateFromHierDictionary(DbSet<T> ts)
        {
            throw new NotImplementedException($"{GetType().GetTypeName()}");
        }
    }

    object IHierDictionaryFasade<T>.GetRoot()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}


 