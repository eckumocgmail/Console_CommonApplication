
using DataEntities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

using Mvc_Apteka.Controllers;

 

using Newtonsoft.Json;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Mvc_Apteka 
{
    /// <summary>
    /// Реализация импорта-экспорта файлов в формате json
    /// </summary>
    public class ProductsJsonController:  Controller
    {
        private readonly CatalogDataModel appDbContext;
     

        public ProductsJsonController(CatalogDataModel appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        /// <summary>
        /// Экспорт файла с данными JSON
        /// </summary>
        public async Task<byte[]> GetDataForExport(  )
        {
            await Task.CompletedTask;
            string json = JsonConvert.SerializeObject(this.appDbContext.ProductInfos.ToList());
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            return bytes;
        }

       

 
       /* private void ImportProducts(IEnumerable<ProductInfo> records)
        {
            foreach (var product in records)
            {
                ProductInfo info = appDbContext.GetProductInfo(product.ProductName);
                if (info == null)
                {
                    appDbContext.ProductInfos.Add(new ProductInfo()
                    {
                        ProductName = product.ProductName,
                        ProductCount = product.ProductCount,
                        ProductPrice = product.ProductPrice
                    });
                }
                else
                {
                    ProductInfo p = appDbContext.GetProductInfo(product.ProductName);
                    if (appDbContext.Equals(p, product.ProductName, product.ProductPrice, product.ProductCount) == false)
                    {
                        p.ProductName = product.ProductName;
                        p.ProductCount = product.ProductCount;
                        p.ProductPrice = product.ProductPrice;
                    }
                }
            }
            appDbContext.SaveChanges();
        }*/
    }
}
