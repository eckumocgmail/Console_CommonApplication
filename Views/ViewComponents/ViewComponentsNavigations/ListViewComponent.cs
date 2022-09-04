using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ViewComponent(Name = "List")]
public class ListViewComponent : ViewComponent
{
    protected ListService _service;
    protected IServiceProvider   _models;

    public ListViewComponent( ListService service, IServiceProvider   models) {
        _service = service;
        _models = models;
    }
 
    public IViewComponentResult Invoke(List Model)
    {
        //RegistrateModel(Model);
        _service.Update(Model);
        return View(nameof(List), Model);
    }
 
}