﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
namespace DataEntities
{
    /// <summary>
    /// Постамат/Устройтво хранения
    /// </summary>
    public class ProductHolder<TItem>: BaseEntity where TItem : SaleItem
    {
        [Key]
        public override int ID { get; set; }


        /// <summary>
        /// Номер постомата
        /// </summary>
        [SerialNumber("XXXX-XXX")]
        public string HolderSerial { get; set; }

        public bool HolderIsActive { get; set; }
        public string HolderLocation { get; set; }
        public string HolderToken { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<SaleOrder<TItem>> HolderOrders { get; set; }

        [JsonIgnore]
        public ICollection<ProductsInStock> ProductsInStock { get; set; }
    }
}
