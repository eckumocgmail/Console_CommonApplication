 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ModelsDataSource
{
    public static string DefaultConnectionString =
        @"Driver={SQL Server};Server=CCPL-1728\SQLServer;Database=ClassicModels;Trusted_Connection=True;MultipleActiveResultSets=True";

    public IDatabaseMetadata Metadata { get; set; }
    public DatabaseManager Manager { get; set; }
    public IDataSource Source { get; set; }


    


         

         
    public void ImportData()
    {

        //Manager.ImportFromCsvFile("Customers", @"A:\Databases\ClassicModels\datafiles\Customers.txt");
        //Manager.ImportFromCsvFile("Employees", @"A:\Databases\ClassicModels\datafiles\Employees.txt");
        //Manager.ImportFromCsvFile("Offices", @"A:\Databases\ClassicModels\datafiles\Offices.txt");
        //Manager.ImportFromCsvFile("OrderDetails", @"A:\Databases\ClassicModels\datafiles\OrderDetails.txt");
        //Manager.ImportFromCsvFile("Orders", @"A:\Databases\ClassicModels\datafiles\Orders.txt");
        //Manager.ImportFromCsvFile("Payments", @"A:\Databases\ClassicModels\datafiles\Payments.txt");
        //Manager.ImportFromCsvFile("Products", @"A:\Databases\ClassicModels\datafiles\Products.txt");
            
    }


}
