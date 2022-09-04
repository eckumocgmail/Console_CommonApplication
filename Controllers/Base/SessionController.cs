using ApplicationDb.Entities;
 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Констроллер работающий с моделью сеанса
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public abstract class SessionController<TModel>:
    BaseController where TModel: class
{
    //public APIAuthorization _authorization;
    public IHttpContextAccessor _accessor;
    //public IUserNotificationsService _notifications;

    protected SessionController(IServiceProvider provider) : base(provider)
    {
    }



    /// <summary>
    /// Метод инициаллизации модели
    /// </summary>
    /// <param name="model"></param>
    public abstract void InitModel(TModel model);


    /// <summary>
    /// Создание новой модели сеанса
    /// </summary>
    /// <returns></returns>
    public TModel NewModel()
    {
        string key = GetType().FullName + "::" + typeof(TModel).FullName;

        

        InitModel((TModel)(_authorization.Verify().Context[typeof(TModel)] =
            ReflectionService.CreateWithDefaultConstructor<TModel>(typeof(TModel))));
        return (TModel)_authorization.Verify().Context[typeof(TModel)];
    }


    /// <summary>
    /// Ключ к модели в контексте сеанса пользователя
    /// </summary>    
    public string GetKey()
    {
        return GetType().FullName + "::" + typeof(TModel).FullName;
    }


    /// <summary>
    /// Регистрация модели в сеансе
    /// </summary>  
    public void SetModel(TModel model)
    {
        string key = GetKey();
        _authorization.Verify().Context[typeof(TModel)] = model;
        this.InitModel(model);  
    }


    /// <summary>
    /// Получение модели сеанса, если модели не существует выполняется её инициаллизация
    /// </summary>
    /// <returns></returns>
    public TModel GetModel()
    {
        if (_authorization.Verify().Context[typeof(TModel)] == null)
        {
            TModel order =
                ReflectionService.CreateWithDefaultConstructor<TModel>(typeof(TModel));
            _authorization.Verify().Context[typeof(TModel)] = order;
            InitModel(order);
        }
        return (TModel)_authorization.Verify().Context[typeof(TModel)];
    }


    /// <summary>
    /// Получение модели сеанса из другого контроллера
    /// </summary>
    /// <typeparam name="T"> тип модели сеанса </typeparam>
    /// <param name="key"> ключ доступа </param>
    /// <returns></returns>
    public T GetAnotherModel<T>(string key)
    {                       
      
        if (_authorization.Verify().Context[typeof(T)] == null)
        {
            _authorization.Verify().Context[typeof(T)] = (T)typeof(T).New();
               
        }
        return ( T)_authorization.Verify().Context[typeof(T)];
    }


    /// <summary>
    /// Получение модели сеанса из другого контроллера
    /// </summary>
    /// <param name="controllerType"> тип контроллера </param>
    /// <returns></returns>
    public TModel GetModel(Type controllerType)
    {
        string key = controllerType.FullName + "::" + typeof(TModel).FullName;

        if (_authorization.Verify().Context[typeof(TModel)] == null)
        {
            TModel order =
                ReflectionService.CreateWithDefaultConstructor<TModel>(typeof(TModel));
            _authorization.Verify().Context[controllerType] = order;
            InitModel(order);
        }
        return (TModel)_authorization.Verify().Context[controllerType];
    }
 


    /// <summary>
    /// ПОиск конструктора класса по-умолчанию
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static ConstructorInfo GetDefaultConstructor(Type type)
    {
            
        ConstructorInfo contr = (from c in new List<ConstructorInfo>(type.GetConstructors()) where c.GetParameters().Length == 0 select c).FirstOrDefault();
        if (contr != null)
        {
            return contr;
        }
        else
        {
            foreach (ConstructorInfo constr in type.GetConstructors())
            {
                int pCOunt = constr.GetParameters().Count();
            }

            return null;
        }
    }
}
