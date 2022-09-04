using System;

public class Search : ViewItem
{
    /*public SearchViewModel OnSearchQueryChanged(string SearchQuery)
    {
        return null;
    }
    public DataResponseMessage OnInput(string SearchQuery)
    {
        return null;
    }*/

    public string Query { get; set; }
    public Func<string, SearchViewModel> OnSearchQueryChanged { get; set; }
    public Func<string,DataResponseMessage> OnInput { get; set; }
    public Func<string, object> OnSearch { get; set; }
}