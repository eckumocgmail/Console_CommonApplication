using DataCommon;

using DataEntities;

using Microsoft.Extensions.Logging;

using MvcDeliveryAuth.Domains.Medical;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Контекст первичных данных
/// </summary>
public class MedicalDbInitializer: DeliveryDbContextInitiallizer<MedicalCustomer, MedicalServices, MedicalStore>
{
    public override IDictionary<string, int> Init(DeliveryDbContext<MedicalCustomer, MedicalServices, MedicalStore> context, string contentPath)
    {
        return base.Init(context, contentPath);
    }


    public override int InitProducts(DeliveryDbContext<MedicalCustomer, MedicalServices, MedicalStore> context, string contentPath)
    {        
        if (context.Products.Count() > 0)
            return 0;
        var products = ReadDataFromXmlFile(contentPath + "\\MedicalMarketplace\\input.xml");
        int ctn = products.Count();
        OverrideLogging.GetLogger<MedicalDbInitializer>().LogInformation(ctn.ToString());
        foreach (DATA p in products)
        {
            ctn=ctn-1;            
            context.Products.Add(new ProductItem()
            {
                ProductName = p.NAME
            });
        }
        int result = context.SaveChanges();
        return result;
    }


    /// <summary>
    /// Считывание данных из XML0-файла
    /// </summary>
    /// <param name="filename">путь к файлу</param>    
    public IEnumerable<DATA> ReadDataFromXmlFile( string filename )
    {
        var result = new List<DATA>();
        var ls = new List<LS>();

        using (var stream = new StreamReader(System.IO.File.OpenRead(filename)))
        {
            DataSet dataset = new DataSet();
            dataset.ReadXml(stream);

            foreach (DataRow row in dataset.Tables[0].Rows)
            {

                Console.WriteLine(row[0]);
                ls.Add(new LS()
                {
                    MNN = row[0].ToString(),
               
                    LS_Id = 1
                });
            }
            foreach (DataRow row in dataset.Tables[1].Rows)
            {

                Console.WriteLine(row[0]);
                result.Add(new DATA()
                {
                    NAME = row[0].ToString(),
                    PRICE = row[1].ToString(),
                    COUNT = row[2].ToString(),
                    LS_Id = 1
                });
            }
        }
        
        return result;
    }

    /// <summary>
    /// Geeration-скрипт
    /// </summary>    
    public string GetPrimaryDatabaseSql()
    {
        return @"
            CREATE TABLE [DBO].[LS](
              MNN nvarchar(max)
              LS_Id int primary identity(1,1)
            )
            GO
            CREATE TABLE [DBO].[DATA](
              NAME nvarchar(max),
              PRICE nvarchar(max),
              COUNT nvarchar(max),
              LS_Id int primary identity(1,1)
            )
            GO
        ";
    }

    /// <summary>
    /// Сведения о лекарственном препарате
    /// </summary>
    public class LS
    {
        public System.String MNN { get; set; }
        public System.Int32 LS_Id { get; set; }
    }


    /// <summary>
    /// Продажи лекарств
    /// </summary>
    public class DATA
    {
        public System.String NAME { get; set; }
        public System.String PRICE { get; set; }
        public System.String COUNT { get; set; }
        public System.Int32 LS_Id { get; set; }
    }

}
