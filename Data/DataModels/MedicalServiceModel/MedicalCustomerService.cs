using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api
{

    /// <summary>
    /// Операции для фейса
    /// </summary>
    public interface MedicalCustomerService
    {
        // актуальные данные(прайс-лист), 
        // препарат, цена и остаток на текущий момент
        // отображается на главной странице
        public string GetPriceList();
    }



    /// <summary>
    /// Подключается к контексту каждого пользователя
    /// </summary>
    public class AnyUserApi: MedicalCustomerService
    {
        public AnyUserApi()
        {
        }


        // актуальные данные(прайс-лист), 
        // препарат, цена и остаток на текущий момент
        // отображается на главной странице
        public string GetPriceList()
        {
            throw new NotImplementedException($"{GetType().GetTypeName()}");
        }
    }
}
