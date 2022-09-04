using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


[Route("[controller]/[action]")]

public class ServiceController : ActionsController<APIAuthorization>
{
    public ServiceController(IServiceProvider provider) : base(provider)
    {
    }

    public override IActionResult Index() => View();
}
