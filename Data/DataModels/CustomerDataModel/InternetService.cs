﻿using ApplicationDb.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriceResourcePlaning.CustomerRelationModel
{
    public class InternetService : DictionaryTable 
    {
        public virtual List<SizeLimitTarrification> SizeTimeTarrifications { get; set; }


    }
}
