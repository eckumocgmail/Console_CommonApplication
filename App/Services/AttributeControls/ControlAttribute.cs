using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public abstract class ControlAttribute: Attribute
{
    public abstract object CreateControl(object field);

}

