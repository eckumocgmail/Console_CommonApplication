using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class ViewComponentStatistics : ViewComponent
{
    public IViewComponentResult Invoke(  )
    {
        return View("Raiting" );
    }
}
 
