using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewComponents.NavComponents
{
    public class NavMenuViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke(Link Model)
        {
            return View("NavMenu", Model);
        }
    }
}
