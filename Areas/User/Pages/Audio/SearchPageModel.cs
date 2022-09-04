using System;
using static System.IO.Directory;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class SearchPageModel<TEntity> : BasePageModel
{

    [BindProperty]
    public string Path { get; set; }


    [BindProperty]
    public IEnumerable<CardModel> SearchResults { get; set; } = new List<CardModel>();


    [BindProperty]
    public int Progress { get; set; } = 0;
    public string View = "List";

    public SearchPageModel(IServiceProvider provider) : base(provider)
    {
    }

    public class CardModel
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Text { get; set; }
        public string Href { get; set; }
        public string Link { get; set; }
    }

    public virtual async Task OnGet(string Path)
    {
        await Search(this.Path = Path);
    }

    public virtual async Task OnPost()
    {
        await Task.CompletedTask;
    }

    private async Task Search(string Path)
    {
        string Pattern = string.IsNullOrEmpty(Path) ? "*.*" : Path;
        var CardsList = new List<CardModel>();
        foreach (var File in GetDirectories(GetCurrentDirectory(), Pattern))
        {
            string FileName = File.Substring(File.LastIndexOf("\\") + 1);
            CardsList.Add(new CardModel()
            {
                Title = FileName,
                Subtitle = System.IO.File.GetLastWriteTime(File).ToString()
            });
        }
        foreach (var File in GetFiles(GetCurrentDirectory(), Pattern))
        {
            string FileName = File.Substring(File.LastIndexOf("\\") + 1);
            CardsList.Add(new CardModel()
            {
                Title = FileName,
                Subtitle = System.IO.File.GetLastWriteTime(File).ToString()
            });
        }
        await Task.CompletedTask;
        SearchResults = CardsList;
    }
}