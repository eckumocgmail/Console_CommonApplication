using ApplicationDb.Entities;

using System.Collections.Concurrent;
using System.Collections.Generic;

public interface APIAuthorizationOptions
{
    int CheckTimeout { get; }
    bool LogginAuth { get; }
    int SessionTimeout { get; }
}

/// <summary>
/// Параметры жизненого цикла обьектов сеанса
/// </summary>
public class AuthorizationOptions 
{



    public bool LogginAuth { get; set; } = true;
    public string UserCookie { get; set; } = "y";
    public string ServiceCookie { get; set; } = "x";
    public string ApplicationUrl { get; set; } = "https://localhost:5001;http://localhost:5000";
    public IEnumerable<string> GetApplicationUrls() => ApplicationUrl.Split(";");
    public bool EnableRecaptcha { get; set; } = true;
    public bool EnableEmailService { get; set; } = false;
    public ConcurrentBag<string> Providers { get; set; } = new ConcurrentBag<string>() { 
        "www.vk.com","www.google.com","www.yandex.ru"
    };

    public int KeyLength { get; set; } = 32;
    public int SessionTimeout { get; set; } = 32;
    public int CheckTimeout { get; set; } = 2000;
    /// <summary>
    /// Страница авторизации
    /// </summary>
    public string HomePagePath { get; set; } = "/User/Home";
    public string LoginPagePath { get; set; } = "/Signin";
    public string LogoutPagePath { get; set; } = "/Signout";


    /// <summary>
    /// Страница активации учетной записи
    /// </summary>
    public string ActivationRequirePath { get; set; } = "/Activation";

    /// <summary>
    /// Роль пользователя по умолчанию,
    /// присваивается пользователям после 
    /// проведеня процедуры регистрации
    /// </summary>
    public string PublicRole { get; set; } = "Users";
    public string PublicGroup { get; set; } = "Users";








    public AuthorizationOptions()
    {
        this.LogginAuth = true;
        this.SessionTimeout = 200;
        this.KeyLength = 32;
        this.UserCookie = "UserKey";
        this.ServiceCookie = "ServiceKey";
        this.CheckTimeout = 20;
        this.PublicRole = "User";
        this.EnableRecaptcha = true;
        this.EnableEmailService = true;
        this.PublicGroup = "User";            
    }




    /// <summary>
    /// Маршруты только для авторизованных пользователей
    /// </summary>  
    public Dictionary<string, List<string>> RoleValidationRoutes
        = new Dictionary<string, List<string>>() {
            { "User",       new List<string>{ "/UserFace" } },
            { "Admin",      new List<string>{ "/AdminFace" } },
            { "Analitic",   new List<string>{ "/Analitic" } },
            { "Boss",       new List<string>{ "/BossFace" } },
            { "Customer",   new List<string>{ "/CustomerFace" } },
            { "Reception",  new List<string>{ "/ReceptionFace" } },
            { "Support",    new List<string>{ "/SupportFace" } },
            { "Worker",     new List<string>{ "/WorkerFace" } },
            { "Developer",  new List<string>{ "/DeveloperFace" } },
    };
}
