using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppModel.Pages
{
    public class RedirectModel : PageModel
    {
        private readonly APIServices _services;
        private readonly Service _service;

        public string Provider { get; set; }
        public string ReturnUrl { get; set; }
        public RedirectModel(APIServices services, Service service)
        {
            _services = services;
            _service = service;
        }

        public void OnGet(string provider)
        {

            this.Provider = provider;
            this.ReturnUrl = _service.Url;            
        }

        public void OnPost()
        {

        }
    }
}
