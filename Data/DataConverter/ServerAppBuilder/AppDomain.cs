using System;

namespace CoreGenerator
{
    class AppDomain
    {
        static void CreateTemplate(string[] args)
        {
            var shared = new CreateViewModule(@"D:\asp.net\MVC");
            //shared.CreeateViewModule("Button");


            var mvc = new CreateDomainModule(@"D:\asp.net\MVC\ApplicationLogic");
            mvc.AddArea("User");
            mvc.AddArea("Admin");
            mvc.AddArea("Employee");
            
            mvc.AddArea("Boss");
            mvc.AddArea("Customer");
            mvc.AddArea("Reception");
            mvc.AddArea("Developer");
            mvc.AddArea("Support");
            mvc.AddArea("Worker");
        }
    }
}
