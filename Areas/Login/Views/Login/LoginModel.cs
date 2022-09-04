using ApplicationDb.Entities;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

using Newtonsoft.Json;

using ReCaptcha;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


public class LoginModel: InputPageModel<UserAccount>
{
    public LoginModel(IServiceProvider provider) : base(provider)
    {
    }

    [RecaptchaValidation("Подтвердите что вы не робот")]
    [FromForm(Name = "g-Recaptcha-Response")]
    [BindProperty(Name = "g-Recaptcha-Response")]
    [Display(Name = "g-Recaptcha-Response")]
    public string ReCaptcha { get; set; }
    


    [BindProperty]
   
    [Display(Name = "Электронный адрес")]
    [DataType(
        DataType.EmailAddress,
        ErrorMessage = "Электронный адрес задан некорректно"
    )]
    [NotNullNotEmptyAttribute( "Не указан электронный адрес")]
    public string Email { get; set; } = "";

 


    [BindProperty]
    [Display(Name = "Пароль для входа")]
    [DataType(DataType.Password)]
    [NotNullNotEmpty( "Не задан пароль для входа")]
    [MinLength(8, ErrorMessage = "Для пароля должна быть не менее 8 символов")]
    public string Password { get; set; } = "";

 



}
