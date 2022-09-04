using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class NavListViewComponent: ViewComponent
{
    public IViewComponentResult Invoke(object Model)=>View("NavList", Model);
}
