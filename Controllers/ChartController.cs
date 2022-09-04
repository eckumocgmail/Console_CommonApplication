using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("[controller]/[action]")]
public class ChartController : BaseController 
{
    private readonly IAnaliticsServiceModel analitics;

    public ChartController(IServiceProvider models, [FromServices] IAnaliticsServiceModel analitics) : base(models)
    {
        this.analitics = analitics;
    }
 
    

    public object MoreUsableSkills()
    {
        return analitics.MoreUsableSkills();
    }

    public object Test()
    {
        return CreateReport(DateTime.Parse("01.01.2022"),3, new int[] { }, new int[] { });
    }

    public object CreateReport(DateTime begin, int time, int[] locations, int[] indicators)
    {
        return analitics.CreateReport(begin, time, locations, indicators);
    }

     
}
