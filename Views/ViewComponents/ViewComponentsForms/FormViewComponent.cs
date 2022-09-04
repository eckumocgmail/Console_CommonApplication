using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMVC.ViewComponents
{
    public class FormViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke( Form Model )
        { 
            return View( "Form", Model );
        }
    }
}
