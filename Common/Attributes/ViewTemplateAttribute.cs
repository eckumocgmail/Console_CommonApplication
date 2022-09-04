using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Атрибут используется для формирования HTML-контента
/// </summary>
public class ViewTemplateAttribute : Attribute
{
    protected string _template;

    public Dictionary<int, string> Options { get; set; }

    public ViewTemplateAttribute(string template)
    {
        if ((this._template = template) == null)
            throw new ArgumentNullException(template);
    }


}

