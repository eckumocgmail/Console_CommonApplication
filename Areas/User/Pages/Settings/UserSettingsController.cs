using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularApplication.Areas.User.Pages.Settings
{
    public class UserSettingsController : Controller
    {        
        public IActionResult Index() => Json(new { 
        });
    }
}
