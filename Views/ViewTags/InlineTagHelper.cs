using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
///     <div style="display: flex; flex-direction: row: flex-wrap: nowrap; width: 100%;"></div>
/// </summary>
public class InlineTagHelper : TagHelper
{

    public bool AlignToEnd { get; set; } = false;
    

    public override void Process(
            TagHelperContext context, 
                TagHelperOutput output)
    {
        output.TagName = "div";
        string justifyContent = AlignToEnd ? "flex-end" : "flex-start";
        output.Attributes.SetAttribute("style", "display: flex; flex-direction: row; flex-wrap: nowrap; width: 100%;  ");         
    }
        
} 

