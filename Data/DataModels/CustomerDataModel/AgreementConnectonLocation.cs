﻿using ApplicationDb.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriceResourcePlaning.CustomerRelationModel
{
    public class AgreementConnectonLocation : DictionaryTable 
    {
        public override int ID { get; set; }

        public int CustonerInfo { get; set; }
    }
}
