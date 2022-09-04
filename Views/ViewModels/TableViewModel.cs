using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class TableViewModel<T>: SearchViewModel<T>, SingleDataSelection, DataTableEvents where T: BaseEntity
{
 
    public string FormTitle { get; set; } = $"Выбери { Utils.LabelFor(typeof(T))}";
    public List<object> SelectedItems { get; set; } = new List<object>();
    public IEnumerable<string> Keywords { get; private set; } = new HashSet<string>();



    [NotMapped]
    public ManagmentDataModel context { get; set; }
    

    public TableViewModel(  ) : base()
    {
     
    }



    public List<TRes> GetResults<TRes>() where TRes : T
    {
        var res = new List<TRes>();
        foreach(var p in Results)
        {
            res.Add((TRes)p);
        }
        return res;
    }




    public void InitView()
    {
        UpdateView();
    }

    public void UpdateView()
    {
        if (context != null)
        {
            SelectedItems =  context.Search(typeof(T).Name, "", PageNumber, PageSize).ToList<object>();
            UpdateKeywords();
        }
    }

    private void UpdateKeywords()
    {
        Keywords =  (context).GetKeywords(typeof(T).Name, "");
    }


    public void Select(T it)
    {
        SelectedItems.Add(it);
    }



    public SearchViewModel<T> OnSearchQueryChanged(string SearchQuery)
    {
        this.SearchQuery = SearchQuery;
        this.UpdateView();
        return this;
    }

    public void OnPageNumberChanged(int pageNumber )
    {
        this.PageNumber = pageNumber;
        this.UpdateView();

    }

    public void OnPageSizeChanged(int pageSize)
    {
        this.PageSize = pageSize;
        this.UpdateView();
    }

    public DataResponseMessage OnInput(string SearchQuery)
    {
        this.SearchQuery = SearchQuery;
        this.UpdateKeywords();
        return new DataResponseMessage() { 
            MessageObject = this,
            Confirmed = true,
            ActionStatus = "success",
            SerialKey = GetHashCode()+""
        };
    }





    public DataResponseMessage OnSelectedItems(int id)
    {
        if (SelectedItems.Contains(id))
        {
            SelectedItems.Remove(id);
            return new DataResponseMessage()
            {
                ActionStatus = "failed"
            };

        }
        else
        {
            SelectedItems.Add(id);
            return new DataResponseMessage() { 
                ActionStatus = "success"
            };
        }


    }

    SearchViewModel SearchEvents.OnSearchQueryChanged(string SearchQuery)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    List<object> SingleDataSelection.Selected { get; set; }

    public DataResponseMessage OnSelected(int id)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}
