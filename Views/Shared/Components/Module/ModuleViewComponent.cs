using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Модуль - javascript
/// </summary>
public class ModuleViewComponent: ViewComponent
{
    public async Task<ViewViewComponentResult> InvokeAsync( IEnumerable<string> scripts  )
    {
        await Task.CompletedTask;
        return View("Module", scripts);
    }
}