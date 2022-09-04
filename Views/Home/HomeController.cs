using ApplicationCore.Converter;

using CoreModel;



using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
 

[Label("Главная страница")]
[Icon("home")]
[Route("/[controller]/[action]")]
public class HomeController : NavigationController<DefaultNavigationModel>
{
    public HomeController(IServiceProvider provider) : base(provider)
    {
    }

    public IActionResult SkillsAverange() => View(new Highchart3dColumnInteractive());
    /// <summary>
    /// Левая выскакивающий панель
    /// </summary>        
    public IActionResult Privacy()
    {
        /*GetNavMenu()*/
        return View(  );
    }


    /// <summary>
    /// Левая выскакивающий панель
    /// </summary>        
    public IActionResult Left()
    {
        /*GetNavMenu()*/
        return ViewComponent("NavTree", new { Model= new Link() });
    }


    /// <summary>
    /// Индексируемая страница
    /// </summary>
    /// <returns></returns>
    public override IActionResult Index()
    {             
        ViewData["Title"] = "Главная страница";
        return View();
    }

    public IActionResult About()
    {
        ViewData["Title"] = "Главная страница";
        return View();
    }



    /// <summary>
    /// Генерация скриптов для клиентского плиложения
    /// </summary>
    /// <returns></returns>
    public IActionResult Download()
    {
        ConverterAngular.GenerateDataModelToTypeScript(
            @"D:\k.batov.io@outlook.com\EcKuMoC-ERP\v.4\ERP. Финансовый модуль\ERP\ClientApp\",
            new AppDbContext());
        return View("Index");
    }




  
       
    public IActionResult Error(ErrorViewModel Model)
    {
        return View(Model);
    }

     
}
 