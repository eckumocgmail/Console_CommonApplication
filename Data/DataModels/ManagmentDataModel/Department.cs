


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Managment.DataModel
{
    /// <summary>
    /// Даталогическая модель сущности "Подразделение".
    /// </summary>
    [Label("Подразделение")]
    [SearchTerms(nameof(Name) + "," + nameof(Description))]
    public class Department : DictionaryTable
    {

        [SelectDataDictionary(nameof(Department)+",Name")]
        public string Type { get; set; }
        public Department()
        {
            Employees = new List<Employee>();
        }

        [Label("Организация")]
        public int OrganizationID { get; set; } = 1;

        [Label("Организация")]
        public virtual BaseOrganization Organization { get; set; }


        [Label("Сотрудники")]
        public virtual List<Employee> Employees { get; set; }





    }
}