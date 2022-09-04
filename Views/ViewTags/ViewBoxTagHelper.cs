using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

/// <summary>
/// Создаёт блок реализующий стили определённые в модели компонента представления/StyledItem.
/// Предполагается что такой блок является корневым элементов представления компонента,
/// остальной контент представления нужно включать как внутренний элемент.
/// </summary>
public class ViewBoxTagHelper : TagHelper
{
    protected CssSerializer _css;

    public ViewItem style { get; set; }

    public ViewBoxTagHelper(CssSerializer css)
    {
        _css = css;
    }


    public override void Process( TagHelperContext context, TagHelperOutput output )
    {
        if (this.style == null)
        {
            throw new System.Exception("Следует задать атрибут style для вспомогательной функции тега "+GetType().Name);
        }
        output.TagName = this.style.Tag;
        

        string[] options = ReflectionService.GetOwnPropertyNames(typeof(StyledItem)).ToArray();
        Dictionary<string,object> valuesMap = Formating.ToDictionary(style, options);
        
        string cssText = _css.Seriallize(valuesMap, AttrsUtils.ForAllPropertiesInType(typeof(StyledItem)));        
        Api.Utils.Info(cssText);
        output.Attributes.SetAttribute("style", cssText);
        output.Attributes.SetAttribute("class",this.style.ClassAttr);
        output.Attributes.SetAttribute("id","view"+style.GetHashCode());
        if(this.style.Draggable){
            output.Attributes.SetAttribute("draggable", "true");
        }
        if(this.style.Dropable){
            output.Attributes.SetAttribute("droppable", "true");
        }
        
        //output.Attributes.SetAttribute("contenteditable", "true");
        
        if(style.Visible == false)
        {
            output.Attributes.SetAttribute("hidden", "true");
        }        
    }

} 
