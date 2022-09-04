using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewComponents.NavComponents
{
    public class NavTreeViewComponent: ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync(ILink Model)
        {
            await Task.CompletedTask;
            return View("NavTree", Model);
        }
         
    }
}
