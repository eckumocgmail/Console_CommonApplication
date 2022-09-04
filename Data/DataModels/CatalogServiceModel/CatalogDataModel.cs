using static System.Console;
 
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using DataCommon;
using System.ComponentModel.DataAnnotations.Schema;
using Mvc_Apteka.Entities;
using DataEntities;
using System.Threading.Tasks;

public sealed class CatalogDataModel : DeliveryDbContext<ProductCustomer<SaleItem>, SaleItem, ProductHolder<SaleItem>>
{
    public CatalogDataModel()
    {
    }

    public CatalogDataModel(Action<DbContextOptionsBuilder> configure) : base(configure)
    {
    }

    public CatalogDataModel(DbContextOptions options) : base(options)
    {
    }

    public string GetConnectionString()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}



