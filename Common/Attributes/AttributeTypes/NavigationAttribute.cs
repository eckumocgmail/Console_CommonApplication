using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class NavigationAttribute : Attribute
{
    protected string _property;

    public NavigationAttribute(string property)
    {
        this._property = property;
    }
}
 