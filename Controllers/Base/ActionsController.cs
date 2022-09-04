using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public abstract class ActionsController<TService> : FormsController 
{
    private readonly TService _service;
     
    protected ActionsController(IServiceProvider provider) : base(provider)
    {
        try
        {            
            this._service = provider.Get<TService>();
        }catch(Exception ex)
        {
            this.Error(ex);
        }
    }

    public MethodResult<object> Activate(RequestMessage entity)
    {
        try
        {
            this.Info($"{_service.GetType().GetNameOfType()}({entity.ToJsonOnScreen()})");
            object result = _service.Invoke(entity.ActionName, entity.GetArguments());
            this.Info($" <= {result.ToJsonOnScreen()}");
            return MethodResult<object>.OnResult(result);

        }
        catch (Exception ex)
        {
            return MethodResult<object>.OnError(ex);
        }
    }

    public   IActionResult Complete(RequestMessage entity)
    {
        var result = this.Activate(entity);
        if (result.Success)
        {
            this._notifications.Info("Успешно выполнено: "+result.ToJsonOnScreen());
            return RedirectToAction("Get");
        }
        else
        {
            
            this._notifications.Error("Завершено с ошибкой: " + result.ToJsonOnScreen());
            return RedirectToAction("Get");
        }        
    }
}