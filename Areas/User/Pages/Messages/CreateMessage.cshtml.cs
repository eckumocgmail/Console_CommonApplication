using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppModel.Areas.User.Pages.Messages
{
    public class CreateMessageModel : BasePageModel
    {
        public CreateMessageModel(IServiceProvider provider) : base(provider)
        {
        }

        [BindProperty]
        public UserMessage Input { get; set; }


        public void OnGet()
        {
            Input = new UserMessage();
        }
    }
}
