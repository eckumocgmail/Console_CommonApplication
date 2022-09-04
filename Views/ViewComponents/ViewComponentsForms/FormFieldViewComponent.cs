using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMVC.ViewComponents
{
    public class FormFieldViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke( FormField Model )
        {
            return View(Model.Type == null ? "Text" : Model.Type, Model);
        }
    }
}
