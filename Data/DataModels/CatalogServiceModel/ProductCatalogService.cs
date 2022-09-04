using DataEntities;

using Mvc_Apteka;
using Mvc_Apteka.Entities;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


public class ProductCatalogService
{

    public List<ProductCatalog> GetChilren(List<ProductCatalog> nodes, ProductCatalog parent)
    {
        return nodes.Where(p => p.Parent == parent).ToList();
    }
    public void AddNode(CatalogDataModel context, List<ProductCatalog> nodes, ProductCatalog pnode, int? parentId)
    {
        pnode.ParentID = parentId;
        context.ProductCatalogs.Add(pnode);
        context.SaveChanges();

        foreach(var node in GetChilren(nodes, pnode))
        {
            AddNode(context, nodes, node, pnode.ID);
            //MessageBox.Show("Контроль", $"ParentID={pnode.ParentID}; ParentName={pnode.Name}", MessageBoxButton.OK);
        }
    }
    public ProductCatalog GetRoot(IEnumerable<ProductCatalog> nodes)
    {
        var roots = nodes.Where(p => p.Parent == null);
        if (roots.Count() != 1)
        {
            throw new Exception($"Корень должен быть один а не {roots.Count()}");
        }
        return roots.First();
    }
    public void AddHier(CatalogDataModel context, List<ProductCatalog> nodes)
    {
        var roots = nodes.Where(p => p.Parent==null);
        if (roots.Count() != 1)
        {
            throw new Exception($"Корень должен быть один а не {roots.Count()}");
        }
        var root = roots.First();
        AddNode(context, nodes, roots.First(), null);
    }
        
    public void Print(TextWriter output, CatalogDataModel context, ProductCatalog catalog)
    {
        string message = GetQualificationString(context, catalog);
        output.WriteLine(message);
        foreach (var child in GetProductSubCatalogs(context, catalog)) 
        {
            Print(output, context, child);
        }
    }

    public List<string> GetQualification(CatalogDataModel context, ProductCatalog catalog)
    {
        List<string> qnames = (catalog.ParentID != null) ?
            GetQualification(context, context.ProductCatalogs.Find(catalog.ParentID)) :
            new List<string>();
        qnames.Add(catalog.Name);
        return qnames;
    }

    public List<ProductCatalog> GetProductSubCatalogs(CatalogDataModel context, ProductCatalog catalog)
        => context.ProductCatalogs.Where(c => c.Parent == catalog).ToList();

    public string GetQualificationString(CatalogDataModel context, ProductCatalog catalog)
    {
        string path = (catalog.ParentID != null) ?
            GetQualificationString(context, context.ProductCatalogs.Find(catalog.ParentID)) :
            "";
        path+=(catalog.Name)+"/";
        return path;
    }
}
