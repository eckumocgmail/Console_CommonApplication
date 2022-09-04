using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public abstract class InputController<TEntity>:
    SessionController<Form> where TEntity: class
{
    protected InputController(IServiceProvider provider) : base(provider)    {    }

    

 

    public abstract IActionResult Complete(TEntity entity);



    [HttpGet("[controller]/{id?}")]
    public IActionResult Get( int? id )
    {
        TEntity model = null;
        if ( id == null)
        {
            model = ReflectionService.CreateWithDefaultConstructor<TEntity>(typeof(TEntity));
        }
        else
        {
               
            model = (TEntity) (_context).Find(nameof(TEntity), (int)id);
        }
        SetModel(new Form(model));            
        Form form = GetModel();

        return PartialView("Page", GetModel());
    }


    [HttpPut("[controller]")]
    public IActionResult Put(string name, string value)
    {
            
        GetModel().Item.GetType().GetProperty(name).SetValue(GetModel().Item, value);
        Dictionary<string, List<string>> errors = ((BaseEntity)(GetModel().Item)).Validate();
        ResolveModelState(errors);
        return Json(errors);
    }


    [HttpPost("[controller]")]
    public IActionResult Post(FormCollection form)
    {
        Dictionary<string, object> values = new Dictionary<string, object>();
        foreach (var key in form.Keys)
        {
            string value = form[key];
            values[key] = value;
        }
        object idstr = null;
        if (values.ContainsKey("ID"))
        {
            idstr = values["ID"];
            values.Remove("ID");
        }
        var model = GetModel();
        new ReflectionService().copyFromDictionary(model, values);
        Dictionary<string, List<string>> errors = ((BaseEntity)(GetModel().Item)).Validate();
        ResolveModelState(errors);
        if (ModelState.IsValid)
        {
            
            try
            {
                    
                TEntity entity = ((TEntity)(GetModel().Item));
                if (idstr == null)
                {
                    _context.Create(entity);
                    _notifications.Info("Сохранение данных выполнено успешно");
                }
                else
                {
                    _context.Update(entity.GetType().Name,entity);
                    _notifications.Info("Обновление данных выполнено успешно");
                }
                return Complete(entity);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
              
            }
                
        }
        else
        {
            return ViewComponent("Form",model);
        }
            
    }

        


    /// <summary>
    /// Установка ошибок в модель MVC
    /// </summary>
    private void ResolveModelState(Dictionary<string, List<string>> errors)
    {
        foreach(string property in errors.Keys)
        {
            foreach(string error in errors[property])
            {
                ModelState.AddModelError(property, error);
            }
        }
    }


    /// <summary>
    /// Инициаллизация данных
    /// </summary>
    public override void InitModel(Form model)
    {
        foreach(var kv in this.HttpContext.Request.Query)
        {
           
        }

        BaseEntity item = 
            FactoryUtils.Get().CreateWithDefaultConstructor<BaseEntity>(typeof(TEntity).Name);
        model.Item = item;
        model.Update();
    }
}

public class IInputService
{
    public Type Model { get; set; }
    public Form CreateForm { get; set; }
    public Form ValidateModel { get; set; }
    public Action<Object> Complete { get; set; }

}
