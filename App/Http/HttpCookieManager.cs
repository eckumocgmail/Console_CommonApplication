using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Concurrent;

/// <summary>
/// Вспомогтельная служба, управляет данными браузера Cookies
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class HttpCookieManager
{
    protected IHttpContextAccessor _accessor;
    protected ConcurrentDictionary<string, string> _cookies;

    public HttpCookieManager(IHttpContextAccessor accessor)
    {
        _cookies = new ConcurrentDictionary<string, string>();
        _accessor = accessor;
        if (_accessor != null && _accessor.HttpContext!=null)
        {
            foreach (var cookie in _accessor.HttpContext.Request.Cookies)
                _cookies[cookie.Key] = cookie.Value;
        }
        
        
    }

    /// <summary>
    /// Установка значения свойства Cookiw 
    /// </summary>
    /// <param name="key">ключ к свойству</param>
    /// <param name="value">значение свойства</param>
    /// <returns>устнавленное значение</returns>
    public string SetCookie(string key, string value)
    {        
        this.LogInformation($"SetCookie: {key}={value}");
        try
        {
            if (_cookies.ContainsKey(key))
            {
                if (_cookies[key] != value)
                {
                    RemoveCookie(key);
                }
                else
                {
                    return value;
                }
            }
            if (_accessor != null && _accessor.HttpContext != null)
            {
                if (_accessor.HttpContext.Response.HasStarted == false)
                {
                    _accessor.HttpContext.Response.Cookies.Append(key, value);
                    _cookies[key] = value;
                }
            }
            return value;
        }
        catch (Exception ex)
        {
            throw new Exception("Исключение в SetCookie()",ex);
        }
    }



    /// <summary>
    /// Получение значения свойства
    /// </summary>
    /// <param name="key">ключ свойства</param>
    /// <returns>значение свойства</returns>
    public string GetCookie(string key)
    {
        try
        {
            if (_accessor == null || _accessor.HttpContext == null || _accessor.HttpContext.Request == null || _accessor.HttpContext.Response.Cookies == null)
                return null;
            foreach (var cookie in _accessor.HttpContext.Request.Cookies)
            {
                _cookies[cookie.Key] = cookie.Value;
            }
            this.LogInformation($"GetCookie: {key}");
            if (_cookies.ContainsKey(key))
                return _cookies[key];
            else return null;

        }catch (Exception ex)
        {
            throw new Exception("Исключение в GetCookie: ",ex);
        }
    }

    


    /// <summary>
    /// Удаление свойства Cookie
    /// </summary>
    /// <param name="cookies">ключ свойства</param>
    public void RemoveCookie(string cookies)
    {
       this.LogInformation($"RemoveCookie: {cookies} ");
       
       _accessor.HttpContext.Response.Cookies.Delete(cookies);
    }

   
}