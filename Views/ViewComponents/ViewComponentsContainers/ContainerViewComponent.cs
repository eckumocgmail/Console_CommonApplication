using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMVC.ViewComponents
{
    public class ContainerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke( Container Model )
        {
            return View("FlexContainer", Model );
        }
    }
}
