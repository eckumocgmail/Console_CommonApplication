






using ApplicationDb.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriceResourcePlaning
{


    /// <summary>
    /// Договор купли-продажы:  лица(покупатель, продавец, перечень товаров, реквизиты для оплаты)
    /// </summary>
    public class SaleAgreement: DictionaryTable
    {
        public override int ID { get; set; }
        public bool IsActive { get; set; } = false;

 

    }
}
