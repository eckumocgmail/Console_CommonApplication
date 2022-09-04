using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
 

using Microsoft.AspNetCore.Authentication;
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ReCaptcha;

namespace Mvc_WwwLogin.Pages
{
    public class SigninModel : PageModel
    {
        public readonly ReCaptchaService _reCaptchaService;
        public readonly APIAuthorization _signinManager;
        public readonly AuthorizationOptions _options;
        public readonly IUserNotificationsService _notifications;
        private readonly Service _service;

        public SigninModel(
            Service service,
            IUserNotificationsService notifications,
            AuthorizationOptions options,
            APIAuthorization signinManager,
            ReCaptchaService reCaptchaService):base()
        {
            this._service = service;
            this._options = options;
            this._notifications = notifications;
            this._reCaptchaService = reCaptchaService;
            this._signinManager = signinManager;
          
        }

        [BindProperty]
        public InputModel Input { get; set; }

   
        public IEnumerable<string> PreScipts { get; set; } = new List<string>();
        public IEnumerable<string> PostScipts { get; set; } = new List<string>();

        
        [TempData]
        public string Message { get; set; }
        public string ReturnUrl { get; set; }
        public IEnumerable<string> ExternalLogins { get; set; }
        public AuthenticationProperties ExternalScheme { get; private set; }

        public class InputModel
        {


            [Required(ErrorMessage = "Введите электронную почту")]
            [Label("Электронная почта")]
            [EmailAddress]
            public string Email { get; set; } = "eckumocuk@gmail.com";


            [Required(ErrorMessage = "Введите пароль")]
            [Label("Пароль")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = "eckumocuk@gmail.com";


            [Display(Name = "Запомнить меня")]
            public bool RememberMe { get; set; } = true;


        }


        public async Task OnGetAsync(string returnUrl = null)
        {             
            ReturnUrl = returnUrl;
            this.Input = new InputModel();
            await Task.CompletedTask;
        }

    

        public async Task<IActionResult> OnPostAsync([FromForm(Name = "g-recaptcha-response")] string Recaptcha, string returnUrl = null)
        {
            this.ReturnUrl = returnUrl;
            this.LogInformation($"OnPostAsync()");
            await Task.CompletedTask;
            bool reCaptchaValidated = _reCaptchaService.Validate(Recaptcha);
            if (!reCaptchaValidated)
            {
                this.LogInformation(ModelState.IsValid.ToString());
                ModelState.AddModelError("ReCaptcha", "Подтвердите что вы не робот");
                return Page();
            }            
            if (ModelState.IsValid)
            {
                string provider = _service.Name;
                var result = _signinManager.Signin(Input.Email, Input.Password, true   );
                if (result!=null)
                {
                    _notifications.Info("Выполнен вход");

                    if (String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(_signinManager.GetUserHomeUrl());
                    }
                    else
                    {
                        
                        return Redirect(ReturnUrl+"?SecretKey="+ result.SecretKey+"&provider="+provider);
                    }
                    
                }                
                else
                {
                    ModelState.AddModelError(string.Empty, "Учётные данные не зарегистрированы");
                    return Page();
                }
            }            
            return Page();
        }
    }
}
