  

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

[Label("Авторизация пользователя")]
[Icon("Авторизация пользователя")]
[Description("Авторизация пользователя")]
public class UserLogin: MethodResult<FileEntity>
{
    [InputEmail("Электронный адрес задан некорректно")]
    [Label("Электронный адрес")]
    [NotNullNotEmpty("Не указан электронный адрес")]
    [Icon("email")]
    [UniqValue("Этот адрес электронной почты уже зарегистрирован")]
    [JsonProperty("Email")]
    public string Email { get; set; }


    [Label("Пароль")]
    [NotNullNotEmpty]
    [InputPassword()]
    [NotMapped]

    [JsonProperty("Password")]
    public string Password { get; set; }

    public UserLogin()
    {
    }

    public UserLogin(string email, string password)
    {
        Email = email;
        Password = password;
    }
}

 