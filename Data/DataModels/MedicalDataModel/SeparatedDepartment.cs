using ApplicationDb.Types;
using Managment.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
[Label("Обособленные подразделения")]
public class SeparatedDepartment<TOrganization> : DictionaryTable where TOrganization: BaseOrganization
{
   

    public SeparatedDepartment()
    {
        Employees = new List<Employee>();
    }

    [Label("Организация")]
    public int OrganizationID { get; set; } 

    [Label("Организация")]
    public virtual TOrganization Organization { get; set; }


    [Label("Сотрудники")]
    public virtual List<Employee> Employees { get; set; }
 


    [Label("Физический адрес")]
    public int LocationID { get; set; }

    [Label("Физический адрес")]
    public virtual Location Location { get; set; }


    [Label("Помещения")]
    public virtual List<Room> Rooms { get; set; }
}