
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDb.Types
{
    /// <summary>
    /// Фиксирует события бизнес процессов
    /// </summary>
    public class FactsTable
    {

        [Required(ErrorMessage ="Необходимо указать дату")]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        [DisplayName("Календарь")]
        public int CalendarID { get; set; }
        public virtual TimePoint Calendar { get; set; }
    }
}
