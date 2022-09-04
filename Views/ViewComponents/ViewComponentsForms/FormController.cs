using Microsoft.AspNetCore.Mvc;

using MVC.ViewControlles;

using NetCoreConstructorAngular.ActionEvent.EventsAndMessages;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public abstract class FormController<TModel>: SessionController<Form>, OnInput
{
    protected FormController(IServiceProvider provider) : base(provider)
    {
    }

    [HttpPut]
    public virtual IDictionary<string, List<string>> OnInput([Bind("Source,Property,Value")] InputEvent message)
    {
        Form form = GetModel();
        //form.OnInput(message);
        return form.Validate();                         
    }


    /// <summary>
    /// Вывод формы
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {
        return PartialView("Container", GetModel());
    }


        
      

    public override void InitModel(Form model)
    {            
        model.Item = ReflectionService.CreateWithDefaultConstructor<MyValidatableObject>(typeof(TModel));
        model.Update();            
    }

        

        
}
