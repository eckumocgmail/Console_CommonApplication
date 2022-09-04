using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
[Route("[controller]")]
public  abstract class FunctionController<TActionModel>: InputController<TActionModel> 
    where TActionModel : class
{
    private readonly IUserNotificationsService _notification;
    private readonly IServiceProvider _sp;
    private readonly string _name;   
    private readonly string _description;
    private readonly string _help;


    /// <summary>
    /// Выполнение операции
    /// </summary>        
    protected abstract void Do(TActionModel model);


    /// <summary>
    /// URL следующей операции
    /// </summary>        
    protected abstract string GetNext();


    /// <summary>
    /// Конструктор контроллера операций
    /// </summary>
    /// <param name="notification"></param>
    public FunctionController(
            IServiceProvider serviceProvider,
            IUserNotificationsService notification,
            IServiceProvider session)
        :base( session ){
        _notification = notification;
      // _index = "Get";
        //_action = "Get";
        //_view = GetType().Name.Replace("Controller", "");
        _name = AttrsUtils.LabelFor(this.GetType());
        _sp = serviceProvider;
        _description = AttrsUtils.DescriptionFor(this.GetType());
        _help = AttrsUtils.HelpFor(this.GetType());
    }

    protected FunctionController(IServiceProvider provider) : base(provider)
    {
    }








    /// <summary>
    /// Выполняется для каждого запроса
    /// </summary>
    protected virtual void Init()
    {
        ViewData["Title"] = this._name;
        ViewData["Description"] = this._description;
        ViewData["Help"] = this._help;            
    }


    /// <summary>
    /// Установка состояний свойств модели
    /// </summary>
    protected virtual void SetValidationStates()
    {
        ViewData["State"] = ModelState;
        foreach (var property in typeof(TActionModel).GetProperties())
        {
            switch (ModelState.GetFieldValidationState(property.Name))
            {
                case ModelValidationState.Valid:
                    ViewData[property.Name + "ValidationState"] = "valid";
                    break;
                case ModelValidationState.Invalid:
                    ViewData[property.Name + "ValidationState"] = "invalid";
                    break;
                case ModelValidationState.Unvalidated:
                    ViewData[property.Name + "ValidationState"] = "untouched";
                    break;
                default:
                    ViewData[property.Name + "ValidationState"] = "skipped";
                    break;
            }
        }
    }

    /// <summary>
    /// Переход к представлению
    /// </summary>               
    [HttpGet]
    [Icon("person")]
    public virtual ViewResult Get()
    {
        this.Info("Get()");
        this.Init();
        string controller = ControllerContext.RouteData.Values["controller"].ToString();
        var args = new List<object>();
        var constructor = typeof(TActionModel).GetConstructors()[0];
        foreach(var parameter in constructor.GetParameters())
        {
            args.Add(_sp.GetService(parameter.ParameterType));
        }
        object model = constructor.Invoke(args.ToArray());
        this.SetValidationStates();
        return View(controller, model);
    }


    /// <summary>
    /// Выполнение валидации модели, если валидация выполнена успешно, то выполнение операции
    /// </summary>
    /// <param name="model">модель аргументов вызова</param>                
    [HttpPost]
    [HttpGet("/[controller]/[action]")]

    [Icon("person")]
    public virtual Microsoft.AspNetCore.Mvc.ActionResult Post(TActionModel model)
    {
        this.Init();
        string controller = ControllerContext.RouteData.Values["controller"].ToString();
        if (ModelState.IsValid == false)
        {
            SetValidationStates();
                 
            return View(controller, model);
        }
        else
        {
            try
            {                    
                Do(model);
                _notification.Success($"Операция '{_name}' выполнена успешно", _description);
                return Redirect(GetNext());
            }
            catch(Exception ex)
            {
                SetValidationStates();
                _notification.Error($"{_name} завершена с ошибкой: "+ex.Message);
                return View(controller, model);
            }                
        }
            
    }

    /// <summary>
    /// Получение статуся проверки свойства модели
    /// </summary>
    /// <param name="property">имя свойства модели</param>
    /// <returns>состояние</returns>
    protected string GetValidationState(string property)
    {
        string state = ModelState[property] == null ? "valid" :
            ModelState[property].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid == true ? "valid" : "invalid";
        return state;
    }
 
}
 