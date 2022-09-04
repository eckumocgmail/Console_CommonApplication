using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System;
using System.Threading.Tasks;

public class SearchViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(global::Search Model)
    {
        return View("Search", Model);
    }
    public class Search : ViewItem
    {
        public string Query { get; set; }

        [JsonIgnore()]
        public Func<Search, object> AtInput { get; set; }

        [JsonIgnore()]
        public Func<Search, object> AtSearch { get; set; }

        public Search()
        {
            Changed = false;
        }

        public object OnInput(string query)
        {
            this.Query = query;
            if (AtInput != null)
            {
                return AtInput(this);
            }
            return new { };
        }

        public object OnSearch(string query)
        {
            this.Query = query;
            if (AtSearch != null)
            {
                return AtSearch(this);
            }
            return new { };
        }


    }
}