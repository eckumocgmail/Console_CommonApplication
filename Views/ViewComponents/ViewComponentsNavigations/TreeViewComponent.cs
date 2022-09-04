using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMVC.ViewComponents
{
    public class TreeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke( Tree Model )
        {
            return View("Tree",Model);
        }
    }
    
    
}
