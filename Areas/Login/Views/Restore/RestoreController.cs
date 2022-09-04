

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMVC.Views.Restore
{
    /// <summary>
    /// Переход на страницу восстановления доступа к учетной записи
    /// </summary>
    
    [Icon("person")]
    [Label("Восстановление доступа")]
    [Area("Login")]

    [Description("На указанный адрес электронной почты отправлено письмл с дальнейшими инструкциями")]
    public class RestoreController : FunctionController<RestoreModel>
    {

        //private readonly APIAuthorization _authorization;
        private readonly AuthorizationOptions _options;
        //private readonly IUserNotificationsService _notifications;
        private readonly IEmailService _email;

        public RestoreController(
                IEmailService email,          
                IServiceProvider  services,
                IServiceProvider provider,
                AuthorizationOptions options,
                APIAuthorization authorization,
                IUserNotificationsService notifications) : base(provider, notifications,services)
        {
            _authorization = authorization;
            _notifications = notifications;           
            _email = email;
            _options = options;
        }

         


        /// <summary>
        /// Запрос на восстановления доступа к учетной записи
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
     
        protected override void Do(RestoreModel model)
        {
            _authorization.RestorePasswordByEmail(model.Email);
        }



        public override IActionResult Complete(RestoreModel entity)
            => Redirect("/Home/Index");

        protected override string GetNext()
            => "/Home/Index";
    }
}
