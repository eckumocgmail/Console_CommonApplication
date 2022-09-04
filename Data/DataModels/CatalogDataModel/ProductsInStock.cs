using System.ComponentModel.DataAnnotations;
 
/// <summary>
/// Свеедния о продукции имеющейся в наличии на складе
/// </summary>
public class ProductsInStock: BaseEntity
{
 
    public int HolderID { get; set; }
    public int ProductID { get; set; }
    public int ProductCount { get; set; }
    public float ProductPrice { get; set; }
}
 