using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

[ViewComponent(Name = "ListItem")]
public class ListItemViewComponent : ViewComponent
{
    protected ListItemService _service;

    public ListItemViewComponent(ListItemService service) {
        _service = service;
    }

    public IViewComponentResult Invoke(ListItem Model)
    {
        return View(nameof(ListItem),_service.Update(Model));
    }
}