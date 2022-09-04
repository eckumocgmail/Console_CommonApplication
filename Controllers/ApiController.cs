using DataConverter.Generators;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

[Route("[controller]/[action]")]
[Label("(API)Application Program Interface")]
[Description(
    "Контроллер предназначен для предоставление информации" +
    " о сервисах приложения.")] 
public class ApiController : InputController<Form> 
{
    private readonly NameServiceProvider _namespace;
    //[Service] public override AuthorizationDataModel _context { get; set; }

    public ApiController(  NameServiceProvider @namespace, IServiceProvider provider):base(provider)
    {
        _namespace = @namespace;
        this.Init(provider);
    }

   

    // https://localhost:5001/Api/SaveJavaScript?dir=D:\NetProjectsAngular\ClientApp\src\serv
    public async Task SaveJavaScript(string dir)
    {
        foreach(var kv in new ControllerGenerator(_provider).GetWebApi())
        
            Path.Combine(dir, kv.Key+".ts").ToString().WriteText(kv.Value);   
        
        await Task.CompletedTask;
    }

    public async Task JavaScript()
    {
        string javascript = new ControllerGenerator(_provider).GetWebApi().ToJsonOnScreen();
        await HttpContext.Response.WriteAsync(javascript);
    }

    /// <summary>
    /// Намиенования сервисов
    /// </summary>
    [HttpGet("")]
    [HttpGet("/")]
    public virtual IActionResult Start() => this.Index();
    public override IActionResult Index() => 
        ListView<string>(
            "1,2,3".Split(","),
            (title) => {
                HttpContext.Response.Redirect($"/Api/Actions?service={title}");
            }
        );
    public virtual IActionResult List() => 
        ListView<string>(
            _namespace.GetServiceNames().ToList(),
            (title) => {
                HttpContext.Response.Redirect($"/Api/Actions?service={title}");
            }
        );
    

    /// <summary>
    /// Список операций реализованных сервисом
    /// </summary>    
    public IActionResult Actions(string service)
    {
        var type = service.ToType();
        if( type != null)
        {
            return ListView<string>(type.GetOwnMethodNames().ToList());
        }
        else
        {
            return AlertView("Не правильно задан тип сервиса");
        }
    }

    /// <summary>
    /// Модель конечных точек HTTP
    /// </summary>    
    //public MyApplicationModel Model() => CreateModels();

    /// <summary>
    ///  Результаты тестирования
    /// </summary>    
    public TestReport Test() => new TestCommonApplication().DoTest();

    /// <summary>
    /// Просмотр отчета
    /// </summary>
    /// <returns></returns>
    public IActionResult Report() => View(Test());
    public IActionResult Http404() => View( );



    /// <summary>
    /// Диаграмма классов модели BIRT
    /// </summary>
    /// <returns></returns>
    public IActionResult GetClassDiagram()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        return PartialView("Page", new TreeViewService().CreateAscendant(new List<Type>(assembly.GetTypes()), (type) => type.BaseType).First());
    }

    public override IActionResult Complete(Form entity)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}