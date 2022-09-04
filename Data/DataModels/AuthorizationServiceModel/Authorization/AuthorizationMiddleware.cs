using System;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Http;


/// <summary>
/// Компонент промежуточного ПО выполняет ограничение доступа пользователей на уровне маршрутов
/// по результатам проверки авторизации и принадлежности пользователя к той или иной роли.
/// Сущность РОЛЬ имеет иерархическую структуру права доступа наследуются от родительской роли к потомку
/// </summary>
public class AuthorizationMiddleware
{
    private RequestDelegate _next;
    private INavigationService _navigation;
    private APIAuthorization _authorization;
    private AuthorizationOptions _options;

    public AuthorizationMiddleware( RequestDelegate next )
    {
        _next = next;

    }

    public async Task Invoke( HttpContext http,                   
                   INavigationService navigation,
                    APIAuthorization authorization,
                     AuthorizationOptions options)
    {
        _navigation = navigation;
        _authorization = authorization;
        _options = options;

        string path = http.Request.Path.ToString();
        _navigation.Navigate(path);
        if (path=="/"|| path == "")
        {
            http.Response.Redirect(_options.LoginPagePath);
            return;
        }

        this.LogInformation(path);
        try
        {
            await CheckUserInRole(http,path);
            await CheckActivation(http,path);
         
            this.LogInformation($"передача управления: {path}");
            await _next.Invoke(http);
        }
        catch(Exception ex)
        {
            WriteError(http,ex);
        }
    }



    private async Task CheckUserInRole(HttpContext http, string path)
    {
        // фильтрация запросов пользователей не принадлежащих к заданным ролям
        await Task.CompletedTask;
        foreach (var pair in _options.RoleValidationRoutes)
        {
            string roleName = pair.Key;
            foreach (string rolePath in pair.Value)
            {
                if (path.StartsWith(rolePath))
                {
                    if (_authorization.IsSignin() && _authorization.IsActivated() == false)
                    {
                        if (!path.StartsWith(_options.ActivationRequirePath))
                        {
                            this.LogInformation($"denied request to: {path}");

                            http.Response.Redirect(_options.ActivationRequirePath);
                            return;
                        }
                    }
                    else
                    {

                        if (_authorization.IsUserInRole(roleName) == false)
                        {
                            this.LogInformation($"denied request to: {path}");
                            //user.Error("Доступ запрещён");
                            http.Response.Redirect(_options.LoginPagePath);
                            return;
                        }
                    }

                }
            }
        }
    }



    // страница активации доступа только авторизованным пользователям,
    // остальные перенаправляются на страницу авторизации
    private async Task CheckActivation(HttpContext http,string path)
    {

        if (IsActivationRequire(path))
        {
            if (_authorization.IsSignin() == false)
            {
                this.LogInformation($"denied request to: {path}");
                //user.Error("Доступ запрещён");
                http.Response.Redirect(_options.LoginPagePath);
                return;
            }
            else
            {
                if (_authorization.IsActivated() == false)
                {
                    this.LogInformation($"commit request to: {path}");
                    await _next.Invoke(http);
                    return;
                }
                else
                {

                    http.Response.Redirect("/Home/Index");
                    return;
                }
            }
        }
    }

    private bool IsActivationRequire(string path)
    {
        return false;
    }

    private void WriteError(HttpContext http, Exception ex) {
        http.Response.StatusCode = 500;
        http.Response.WriteAsync("<div class='alert alert-error'>" + ex.Message + "</div>");
        http.Response.WriteAsync("<div class='alert alert-warning'>" + ex.StackTrace + "</div>");
    }
}
