using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreConstructorAngular.Data.DataAttributes.AttributeControls
{
    public class SelectDataDictionaryByQueryAttribute : ControlAttribute
    {
        private readonly string _sql;
       

        public SelectDataDictionaryByQueryAttribute(string sql)
        {
            _sql = sql;
        }




        public override ViewItem CreateControl(object field)
        {
            using (var db = new AppDbContext())
            {                
                db.Execute(_sql);
            }
            Dictionary<object, object> options = new Dictionary<object, object>();
            
            return new Select()
            {
                Options = options
            };
         
        }
    }
     
}