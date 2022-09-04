 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[Label("Мониторин")]
public class Monitoring : DictionaryTable
{
   
    public virtual List<Indicator> Indicators { get; set; }
    public virtual List<Location> Locations { get; set; }




    public Monitoring()
    {

    }



    /// <summary>
    /// Получение квитанции, для выполнения операции( содержит защищенные данные )
    /// </summary>
    /// <returns></returns>
    public string GetToken()
    {
        return "".GenRandom(1024);
    }


    

}