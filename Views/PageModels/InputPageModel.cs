using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public abstract class InputPageModel<TBaseEntity>: BasePageModel
{

    [Service]
    protected IServiceProvider  _sessions { get; set; }
    [TempData]
    public TBaseEntity InputState { get; set; }
    [TempData]
    public bool Completed { get; set; }
    [TempData]
    public string ErrorMessage { get; set; }
    [BindProperty]
    public TBaseEntity Input { get; set; }
    [BindProperty]
    public Form Form { get; set; } = new Form();

    protected IServiceProvider _provider { get; set; }
    protected  InputPageModel(IServiceProvider provider): base(provider)
    {
        this.Init(this._provider = provider);
    }


    public virtual void OnGet()
    {        
        try
        {
            if(_sessions == null)
            {
                this.Init(this._provider);
            }
            if (_sessions != null)
            {
                //this._provider.GetService<UserModelsService>().RegistrateModel(this.Input = (TBaseEntity)typeof(TBaseEntity).New());
            }
            this.Form = new Form(this.Input);
        }
        catch(Exception ex)
        {
            ex.ToString().WriteToConsole();
        }
    }

   
    public virtual void OnPost()
    {
        this.Info(this._provider.GetService<IHttpContextAccessor>().HttpContext.ToRequestMessage().ToJsonOnScreen());
    }

    /*
    public virtual void OnPut(string Source, string Property, string Value)
    {
        //this.Info(HttpContext.ToRequestMessage().ToJsonOnScreen());
        

        try
        {
            object model = _sessionManager.GetById(Source);
            model.SetProperty(Property, Value);
        }
        catch (Exception ex)
        {
            ex.ToString().WriteToConsole();
        }
    }*/


}
