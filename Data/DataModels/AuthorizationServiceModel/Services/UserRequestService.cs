
using Microsoft.AspNetCore.Http;
using System;


public class UserRequestService 
{
    private const string COOKIE_KEY = "SesionID";

    protected HttpCookieManager _cookiesManager;
    protected IHttpContextAccessor _http;

    public UserRequestService() { }
    /*  public UserRequestService(HttpCookieManager cookiesManager, IUserSessionManager application, IHttpContextAccessor http )
      {
          _cookiesManager = cookiesManager;
          _application = application;
          _http = http;      
      }*/



 


    private string GetTcpIpV6Address() =>  _http.HttpContext.Connection.RemoteIpAddress.MapToIPv6().ToString();

    /*
    public HttpSessionContext GetSession()
    {
        string ip = GetTcpIpV6Address();
        string id = Identify();
        HttpSessionContext session = GetHttpSessionContext();
        if( session.TcpIpV6 == null)
        {
            session.TcpIpV6 = ip;
        }
        else
        {
            if( session.TcpIpV6 != ip)
            {
                //throw new Exception($"IP-адрес изменился c {session.ip} на {ip}"); 
                Api.Utils.Info($"IP-адрес изменился c {session.TcpIpV6} на {ip}");
            }
        }
        return session;
    }
 
    private HttpSessionContext GetHttpSessionContext()
    {
        return new HttpSessionContext();
    }
       */
    public string Identify()
    {
        string sessionId = _cookiesManager.GetCookie(COOKIE_KEY);
        if(string.IsNullOrEmpty(sessionId)==false)
        {
            return sessionId;
        }
        else
        {
            string id = "";// CreateId();
            _cookiesManager.SetCookie(COOKIE_KEY, id);
            return id;
        }
    }

    /*
    private string CreateId()
    {
        string id = CreateRandomId();
        while( _application.ContainsKey(id))
        {
            id = CreateRandomId();
        }
        return id;
    }

    */
    private string CreateRandomId()
    {
        string id = "";
        Random random = new Random();
        while (id.Length != 10)
        {
            id+=Math.Floor(random.NextDouble() * 10).ToString();
        }
        return id;
    }
    /*
    public void OnSignout()
    {
        string cookies = _cookiesManager.GetCookie(COOKIE_KEY);
        _application.Invalidate(cookies);
        _cookiesManager.RemoveCookie(cookies);
    }*/
}
