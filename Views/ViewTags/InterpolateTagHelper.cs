using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Components.Forms;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Выполняет преобразование выражения, определённого через атрибут в разметку представления
/// </summary>
public class InterpolateTagHelper: TagHelper
{


    /// <summary>
    /// Разметка, включающая индикативные предикаты
    /// </summary>
    protected string _Template;


    /// <summary>
    /// Модель свойств представления
    /// </summary>
    public object Model { get; set; }



    /// <summary>
    /// Конструктор по-умолчанию
    /// </summary>
    public InterpolateTagHelper() {            
        _Template = AttrsUtils.GetRequiredTypeAttrValue( this, "ViewTemplate");      
    }



    /// <summary>
    /// Метод вывода разметки
    /// </summary>
    /// <param name="context">контекст вспомогательной функции тега</param>
    /// <param name="output">поток вывода</param>
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        string content = "";
        try
        {
                
            content = ObjectCompileExpExtensions.Expression.Interpolate(_Template, this);
        }
        catch(Exception ex)
        {
            content = $"<div class='alert alert-danger'>{ex.GetType().Name}: {ex.Message}</div>";
        }
        finally
        {
            output.TagName = "div";
            output.Content.AppendHtml(content);
        }
            
    }
}
