using System;

namespace Managment.ApiControllers.ApiControllersManagment
{
    public class SalaryDepart
    {
        public string Depart { get; set; }
        public string Position { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Value { get; set; }
    }
}