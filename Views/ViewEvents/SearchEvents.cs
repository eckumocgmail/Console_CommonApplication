

using Microsoft.AspNetCore.Mvc;

public interface SearchEvents
{
    public SearchViewModel OnSearchQueryChanged( string SearchQuery );
    public DataResponseMessage OnInput(string SearchQuery);
}