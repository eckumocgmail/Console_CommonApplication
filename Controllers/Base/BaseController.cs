
using DataConverter.Generators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


/// <summary>
/// Базовый класс контроллеров представления
/// </summary>
[Icon("apps")]
[Label("app")]
[Description(
    "Базовый контроллер реализует методы проброса моделей в" +
    "компоненты представлений:" +
    "-[список]:" +
    "   [строчный|двустрочный]:" +
    "   [выбор,мульти-выбор]," +
    "   {перетаскивание,сортировака,пагинация}" +
    "-[форма]" +
    "   [выбор,ввод,флаг]" +
    "-таблица" +
    "-дерево" +
    "-карточки" +
    "-диаграмма ")]
public abstract class BaseController : Controller, IUserAgent 
{
     
    [NotNullNotEmpty] public string _index;
    [Service] public AuthorizationDataModel _context { get; set; }
    [Service] public IUserNotificationsService _notifications { get; set; }
    [Service] public APIAuthorization _authorization { get; set; }
    public IServiceProvider _provider { get; set; }

    private IUserAgent UserAgentApi { get; set; }


    /// <summary>
    /// Базовый класс контроллеров представления
    /// </summary>    
    public BaseController ( IServiceProvider provider )
    {
        this.Init(_provider = provider);

        lock (_authorization)
        {
            if (_authorization.IsSignin())
            {
                this.UserAgentApi = _authorization.Verify().Context;
            }
        }
        
    }


    /// <summary>
    /// Вывод представлений иерархического справочника.    
    /// </summary>
    public IActionResult TreeView<T>() where T: HierDictionary<T>
        => PartialView("Page", this.Get<DbHierDictionaryFasade<T>>().GetRoot());

    /// Внедрение ссылки из контейнера
    protected T Get<T>() where T : class => this._provider.Get<T>();
 

    public string onkeypress(string message)
    {
        ViewEventMessage fromView = JsonConvert.DeserializeObject<ViewEventMessage>(message);
        if (fromView.Type != "keypress")
        {
            return Formating.ToJson(new
            {
                Status = "Error",
                Message = "Тип события передан неверно должен быть keypress"
            });
        }
        else
        {
            var keypressedEvent = JsonConvert.DeserializeObject<KeyboardEventMessage>(message);

            return Formating.ToJson(new
            {
                Status = "Success",
                Data = this.onkeypressed(keypressedEvent)
            }); ;
        }
    }

    public object onkeypressed(KeyboardEventMessage message)
    {
        switch (message.GetKeyCode())
        {
            case "13":
                //.ShowHelp("Справочная информация");

                break;
        }
        return new { };
    }
    public List<string> GetKeywords<T>([FromServices] CommonDataModel _context, string query) where T : BaseEntity
    {



        DatabaseManager dbm = new DatabaseManager("Driver={SQL Server};" + AuthorizationDataModel.DEFAULT_CONNECTION_STRING.Replace(@"\\", @"\"));

        object fasade = dbm.GetFasade(TextCounting.GetMultiCountName(typeof(T).Name), TextCounting.GetSingleCountName(typeof(T).Name));

        List<string> keywords = new List<string>();
        List<string> terms = GetIndexes<T>();
        Func<T, bool> verify = Expressions.ArePropertiesContainsText<T>(GetIndexes<T>(), query);
        IQueryable<T> q = ((IQueryable<T>)(_context.GetDbSet(typeof(T).Name)));
        foreach (var p in q.ToList())
        {
            foreach (string term in terms)
            {
                object val = GetValue(p, term);
                if (val != null)
                {
                    keywords.AddRange(val.ToString().Split(" "));
                }
            }
        }
        return keywords;


    }

    private object GetValue(object i, string v)
    {
        PropertyInfo propertyInfo = i.GetType().GetProperty(v);
        FieldInfo fieldInfo = i.GetType().GetField(v);
        return
            fieldInfo != null ? fieldInfo.GetValue(i) :
            propertyInfo != null ? propertyInfo.GetValue(i) :
            null;
    }

    public List<string> GetIndexes<T>()
    {
        Type entityType = FactoryUtils.Get().TypeForName(typeof(T).FullName);
        List<string> terms = AttrsUtils.SearchTermsForType(entityType);
        return terms;
    }

    public IQueryable<T> Search<T>([FromServices] CommonDataModel _context,  string query) where T : BaseEntity
    {
        Func<T, bool> verify = Expressions.ArePropertiesContainsText<T>(GetIndexes<T>(), query);
        IQueryable<T> q = ((IQueryable<T>)(_context.GetDbSet(typeof(T).Name)));
        return q.Where(p => verify(p));
    }
    //////// Навигация 
    public virtual IActionResult Index() 
        => NavList();
 

    protected virtual string GetActionUri(string action) => $"/{GetType().GetNameOfType().Replace("Controller", "")}/{action}";
    protected virtual string GetControllerUri() => $"/{GetControllerName()}";
    protected virtual string GetControllerName() => $"{GetType().GetNameOfType().Replace("Controller", "")}";

    public virtual IActionResult NavList(IEnumerable<string> actions)
    {
        var result = new Dictionary<string, string>();
        foreach (var action in actions)
        {
            result[GetActionUri(action)] = action;
        }
        return NavList(result);
    }
    public virtual IActionResult NavList() 
        => NavList(NavModel());
    public virtual IActionResult NavList(IDictionary<string, string> model) => ViewComponent("NavList", new NavList(model));

    /// <param name="model">
    ///     Справочник со ссылками
    ///     Ключ адрес ссылки, значение надпись на ссылки
    /// </param>
    public virtual IDictionary<string, string> NavModel()
    {
        var result = new ConcurrentDictionary<string, string>();
        foreach (string name in this.GetOwnMethodNames())
        {
            result[this.GetActionUri(name)] = name;
        }
        return result;

    }

    /// <param name="model">
    ///     Справочник со ссылками
    ///     Ключ адрес ссылки, значение надпись на ссылки
    /// </param>
    public virtual IDictionary<string, string> NavModelFor(object target)
    {
        var objectMethods = typeof(System.Object).GetMethods().Select(m => m.Name).ToHashSet();
        var result = new ConcurrentDictionary<string, string>();
        foreach (string name in target.GetType().GetMethods().Select(m => m.Name))
        {
            if (objectMethods.Contains(name) == false)
            {
                if (name.StartsWith("get_") == false && name.StartsWith("set_") == false)
                {
                    result[this.GetActionUri(name)] = name;
                }
            }

        }
        return result;

    }

    public virtual IActionResult NavList(IEnumerable<string> enumerable, System.Func<object, string> p)
    {
        var result = new ConcurrentDictionary<string, string>();
        foreach (string name in enumerable)
        {
            result[p(name)] = name;
        }
        return NavList(result);
    }

 

    public virtual IActionResult IndexNavigationView()
    {

        if (_index != "Index")
        {
            return View(_index);
        }
        else
        {
            if (GetType().GetMethod(_index) == null)
            {
                return View(_index);
            }
            else
            {
                return RedirectToAction(_index);
            }

        }
    }


    public IActionResult NavigationView()
    {
        ViewData["Layout"] = "/Views/Shared/_Layout.cshtml";
        return PartialView("Container", NavigationSingleton.CreateControllerNavigation(GetType()));
    }


    public IActionResult ErrorView(string message)
    {
        return AlertView(message);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TDataItem"></typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public IActionResult ListView<TDataItem>(IList<TDataItem> items)
    {
        return PartialView("Page", new List(items.ToArray()));
    }
    public IActionResult AlertView (string message)
    {
        return PartialView("Page", new Alert(message));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TDataItem"></typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public IActionResult ListView<TDataItem>(IList<TDataItem> items, Action<string> OnClick)
    {
        var Model = new List(items.ToArray());
        Model.ListItems.ForEach(item => item.OnClick = (it) => {
            OnClick(((ListItem)it).Title);
        });
        return PartialView("Page", Model);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TDataItem"></typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public IActionResult TableView<TDataItem>(IEnumerable<TDataItem> items)
    {
        return PartialView("Page", new Table(items.ToArray()));
    }
        

    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TDataItem"></typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public IActionResult FormView<TDataItem>(object item)
    {
        return PartialView("Page", new Form(item));
    }

    /// <summary>
    /// Ссылка на переключение представления
    /// </summary>
    /// <param name="action">наименование методы</param>
    /// <returns></returns>
    public ILink ActionLink(string action)
    {
        var Attributes = AttrsUtils.ForMethod(GetType(), action);
        var link = new Link()
        {
            
            Icon = Attributes.ContainsKey(nameof(IconAttribute)) ?
                   Attributes[nameof(IconAttribute)].ToString() : null,
            Tooltip = Attributes.ContainsKey(nameof(DescriptionAttribute)) ?
                      Attributes[nameof(DescriptionAttribute)].ToString() :
                      action,
            Label = Attributes.ContainsKey(nameof(LabelAttribute)) ?
                    Attributes[nameof(LabelAttribute)].ToString() :
                    action,
            Href = "/" + ControllerContext.RouteData.Values["area"].ToString() +
                    "/" + ControllerContext.RouteData.Values["controller"].ToString() +
                    "/Navigate?id=" + action
        };
        return link;
    }


    public PartialViewResult ActionForm<TController, TInputModel>(string action)
        where TController : Controller
    {
        this.Info($"{nameof(ActionLink)}<{typeof(TController)},{typeof(TInputModel)}>({action}) => ");
        Form model = new Form();
        model.Action = GetActionUrl<TController>(action);
        model.Method = "POST";
        foreach (var par in typeof(TController).GetActionParameters(action))
        {
            var attrs = Utils.ForMethodParam(typeof(TController), action, par.Name);
            model.AddFormField(par.Name, par.ParameterType, attrs);
        }
        return PartialView("Page", model); 
    }


    public string GetActionUrl<TController>(string action) where TController : Controller
    {
        string url = typeof(TController).GetAttribute<RouteAttribute>
        (
            $"/{typeof(TController).GetNameOfType()}/{action}"
        );
        this.Info($"URL адрес: {url}");
        return url;
    }



    /// <summary>
    /// Представление редактора свойств
    /// </summary>
    /// <param name="props">свойства</param>
    /// <returns>представление</returns>
    public IActionResult PropertiesView(IDictionary<string,object> props)
    {
        ViewData["Layout"] = "_Layout";
        ViewData["PropertiesView"] = props;
        return PartialView("_Dictionary", props);
    }







    






    [NonAction]
    public override ViewResult View()
    {
        return base.View();
    }
    
   
    [NonAction]
    public override ViewResult View(string viewName)
    {
        return base.View(viewName);
    }


    [NonAction]
    public override ViewResult View(string viewName, object model)
    {
        return base.View(viewName, model);
    }


    [NonAction]
    public override ViewResult View(object model)
    {
        return base.View(model);
    }




    /// <summary>
    /// Выполняет передачу конфигурации контроллера
    /// </summary>
    /// <returns></returns>
    
    public object GetSettings()
    {
       
        if (HttpContext.Request.Headers.ContainsKey("Content-Type") == false)
        {
            return Formating.ToJson(ControllerGenerator.CreateModel(this.GetType())).Replace("\n", "<hr>");
        }
        else
        {

            switch (HttpContext.Request.Headers.ContainsKey("Content-Type").ToString().ToLower())
            {
                case "text/xml":
                    return View("Controller", ControllerGenerator.CreateModel(this.GetType()));
                     
                default: throw new System.Exception("Content-Type не поддерживается");
            }
        }
        
    }


    /// <summary>
    /// Выполняет поиск модели в контексте соединения по хэш-коду
    /// </summary>
    /// <param name="hashcode"></param>
    /// <returns></returns>
    protected object Find(int hashcode)
    {
        return this.FindByHash(hashcode);
    }

    private object FindByHash(int hashcode)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }


    /// <summary>
    /// Переход на страницу конфигшурации контроллеоа
    /// </summary>
    /// <returns></returns>
    public IActionResult Setup()
    {
        return View();
    }
     



    /// <summary>
    /// Вывод сообщения в консоль
    /// </summary>
    /// <param name="message">Сообщение</param>
    public void Info(string message)
    {
        Api.Utils.Info($"[{GetType().Name}][{GetHashCode()}]: "+message);
    }


    /// <summary>
    /// Вывод сообщения об ошибке в консоль
    /// </summary>
    /// <param name="ex">Исключение</param>
    public void Error(Exception ex)
    {
        Api.Utils.Info($"[{GetType().Name}][{GetHashCode()}]: " + ex.Message);
        Api.Utils.Info($"[{GetType().Name}][{GetHashCode()}]: " + ex.StackTrace);        
    }

    public bool InfoDialog(string Title, string Text, string Button)
    {
        return UserAgentApi.InfoDialog(Title, Text, Button);
    }

    public void ShowHelp(string Text)
    {
        UserAgentApi.ShowHelp(Text);
    }

    public bool RemoteDialog(string Title, string Url)
    {
        return UserAgentApi.RemoteDialog(Title, Url);
    }

    public bool ConfirmDialog(string Title, string Text)
    {
        return UserAgentApi.ConfirmDialog(Title, Text);
    }

    public bool CreateEntityDialog(string Title, string Entity)
    {
        return UserAgentApi.CreateEntityDialog(Title, Entity);
    }

    public object InputDialog(string Title, object Properties)
    {
        return UserAgentApi.InputDialog(Title, Properties);
    }

    public string Eval(string js)
    {
        return UserAgentApi.Eval(js);
    }

    public string HandleEvalResult(Func<object, object> handle, string js)
    {
        return UserAgentApi.HandleEvalResult(handle, js);
    }

    public string Callback(string action, params string[] args)
    {
        return UserAgentApi.Callback(action, args);
    }

    public bool AddEventListener(string id, string type, string js)
    {
        return UserAgentApi.AddEventListener(id, type, js);
    }

    public bool DispatchEvent(string id, string type, object message)
    {
        return UserAgentApi.DispatchEvent(id, type, message);
    }
}
 