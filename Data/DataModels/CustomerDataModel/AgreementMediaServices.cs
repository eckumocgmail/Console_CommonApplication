﻿using ApplicationDb.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriceResourcePlaning.CustomerRelationModel
{
    public class AgreementMediaServices : DictionaryTable 
    {

        public override int ID { get; set; }
        public int AgreementID { get; set; }
        public virtual List<MediaService> MediaServices { get; set; }
        public virtual List<InternetService> InternetServices { get; set; }
        
    }
}
