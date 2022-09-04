using System.Collections.Generic;
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public abstract class SearchViewModel<TEntity> : BookViewModel<TEntity> where TEntity : BaseEntity
{
    public string SearchQuery { get; set; } = "";
    public List<string> SearchKeywords { get; set; } = new List<string>();
    

 
}


public class SearchViewModel: SearchViewModel<BaseEntity>
{

}