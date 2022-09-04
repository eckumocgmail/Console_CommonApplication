using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Linq;

public class RequireMethodNameResult : BadRequestResult
{
    protected string[] AvailableMethods;
    public RequireMethodNameResult(string[] AvailableMethods)
    {
        this.AvailableMethods = AvailableMethods;
    }
    public override void ExecuteResult(ActionContext context)
    {
        context.HttpContext.Response.ContentType = "text/html; charset=utf-8";

        context.HttpContext.Response.WriteAsync($"<form class='list-group' action=\"OnAuthSuccess\">").Wait();
        AvailableMethods.ToList().ForEach(method => {
            context.HttpContext.Response.WriteAsync($"<button style=\"width: 100%;\" class=\"btn btn-primary list-group-item\" onclick=\"alert('{method}')\">{method}</button>").Wait();
        });
        context.HttpContext.Response.WriteAsync($"</form>").Wait();

    }
}
