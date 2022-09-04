

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// Выход пользователя из системы
/// </summary>
    
[Label("Выход")]
[Area("Login")]
[Icon("person")]
public class LogoutController: FunctionController<LogoutModel>
{
    //private readonly APIAuthorization _authorization;   
    private readonly AuthorizationOptions _options;

    public LogoutController(
            APIAuthorization authorization,
            AuthorizationOptions options,
            IServiceProvider  services,
            IServiceProvider provider,
            IUserNotificationsService notifications) : base(provider, notifications, services)
    {
        _authorization = authorization;          
        _options = options;
    }


    public override IActionResult Index() => Redirect($"/Logout/Logout");  


    /// <summary>
    /// Реализация операции
    /// </summary>   
    protected override void Do(LogoutModel model)
    {
        if (model.Confirmed)
        {
            _authorization.Signout();
            this.OnSignout();
        } 
            
    }

    private void OnSignout()
    {
    }


    /// <summary>
    /// URL к следующей операции
    /// </summary>        
    protected override string GetNext()
    {
        return "/Home/Index";
    }

    public override IActionResult Complete(LogoutModel entity)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}
