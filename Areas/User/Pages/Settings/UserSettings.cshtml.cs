using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppModel.Areas.User.Pages.Settings
{
    public class UserSettingsModel : PageModel
    {

        [BindProperty]
        public Form InputForm { get; set; }


        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            this.Info(context.HttpContext.Request.Method);
            base.OnPageHandlerExecuted(context);
            switch (context.HttpContext.Request.Method)
            {
                case "POST":
                    break;
            }
        }

        public void OnGet([FromServices] APIAuthorization authorization)
        {
            this.InputForm = new Form(authorization.Verify().Settings);
        }

        public void OnPost()
        {



            this.Info(HttpContext.ToRequestMessage());
        }
    }
}
