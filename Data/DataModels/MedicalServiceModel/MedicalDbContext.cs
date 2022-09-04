using DataCommon;

using DataEntities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MvcDeliveryAuth.Domains.Medical
{



    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCustomer"></typeparam>
    /// <typeparam name="TItem"></typeparam>
    /// <typeparam name="THolder"></typeparam>
    public interface IMedicalDbContext : IDeliveryDbContext<MedicalCustomer, MedicalServices, MedicalStore>

    {

        /// <summary>
        /// Вывод текущего остатка медицинской продукции 
        /// </summary>        
        public void WriteState(StreamWriter stream);
    }



    public class MedicalDbContext : DeliveryDbContext<MedicalCustomer, MedicalServices, MedicalStore>, IMedicalDbContext
    {
        public MedicalDbContext()
        {
        }

        public MedicalDbContext(DbContextOptions options) : base(options)
        {
        }

        public void WriteState(StreamWriter stream)
        {
            
        }
        

    }
}
