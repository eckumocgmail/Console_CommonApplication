using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc; 


public class ListItemController : BaseController 
{
    public ListItemController(IServiceProvider provider) : base(provider)
    {
    }

    public override IActionResult Index()
    {
        return View();
    }


    public IActionResult onClick(int hash)
    {
        Api.Utils.Info("OnClick " + hash);
        ViewItem model = (ViewItem)this.FindByHash(hash);
        if (model.Selectable)
        {

            model.Selected = model.Selected ? false : true;
            model.Changed = true;
            Api.Utils.Info("Selected " + hash);
        }
        return Ok();
    }

    private ViewItem FindByHash(int hash)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}
