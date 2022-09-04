using ApplicationDb.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriceResourcePlaning.CustomerRelationModel
{
    public class TimeLimitTarrification: DictionaryTable 
    {
        
        public float Size { get; set; }
        
        public float Speed { get; set; }
        public string Unit { get; set; }
    }
}
