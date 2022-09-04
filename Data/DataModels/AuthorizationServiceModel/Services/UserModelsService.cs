using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TeleReportsDataProvider;


/// <summary>
/// Сервис выполняет регистрацию обьектов в контексте сенса.
/// </summary>
public class UserModelsService: IServiceProvider
{
   

    [Service]
    protected APIUsers _users;
    private readonly AuthorizationOptions _options;

    public HttpCookieManager _cookies { get; }

    private readonly IHttpContextAccessor _http;
    

    public UserModelsService(
        AuthorizationOptions options,
        IHttpContextAccessor http,
        HttpCookieManager cookies, 
        APIUsers users, 
        IServiceProvider provider)
    {
        this.Init(provider);
        _options = options;
        _cookies = cookies;
        _http = http;
        _users = users;
    }

 





    /// <summary>
    /// 
    /// </summary>
    public object BeforeRender()
    {
        var models = GetModels();
        if( models != null)
        {
            object p = null;
            foreach(var hashcode in new List<int>(models.Keys))
            {
                models.TryRemove(hashcode, out p);
                if( p !=null && p is ViewItem)
                {
                    ((ViewItem)p).RemoveFromParent();
                }
            }
        }
        return "";
    }


    /// <summary>
    /// 
    /// </summary>
    public string AfterRender() {
        return "";
    }


    /// <summary>
    /// 
    /// </summary>
    public HashSet<int> GetChanges()
    {
        HashSet<int> changes = new HashSet<int>();
        var models = GetModels();
        if(models != null)
        {
            foreach (object val in models.Values) { 
                if( val is ViewItem)
                {
                    ViewItem view = ((ViewItem)val);
                    if (view.ViewInitiallized)
                    {
                        if (view.WasChanged())
                        {
                            changes.Add(val.GetHashCode());
                        }
                    }
                }
            }
        }

        return changes;
    }



    public bool Has(object model)
    {
        return GetModels().ContainsKey(model.GetHashCode());
    }

    public object Remove(int hashcode)
    {
        object p = null;
        GetModels().TryRemove(hashcode, out p);
        if (p != null && p is ViewItem)
        {
            ((ViewItem)p).RemoveFromParent();
        }
        return p;
    }

    public object FindByHash(int code)
    {   
     
        try
        {
            var models = GetModels();
            if (models.ContainsKey(code))
            {
                return GetModels()[code];
            }
            else
            {
                return null;
            }
        }
        catch(Exception ex)
        {
            this.Error(ex);
            return Formating.Json(new
            {
                Status = "Error",
                Type = "FindModelException",
                Errors = new
                {
                    Source = code
                }
            });
        }        
    }






    public string RegistrateModel(object model)
    {
        try
        {
            if (model == null) return "";
            int code = model.GetHashCode();

            if (model is ViewItem)
            {
                ((ViewItem)model).hashcode = code;
            }
            try
            {
                ConcurrentDictionary<int, object> models = GetModels();
                if (models == null)
                {
                    return model.GetHashCode().ToString();
                }
                models[code] = model;
                if (model is ViewItem)
                {


                    ((ViewItem)model).GetSession = (d) =>
                    {
                        return _users.GetUserSession(_cookies.GetCookie(_options.UserCookie));
                        //return 0;// sessionManager.GetById(sessionId).GetRoot();
                    };
                }
            }
            catch (Exception ex)
            {
                this.Error(ex);
                if (model is ViewItem)
                    ((ViewItem)model).HasRegistered = false;
                throw;
            }
            //if (_page.Find(code) == null)
            //{
            //    _page.Append(model);
            //}
            return code.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception("Исключение при регистрации данных представления", ex);
        }
    }



    public ConcurrentDictionary<int, object> GetModels()
    {
     
        var session = _users.GetUserSession(_cookies.GetCookie(_options.UserCookie));
        return null;// session;
        //return GetModel();
    }


    public void InitModel(ConcurrentDictionary<int, object> model)
    {

    }

    public object Find(int hash)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }


    public bool InfoDialog(string Title, string Text, string Button)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public void ShowHelp(string Text)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public bool RemoteDialog(string Title, string Url)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public bool ConfirmDialog(string Title, string Text)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public bool CreateEntityDialog(string Title, string Entity)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public object InputDialog(string Title, object Properties)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public string Eval(string js)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public string HandleEvalResult(Func<object, object> handle, string js)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public string Callback(string action, params string[] args)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public bool AddEventListener(string id, string type, string js)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public bool DispatchEvent(string id, string type, object message)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

   
    public object GetService(Type serviceType)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    /*
public bool InfoDialog(string Title, string Text, string Button)
{
GetViewContext().ServerTasks.Enqueue(new ServerTask()
{
  ToDo = (ctx) => {
      if (ctx is AbstractHub)
      {
          var hub = (AbstractHub)ctx;                    
          hub.InfoDialog(Title, Text, Button);                    
      }
      return null;
  }
});
return true;
}

public bool RemoteDialog(string Title, string Url)
{
throw new NotImplementedException($"{GetType().GetTypeName()}");
}

public bool ConfirmDialog(string Title, string Text)
{
GetViewContext().ServerTasks.Enqueue(new ServerTask()
{
  ToDo = (ctx) => {
      if (ctx is AbstractHub)
      {
          var hub = (AbstractHub)ctx;
          hub.ConfirmDialog( Title, Text );
      }
      return null;
  }
});
return true;
}

public bool CreateEntityDialog(string Title, string Entity)
{
throw new NotImplementedException($"{GetType().GetTypeName()}");
}

public object InputDialog(string Title, object Properties)
{
throw new NotImplementedException($"{GetType().GetTypeName()}");
}

public string Eval(string js)
{
throw new NotImplementedException($"{GetType().GetTypeName()}");
}

public string HandleEvalResult(Func<object, object> handle, string js)
{
GetViewContext().ServerTasks.Enqueue(new ServerTask()
{
  ToDo = (ctx) => {
      if (ctx is AbstractHub)
      {
          var hub = (AbstractHub)ctx;
          hub.HandleEvalResult(handle,js);
      }
      return null;
  }
});
return "";
}

public string Callback(string action, params string[] args)
{
GetViewContext().ServerTasks.Enqueue(new ServerTask()
{
  ToDo = (ctx) => {
      if (ctx is AbstractHub)
      {
          var hub = (AbstractHub)ctx;
          hub.Callback(action, args);
      }
      return null;
  }
});
return "";
}

public bool AddEventListener(string id, string type, string js)
{
throw new NotImplementedException($"{GetType().GetTypeName()}");
}

public bool DispatchEvent(string id, string type, object message)
{
throw new NotImplementedException($"{GetType().GetTypeName()}");
}

public string OnConnected(string token)
{
throw new NotImplementedException($"{GetType().GetTypeName()}");
}

public void ShowHelp(string Text)
{
GetViewContext().ServerTasks.Enqueue(new ServerTask()
{
  ToDo = (ctx) => {
      if (ctx is AbstractHub)
      {
          var hub = (AbstractHub)ctx;
          hub.ShowHelp(Text);
      }
      return null;
  }
});        
}*/
}
