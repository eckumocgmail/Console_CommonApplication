
using ApplicationDb.Entities;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Area("Login")]

[Icon("person")]
[Label("Активация учетной записи")]    
public class ActivationController: FunctionController<ActivationModel>
{
  
    //private readonly APIAuthorization _authorization;
    private readonly AuthorizationOptions _options;

    public ActivationController(
            APIAuthorization authorization,
            IServiceProvider provider,
            AuthorizationOptions options,
            IUserNotificationsService notifications,
            IServiceProvider session) : base(provider, notifications,session)
    {
        _authorization = authorization;
        _options = options;
    }


        


    /// <summary>
    /// Активация учетной записи
    /// </summary>
    /// <param name="id">ключ активации</param>
    /// <returns></returns>
    [HttpGet("[controller]/[action]")]
    private async Task<IActionResult> Activate([FromRoute] string id)
    {
        string activationKey = id;
        UserApi user = _authorization.Verify();
        if (user != null)
        {
            var account = await _authorization.GetAccountByID(user.Account.ID);
            if (account.ActivationKey == id)
            {
                account.Activated = DateTime.Now;
                account.Update();
            }
            return View("ActivationComplete");
        }
        else
        {
            return View();
        }
    }

/*    /// <summary>
    /// Переход на страницу активации учетной записи
    /// </summary>
    /// <returns></returns>
    [HttpGet("[controller]/[action]")]
    public IActionResult ActivationRequire()
    {
        ApplicationDb.Entities.User user = _authorization.Verify();
        if (user != null)
        {
            if (_authorization.IsActivated() == false)
            {
                return View(new ActivationModel()
                {
                    Email = user.Account.Email
                });
            }
            else
            {
                return RedirectToAction("Home", "Index");
            }
        }
        else
        {
            return RedirectToAction("Login");
        }
    }*/


    /// <summary>
    /// Выполнение процедуры активации учетной записи
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    //[HttpPost]
    protected override void Do(ActivationModel model)
    {
        UserApi user = _authorization.Verify();
        if (user != null)
        {
            if ((_authorization.GetAccountByID(user.Account.ID).Result).ActivationKey == model.ActivationKey)
            {
                UserAccount account = (_authorization.GetAccountByID(user.Account.ID).Result);
                _authorization.Verify().Account.Activated = account.Activated = DateTime.Now;
                account.Update();
                     
            } 

        } 
               
    }

    protected override string GetNext()
    {
        return "/Home/Index";
    }

    public override IActionResult Complete(ActivationModel entity)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}
 