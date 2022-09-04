using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreModel.DataConverter.ServerApp
{
    public class GenerateTestMethods
    {
        public void CreateTestClasses()
        {
            string path =
                @"D:\k.batov.io@outlook.com\EcKuMoC-ERP\v.4\" +
                @"ERP. Финансовый модуль\Login\Views\ViewControlles\";
            path.GetFiles().ForEach ((filename)=> {
                if (filename.EndsWith(".cs"))
                {
                    
                }
            });
        }

    }
}
