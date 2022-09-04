 
using Microsoft.EntityFrameworkCore.Migrations.Operations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreModel.Ananlitics.DeployDataModel
{
    public class ApplicationMigration : DictionaryTable
    {
        public int SystemsIntegrationID{ get;set; }


        public ApplicationMigration()
        {
            Operations = new List<ApplicationUpgrade>();
        }



        public int Version { get; set; }



        public virtual List<ApplicationUpgrade> Operations { get; set; }

        public virtual ApplicationUpgrade CreateStep()
        {
            var upgrade = new ApplicationUpgrade();
            Operations.Add(upgrade);
            upgrade.Order = (Operations.Count+1);
            return upgrade;
        }
    }
}
