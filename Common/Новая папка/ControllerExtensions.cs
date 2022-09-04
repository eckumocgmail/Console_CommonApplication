 
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;



public static class ControllerExtensions2
{

    public static MyControllerModel GetModel(this ControllerActionEndpointConventionBuilder ctrl) =>
        CreateModel(ctrl.GetType());

    private static MyControllerModel CreateModel(Type type)
    {
        throw new NotImplementedException($"{typeof(MyControllerModel).GetTypeName()}");
    }

    public static IActionResult Comp( 
        this Controller controller, object model )
        => controller.PartialView(model.GetType().GetNameOfType(), model);
}