

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMVC.Views.Registration
{
    [Icon("person")]
    [Area("Login")]

    [Label("Регистрация")]
    [Description("Регистрация  ")]    
    public class RegistrationController: FunctionController<RegistrationModel>
    {
        //private readonly APIAuthorization _authorization;
        private readonly IEmailService _email;
        private readonly AuthorizationOptions _options;


        public override IActionResult Complete(RegistrationModel entity)
            => Redirect("/Home/Index");

        protected override string GetNext()
        {
            return "/Login";
        }

        public RegistrationController(
                APIAuthorization authorization,
                AuthorizationOptions options,
                IServiceProvider  services,
                IServiceProvider provider,
                IUserNotificationsService notifications,
                IEmailService email): base(provider, notifications, services)
        {
            _authorization = authorization;
            _email = email;
            _options = options;
        }


         
        private string GetBaseUrl()
        {
            return "/Login";
        }

        protected override void Do(RegistrationModel model)
        {
            _authorization.Signup(
                model.Email, model.Password, model.Confirmation,
                model.SurName, model.FirstName, model.LastName, (DateTime)model.Birthday, model.Tel);
        }

   
    }
}
