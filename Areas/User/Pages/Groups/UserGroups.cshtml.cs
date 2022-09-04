using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppModel.Areas.User.Pages.Groups
{
    public class UserGroupsModel : SearchPageModel<UserGroups>
    {
        public UserGroupsModel(IServiceProvider provider) : base(provider)
        {
        }
        public override async Task OnGet(string Path)
        {
            await Task.CompletedTask;

        }

        public override async Task OnPost()
        {
            await Task.CompletedTask;
        }



    }
}
