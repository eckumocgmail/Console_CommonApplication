
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class DiagramCustomizer 
    {        
        public JArray dataset { get; set; }
        public List<Int64> granularities { get; set; }

        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }

        public JArray indicators { get; set; }
        public JArray locations { get; set; }



        public DiagramCustomizer() { }



        public object RequestData(string beginDate, string endDate, Int64 granularity, JArray indicators, JArray locations)
        {
            if (indicators == null)
            {
                throw new ArgumentNullException("indicators argument references to null pointer");
            }
            if (beginDate == null)
            {
                throw new ArgumentNullException("beginDate argument references to null pointer");
            }
            if (endDate == null)
            {
                throw new ArgumentNullException("endDate argument references to null pointer");
            }
            if (locations == null)
            {
                throw new ArgumentNullException("locations argument references to null pointer");
            }
            string sindicators = indicators.ToString().Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "");
            string slocations = locations.ToString().Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "");
            string sqlQuery = "select * from datainput where indicator_id in (" + sindicators + ") and subject_id in(" + slocations + ") and begin_date between '" + beginDate + "' and '" + endDate + "' and granularity_id = " + granularity + " order by begin_date,subject_id,indicator_id";
            return GetDataSource().Execute(sqlQuery);
        }

        private DatabaseManager GetDataSource()
        {
            throw new Exception();
        }
    }
