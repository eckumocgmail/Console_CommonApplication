
using Newtonsoft.Json;

using System;
using System.Collections.Generic;

[Icon("account_tree")]
public class Tree: ViewItem 
{
    [JsonIgnore]
    public object Item { get; set; }
    public string Title { get; set; }
   

    public string Image { get; set; }


    public Tree():base() 
    {
       // Api.Utils.Info(GetType().Name + " Created " + GetHashCode());
        Item = new DictionaryTable() { Name = "Новый каталог" };
        Selectable = true;
        Expanded = true;
        ContextMenu = null;        
        Init();        
    }

    public Tree(string name) : base() {
        // Api.Utils.Info(GetType().Name + " Created " + GetHashCode());
        Item = new DictionaryTable() { Name = name };
        Selectable = true;
        Expanded = true;
        ContextMenu = null;
        Init();
    }


    public Tree(Tree parent, DictionaryTable item)
    {
        //Api.Utils.Info(GetType().Name + " Created" + GetHashCode());
        Item = item;
        Selectable = true;
        Expanded = true;
        SetParent(parent);
        Init();
    }

    public override void Init() {

        base.Init();
        var ctrl = this;
        this.ContextMenu = null;
    }


    public List<List<object>> ToOrgChart()
    {        
        List<List<object>> items = new List<List<object>>() {   };
        string pname = (Parent != null) ?
            ((DictionaryTable)(((Tree)Parent).Item)).Name :
            (((DictionaryTable)Item).Name);
        
        items.Add(new List<object>() { (((DictionaryTable)Item).Name), pname, "" });
        Children.ForEach(p => {
            items.AddRange(((Tree)p).ToOrgChart());
        });
        return items;


    }

    public List<List<object>> ToOrgHighChart() {
        List<List<object>> items = new List<List<object>>() { };
        string pname = (Parent != null && ((Tree)Parent).Item!= null && ((DictionaryTable)(((Tree)Parent).Item)).Name != null) ?
            ((DictionaryTable)(((Tree)Parent).Item)).Name :
            AttrsUtils.LabelFor(Item.GetType());

        items.Add(new List<object>() { (((DictionaryTable)Item).Name), pname });
        Children.ForEach(p => {
            items.AddRange(((Tree)p).ToOrgHighChart());
        });
        return items;


    }
    protected  void On(dynamic message)
    {
        switch (message.Type)
        {
            case "Select": 
                if( message.Value == true && MultiSelect == false )
                {
                    GetSelected().ForEach(p => p.Selected = false);
                    SelectionModel.Clear();
                    SelectionModel.Add(message.Source);
                }
                break;
            default: throw new Exception("События типа "+message.Type+" не поддерживаются");
        }
    }


    public object GetItem()
    {
        return Item;
    }


    public List<ViewNode> GetSelected()
    {
        List<ViewNode> selected = new List<ViewNode>();
        this.Do((p) => {
            if (p.Selected)
            {
                selected.Add(p);
            }
        });
        return selected;
    }



    public List<ViewNode> GetChecked()
    {
        List<ViewNode> selected = new List<ViewNode>();
        this.Do((p) => {
            if (p.Checked)
            {
                selected.Add(p);
            }
        });
        return selected;
    }


    




    public void Create()
    {
        Api.Utils.Info(GetType().Name + " Children Node Created " + GetHashCode());
        new Tree(this, new DictionaryTable() { Name = "Новый элемент" });
    }



    public void Search( string query )
    {
        Api.Utils.Info(GetType().Name + " Children Node Created " + GetHashCode());
        new Tree(this, new DictionaryTable() { Name = "Новый элемент" });
    }

    public void AppendRange(ICollection<Tree> children )
    {
        foreach(var p in children)
        {
            base.Append(p);
        }
    }

     
    public override string ToString() {
        string s = "";
        Children.ForEach(c => s += c.ToString() + ",");
        return Item  + "[" +s+ "]";
    }
   
}