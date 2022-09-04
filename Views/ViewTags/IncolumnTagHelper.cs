using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class IncolumnTagHelper : TagHelper
{
    public override void Process(
            TagHelperContext context, 
                TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.SetAttribute("style", "display: flex; flex-direction: column; flex-wrap: nowrap; height: 100%;");         
    }
        
} 
