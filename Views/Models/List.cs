using ApplicationDb.Entities;
using NetCoreConstructorAngular.ActionEvent;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[Icon("view_headline")]
public class List: StructuredCollection
{    

    [Label("Иконка")]
    public string Icon { get => Get<string>("Icon"); set => Set<string>("Icon", value); }


    public virtual List<ViewItem> ListItems 
    { 
        get
        {
            
            return ItemsList;
        }
        set
        {
            this.ItemsList = value;
        }
    }
    public List(ICollection items,Func<object, string> navigation) : this()
    {
        ListItems.Clear();
        foreach (var item in items)
        {
            ListItems.Add(new ListItem() { Title = item.ToString()  });
        }

    }
    public List(ICollection items) : this()
    {
        ListItems.Clear();
        foreach (var item in items)
        {
            ListItems.Add(new ListItem() { Title = item.ToString() });
        }

    }
    public List() : base()
    {
        InitDefaultStyle();
        Selectable = true;
        Searchable = true;
        Type = typeof(DictionaryTable);
        Chapter = "List";
        ListItems = new List<ViewItem>();
        Bindings = null;
        ListItems.Add(new ListItem() { Title = "Item1" });
        ListItems.Add(new ListItem() { Title = "Item2" });
        this.AddEditTools();
        Changed = false;
    }


    public List(params object[] items) : this((ICollection)(items.ToList())) {
        this.ContextMenu = new ContextMenu();
    }



    private void InitDefaultStyle()
    {
        Icon = "";
        FontSize = 16;       
    }

    public List AddAction(string Label, Action<global::List> OnClick )
    {
         
        return this;
    }
    
     




}