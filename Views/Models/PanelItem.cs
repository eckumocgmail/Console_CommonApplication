using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class PanelItem: Pane
{
    [JsonIgnore()]
    public string Chapter { get => Get<string>("Chapter"); set => Set<string>("Chapter", value); }

    [JsonIgnore()]
    public Container TopMenu = new Container();
    [JsonIgnore()]
    public Container TopToolbar = new Container();
    [JsonIgnore()]
    public Container BottomToolbox = new Container();
    [JsonIgnore()]
    public Pane LeftPane = new Pane() { };
    [JsonIgnore()]
    public Pane RightPane = new Pane() { };

     
    public PanelItem(): base()
    {                  
        Append(Left = LeftPane);
        Append(Right = RightPane);
        Append(Top = new Pane() { 
            Item = TopMenu
        });
        Append(Bottom = new Pane() {
            Item = BottomToolbox
        });
        this.EnableChangeSupport = true;
        this.OnEvent+=(eventMessage)=>{
            if( eventMessage is PropertyChangedMessage ){
                if( ((PropertyChangedMessage)eventMessage).Property == "Item"){
                    Api.Utils.Info("Item changed");
                }
            }
        };
        EnableChangeSupport = true;
        Chapter = this.GetType().Name;
    }




    /// Окно настрйоки стиля элемента
    public void ShowPropertiesCustomizer()
    {
        Form form = GetPropertiesCustomizer();         
        LeftPane.Item = form;
        LeftPane.Changed = true;
    }

    private Form GetPropertiesCustomizer()
    {
        EnableChangeSupport = true;
        var ctrl = this;       
        var form = new Form();
        form.StructuresAreEditable = true;
        if(this.Item != null){
            form.Item = this.Item;
            form.Update(form.Item.GetType());
            form.Chapter = AttrsUtils.LabelFor(this.Item.GetType());
        }            
        form.Changed = true;
        LeftPane.Changed = true;                     
        form.EnableChangeSupport = true;
        //form.Bind("Item",ctrl,"Item");        
        return form;
    }


    /// Окно настройки параметров связывания с данными
    public void ShowDataBindingsCustomizer()
    {
        Form form = GetDataBindingsCustomizer();

        LeftPane.Item = form;
        LeftPane.Changed = true;
    }


    private Form GetDataBindingsCustomizer()
    {        
        var form = new Form();            
        form.StructuresAreEditable = true;
        if(this.Item!=null)  {
            form.Item = this.Item;
            form.Chapter = this.Item.GetType().Name;    
            form.Chapter = AttrsUtils.LabelFor(typeof(ViewBuilder));
            form.Update(typeof(ViewBuilder));      
        }
            
        form.Changed = false;
        LeftPane.Changed = true;        
      
        return form;
    }





    /// Окно настрйоки стиля элемента
    public void ShowStyleCustomizer()
    {
        Form form = GetStyleCustomizer();

        LeftPane.Item = form;
        LeftPane.Changed = true;
    }


    private Form GetStyleCustomizer()
    {
     
        var form = new Form();            
        form.StructuresAreEditable = false;
        if(this.Item!=null)  {
            form.Item = this.Item;
            form.Chapter = this.Item.GetType().Name;          
        }
        form.Chapter = AttrsUtils.LabelFor(typeof(StyledItem));
        form.Update(typeof(StyledItem));
        form.Changed = false;
        LeftPane.Changed = true;
      
        return form;
    }




 


    private bool IsCollection()
    {
        return IsExtendedFrom("StructuredCollection");
    }
}