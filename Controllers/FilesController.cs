using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;







[Icon("folder")]
[Label(nameof(FilesController))]
[Description(@" онтроллер предназначен дл€ св€зывани€ операций ввода-вывода бинарных данных
    из файловых источников с другими системами хранени€ и обработчиками.")]
[Route("[controller]")]
[Route("[controller]/[action]")]
public class FilesController: BaseController 
{
    public FilesController
        (IServiceProvider models) : base(models)
    {
    }

    [HttpGet]
    public async Task<IActionResult> OnGet( 
        [FromServices] IWebHostEnvironment env,
        [FromHeader] string ActionName,
        [FromHeader] string ServiceName,
        [FromHeader] string UserAgent)
    {
        var message = HttpContext.ToRequestMessage();        
        return await ContentsNavList(env);
    }


    public IActionResult FilesList([FromServices] IWebHostEnvironment env) => this.ListView<string>($"{env.ContentRootPath}{HttpContext.Request.Path.ToString().Substring(GetType().GetNameOfType().Replace("Controller", "").Length + 1).ReplaceAll("/", @$"\")}".GetFiles());

    public async Task<IActionResult> ContentsNavList(IWebHostEnvironment env)
    {
        string filePath = $"{env.ContentRootPath}{HttpContext.Request.Path.ToString().Substring(GetType().GetNameOfType().Replace("Controller", "").Length + 1).ReplaceAll("/", @$"\")}";

        await Task.CompletedTask;

        this.Info(filePath);
        return ViewComponent("NavList", new NavList(new Dictionary<string, string>(filePath.GetFiles().Select(f => new KeyValuePair<string, string>(f, f)))));
    }
}