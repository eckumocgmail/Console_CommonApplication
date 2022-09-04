using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppModel.Pages
{
    public class SignoutModel : PageModel
    {
        private readonly APIAuthorization _authorization;
        private readonly AuthorizationOptions _options;

        public SignoutModel(APIAuthorization authorization, AuthorizationOptions options)
        {
            this._authorization = authorization;
            this._options = options;
        }

        public void OnGet()
        {
            this._authorization.Signout();
            HttpContext.Response.Redirect(_options.LoginPagePath);
        }
    }
}
