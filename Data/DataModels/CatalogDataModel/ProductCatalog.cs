using Microsoft.EntityFrameworkCore;

using Mvc_Apteka.Entities;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Группировка продукции ( 1 ко многим )   
/// </summary>
//[Index(nameof(ProductCatalogName),nameof(ProductCatalogNumber))]
public class ProductCatalog: HierDictionary<ProductCatalog>
{
        
 
    




    [Required]
    public int ProductCatalogNumber { get; set; }

    [Required]
    public string ProductCatalogName { get; set; }
    public virtual ICollection<ProductInfo> Products { get; set; }


        

        

    public ProductCatalog()
    {
        this.Products = new List<ProductInfo>();
    }

    public ProductCatalog(ProductCatalog parent, string name)
    {
        this.ProductCatalogName = name;
        this.Parent = parent;
    }
}
