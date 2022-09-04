using Microsoft.AspNetCore.Http;


public class HttpContextAccessor : IHttpContextAccessor
{

    public HttpContext HttpContext { get; set; } = null;
}

