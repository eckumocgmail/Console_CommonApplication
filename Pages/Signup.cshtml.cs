using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using ApplicationDb.Entities;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Mvc_WwwLogin.Pages;

using ReCaptcha;

namespace AppModel.Pages
{
    [AllowAnonymous]
    public class SignupModel : PageModel
    {
        public ReCaptchaService _reCaptchaService { get; }

        private readonly APIAuthorization _authorization;
        private readonly IEmailService _emailSender;

        public SignupModel(
            APIAuthorization authorization,
            ReCaptchaService reCaptchaService,
            IEmailService emailSender)
        {
            _reCaptchaService = reCaptchaService;
            _authorization = authorization;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string Message { get; set; }
        public string ReturnUrl { get; set; }
        public IList<string> ExternalLogins { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public class InputModel
        {

            [InputEmail]
            [Label("Электронная почта")]
            [NotNullNotEmpty(ErrorMessage = "Введите адрес электронной почты")]
            [BindProperty(Name = "Email")]
            public string Email { get; set; }

            [InputPassword]
            [NotNullNotEmpty(ErrorMessage = "Введите пароль")]
            [Label("Пароль")]
            [BindProperty(Name = "Password")]
            public string Password { get; set; }

            [Label("Подтвердите пароль")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Пароль отличается от подтверждения.")]
            public string ConfirmPassword { get; set; }
        }


 


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            this.Input = new InputModel();
            await Task.CompletedTask;
            Page();
        }



        public async Task<IActionResult> OnPostAsync([FromForm(Name = "g-recaptcha-response")] string Recaptcha, string returnUrl = null)
        {
            this.ReturnUrl = returnUrl;

            bool reCaptchaValidated = _reCaptchaService.Validate(Recaptcha);
            if (!reCaptchaValidated)
            {
                ModelState.AddModelError("ReCaptcha", Message="Подтвердите что вы не робот");
                return Page();
            }            
            else
            {
                return await OnAccountPosted();
            }
        }
        
        private async Task<IActionResult> OnAccountPosted()
        {
            var state = Input.Validate();
            if (state.Count() == 0)
            {
                MethodResult<UserApi> result = Signup(Input.Email, Input.Password);
                if (result.Success)
                {
                    _authorization.Signin(Input.Email, Input.Password, true);
                    await Task.CompletedTask;
                  
                    Message = "Регистрация успешно завершена";
                    if(ReturnUrl == null)
                    {
                        return Redirect(_authorization.GetUserHomeUrl());
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }
                    
                }
                else
                {
                    Message = "Ошибка при регистрации: "+ result.Exception;
                }                
            }
            ModelState.Add(state);
          
            await Task.CompletedTask;
            return Page();
        }

        private MethodResult<UserApi> Signup(string email, string password)
        {
            try
            {
                string tcpIp6 = HttpContext.Connection.RemoteIpAddress.MapToIPv6().ToString();
                UserApi user = _authorization.Signup(email, password, password,
                    "Батов", 
                    "Константин", 
                    "Александрович",  
                    DateTime.Parse("26.08.1989"), "7-904-334-1124");
                return MethodResult<UserApi>.OnResult(user);
            }
            catch (DbUpdateException ex)
            {
                return MethodResult<UserApi>.OnError(ex.InnerException);
            }
            catch (Exception ex)
            {
                return MethodResult<UserApi>.OnError(ex);
            }
        }

        private async Task ConfirmEmail(string returnUrl, UserAccount user)
        {
            await Task.CompletedTask;
            /*var code = await _authorization.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = user.ID, code, returnUrl },
                protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");*/
        }
    }
}
