using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Базовый класс сервисов комопнентов представления.
/// Компоненты представления интегрируются на страницы через эти сервисы.
/// Сервисы отвечаются за связь модели данных с событиями представления.
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public abstract class ViewComponentService
{
    private readonly IServiceProvider _models;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="models"></param>
    public ViewComponentService(IServiceProvider  models)
    {
        _models = models;
    }


    public object IntoSession( object viewModel )
    {        
      //  this.RegistrateModel(viewModel);
        return viewModel;
    }

  
}
