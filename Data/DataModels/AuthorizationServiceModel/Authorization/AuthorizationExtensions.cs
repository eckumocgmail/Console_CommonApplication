using Microsoft.AspNetCore.Http;


public static class AuthorizationExtensions
{

    public static T GetSingleton<T>(this object context) => 
        AppProviderService.GetInstance().GetSingleton<T>();

    public static void GoToLoginPage(this HttpContext context) => AppProviderService.GetInstance().Get<HttpResponse>().Redirect("/");
}
