 

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;

public class TreeModel
{
    public string Title { get; set; } = "";
    public bool Expanded { get; set; } = false;
    public bool Checked { get; set; } = false;
    public List<TreeModel> Children { get; set; } = new List<TreeModel>();
}
public class SearchModel<TEntity> where TEntity : class
{
    public TreeModel SearchGroups { get; set; } = new TreeModel();
    public string SearchQuery { get; set; } = "";
    public IEnumerable<string> SearchOptions { get; set; } = new List<string>();
    public IEnumerable<TEntity> SearchResults { get; set; } = new List<TEntity>();
    public int TotalResults { get; set; } = 0;
    public int TotalPages { get; set; } = 1;
    public int PageNumber { get; set; } = 1;

    public SearchModel()
    { 

    }
    public SearchModel(IEnumerable<TEntity> results)
    {
        TotalResults = results.Count();
        SearchResults = results.Skip(0).Take(10);

        SearchQuery = "";
        PageNumber = 1;                            
    }
}

public abstract class SearchController<TResult> : Controller where TResult : BaseEntity
{
    public abstract SearchModel<TResult> GetModel( );

    public abstract IEnumerable<string> GetOptions(

        [FromServices] 
        EntityFasade<TResult> repository,
        string Query );
}
