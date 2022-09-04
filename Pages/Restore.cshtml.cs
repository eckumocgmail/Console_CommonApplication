using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AngularApplication.Pages
{
    public class RestoreModel : PageModel
    {
        [TempData]
        public byte[] Memory { get; set; }

        public IDictionary<string, IEnumerable<string>> Controllers { get; set; } = new Dictionary<string, IEnumerable<string>>();

        [BindProperty]
        public string Controller { get; set; }
        [BindProperty]
        public string Action { get; set; }

        


        public void OnGet()
        {
            this.Controllers = new Dictionary<string, IEnumerable<string>>(Assembly.GetExecutingAssembly().GetControllers().Select(t => 
                new KeyValuePair<string, IEnumerable<string>>(t.GetTypeName(), t.GetOwnMethodNames())));
        }

        public void OnPost()
        {
        }
    }
}
