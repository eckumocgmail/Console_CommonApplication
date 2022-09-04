 

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

public class StructuredCollection: PanelItem  
{
  

    [NotNullNotEmpty("Необходимо задать значение свойсва ItemType")]
    public Type Type { get; set; }
    public List<ViewItem> ItemsList { get; set; } = new List<ViewItem>();


    [JsonIgnore()]
    public Func<object, object> Create { get; set; }

    [JsonIgnore()]
    public Search SearchControl { get; set; }



    public StructuredCollection()
    {        
        
    }


     /// <summary>
     /// Поисковая строка
     /// </summary>
     /// <returns></returns>
     public Search CreateSearch()
     {          
         if(SearchControl == null)
         {
             var search = new Search()
             {
                 OnInput = (search) => {
                     var dataset = GetDatasetFromItems();
                     var results = DataSearch.Search(dataset, Type.Name, search.ToString());
                     ItemsList.ForEach(p => {
                         bool visible = results.Contains(p.DataSet);
                         if (p.Visible != visible)
                         {
                             if (p.Selected)
                             {
                                 p.Selected = false;
                             }
                             p.Visible = visible;
                             p.Changed = true;
                         }
                     });
                     return new DataResponseMessage()
                     {
                         MessageObject = new
                     {
                         Query = search.ToString(),
                         Keywords = GetKeywords(dataset, Type.Name, search.ToString())
                     }
                     };
                 },
                 OnSearch = (search) => {
                     var dataset = GetDatasetFromItems();
                     var results = Search(dataset, Type.Name, search.ToString());
                     ItemsList.ForEach(p => {
                         bool visible = results.Contains(p.DataSet);
                         if( p.Visible != visible)
                         {
                             if (p.Selected)
                             {
                                 p.Selected = false;
                             }
                             p.Visible = visible;

                         }
                         p.Changed = true;
                     });
                     return new
                     {
                         Status = "Success"
                     };
                 }
             };
             search.Changed = false;
             SearchControl = search;
         }        
         return SearchControl;
     }

    private IEnumerable<string> GetKeywords(List<object> dataset, string name, string v)
        => DataSearch.GetKeywords(dataset, name, v);  

    private HashSet<object> Search(List<object> dataset, string name, string v)
        => DataSearch.Search(dataset, name, v);

    private void Delete(BaseEntity entity)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    /// <summary>
    /// Извлекает элементы данных
    /// </summary>
    /// <returns></returns>
    public List<object> GetDatasetFromItems()
    {
        List<object> dataset = new List<object>();
        ItemsList.ForEach((p) => {
            dataset.Add(p.DataSet);
        });
        return dataset;
    }


    /// <summary>
    /// Присоединяет панель инструментов: "Редактирование коллекций"
    /// </summary>
    public void AddEditTools()
    {
        var ctrl = this;
        var createButton = new Button()
        {
            Label = "Создать",
            Icon = "add",
            OnClick = (button) => {
                object item = ctrl.Create==null? ReflectionService.CreateWithDefaultConstructor<object>(Type): ctrl.Create(ctrl);
                var form = new Form();
                form.Item = item;
                form.Edited = true;
                var createButton = new Button()
                {
                    Label = "Сохранить",
                    OnClick = (button) =>
                    {
                        var entity = ((BaseEntity)form.Item);
                        CreateEntity(entity);
                        ItemsList.Add(new ListItem() { DataSet = entity });
                        this.LeftPane.Clear();
                        this.Changed = true;                     
                        this.LeftPane.Changed = true;
                    }
                };
                createButton.Enabled = false;
                createButton.Bind("Enabled", form, "IsValid");
                form.Buttons.Add(createButton);
                this.LeftPane.Item = form;
                this.LeftPane.Changed = true;
            }
        };
        createButton.OnClick += (button) =>
        {
            createButton.Enabled = createButton.Enabled ? false : true;
        };



        //кнопка редактирования
        Button editButton = null;
        editButton = new Button()
        {
            Label = "Редактировать",
            Icon = "edit",
            OnClick = (button) => {

                var selectedListItem = this.SelectionModel.FirstOrDefault();
                if (selectedListItem == null)
                {
                    throw new Exception("Не найден выбранный элемент");
                }
                var item = selectedListItem.DataSet;
                //object item = 
                var form = new Form();
                form.Item = item;
                form.Update();
                var createButton = new Button()
                {
                    Label = "Сохранить",
                    OnClick = (button) =>
                    {
                        var entity = ((BaseEntity)form.Item);
                        entity.Update();
                        this.LeftPane.Clear();
                        this.Changed = true;
                    }
                };
                var closeButton = new Button()
                {
                    Label = "Закрыть",
                    OnClick = (button) =>
                    {
                        this.LeftPane.Clear();
                        this.Changed = true;
                    }
                };
                createButton.Enabled = false;
                createButton.Bind("Enabled", form, "IsValid");
                form.Buttons.Add(createButton);
                form.Buttons.Add(closeButton);
                this.LeftPane.Item = form;
                this.LeftPane.Changed = true;
            }
        };

        this.OnEvent += (message) =>
        {
            if (message is PropertyChangedMessage)
            {
                PropertyChangedMessage propertyChangedMessage = (PropertyChangedMessage)message;
                if (propertyChangedMessage.Property == "Selected")
                {
                    if (this.LeftPane.Clear() != null)
                    {
                        this.Changed = true;
                    }
                }
            }
        };
        this.OnEvent += (message) =>
        {
            if (message is PropertyChangedMessage)
            {
                PropertyChangedMessage propertyChangedMessage = (PropertyChangedMessage)message;
                if (propertyChangedMessage.Property == "Selected")
                {
                    editButton.Enabled = (this.SelectionModel.Count() == 1);
                }
            }
        };
        editButton.Enabled = false;

        Button deleteButton = null;
        deleteButton = new Button()
        {
            Label = "Удалить",
            Icon = "remove",
            OnClick = (button) => {
                foreach (var listitem in this.SelectionModel.ToList())
                {
                    BaseEntity entity = ((BaseEntity)listitem.DataSet);
                    ItemsList.Remove(listitem);
                    this.SelectionModel.Remove(listitem);
                    Delete(entity);
                }
                editButton.Enabled = deleteButton.Enabled = false;
                ctrl.Changed = true;
            }
        };
        deleteButton.Enabled = true;
        this.OnEvent += (message) =>
        {
            if (message is PropertyChangedMessage)
            {
                PropertyChangedMessage propertyChangedMessage = (PropertyChangedMessage)message;
                if (propertyChangedMessage.Property == "Selected")
                {
                    deleteButton.Enabled = (this.SelectionModel.Count() > 0);
                }
            }
        };
        createButton.FontSize = 14;
        editButton.FontSize = 14;
        deleteButton.FontSize = 14;

        deleteButton.Enabled = false;

        createButton.OnClick(createButton);
        ((ViewItem)(this.LeftPane)).Visible = false;
        this.TopMenu.Append(createButton);
        this.TopMenu.Append(editButton);
        this.TopMenu.Append(deleteButton);
    }

    public void CreateEntity(BaseEntity e)
    {
        
    }
}
