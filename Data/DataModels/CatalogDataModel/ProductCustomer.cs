using DataCommon;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 
public class ProductCustomer<TItem>: ActiveObject where TItem : SaleItem
{
    [Key]
    public override int ID { get; set; }


    /// <summary>
    /// Идентификатор учетной записи в Бд
    /// </summary>
    public int AccountId { get; set; }

    [Required]
    [MinLength(2)]
    public string LastName { get; set; }

    [Required]
    [MinLength(2)]
    public string FirstName { get; set; }

    [Required]
    [InputPhone]
    public string PhoneNumber { get; set; }

    [NotMapped]
    public IEnumerable<ProductCustomer<TItem>> CustomerOrders { get; set; }





}
 