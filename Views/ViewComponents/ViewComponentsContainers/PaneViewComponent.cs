using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMVC.ViewComponents
{
    public class PaneViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke( Pane Model )
        {
            return View("Pane", Model );
        }
    }
}
