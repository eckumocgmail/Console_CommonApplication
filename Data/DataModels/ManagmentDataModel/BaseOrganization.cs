

using Managment.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Label("Организация")]
public class BaseOrganization : DictionaryTable 
{

    [Label("ИНН")]
    [InputText()]
    public string INN { get; set; }

    [Label("Юридический адрес")]
    [InputNumber]
    public int JuristicalLocationID { get; set; }

    [Label("Юридический адрес")]
    [InputHidden(true)]
    public virtual ManagmentLocation JuristicalLocation { get; set; }


    [NotInput]
    [Label("Обособленные подразделения")]
    public List<Department> ManagmentDepartments { get; set; }


    
}