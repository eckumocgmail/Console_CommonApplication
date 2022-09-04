 

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class NavigationService: INavigationService  
{
    public string Area { get; set; } = "AdminFace";
    public string Index { get; set; }
    public DefaultNavigationModel Model { get; private set; }

    private readonly IHttpContextAccessor _accessor;
    private readonly IUserNotificationsService _notifications;

    public NavigationService(
        IHttpContextAccessor accessor,
            IUserNotificationsService notifications,
                IServiceProvider  sessions ) 
    {
    //    Model = (DefaultNavigationModel)trans.GetSession(accessor.HttpContext).Get(typeof(DefaultNavigationModel));
        _accessor = accessor;
        _notifications = notifications;
    }

    public  void InitModel(DefaultNavigationModel model)
    {
        using (var db = new AuthorizationDataModel())
        {
            Model.States = new Dictionary<string, object>();
            foreach (var role in db.BusinessResources.ToList())
            {                    
                Model.States[role.Code] =
                    NavigationSingleton.GetNavigationFor(role.Code + "Face");
            }                
        }
    }






 
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ILink GetNavMenu()
    {         
        return NavigationSingleton.GetNavigationFor(Area);
    }


    /// <summary>
    /// Определение сегмента связи 
    /// </summary>
    /// <param name="path">URL</param>
    /// <returns>наменование сегмента</returns>
    private string GetArea(string path)
    {
        if (path.StartsWith("/") == false || (path.Length>0 && (path.Substring(1).IndexOf("/") == -1)))
        {
            return "Public";
        }
        else
        {
            string area = path.Substring(1);
            return area.Substring(0, area.IndexOf("/") - 1);
        }
    }


        




    public void Init(ILink link)
    {
        ReflectionService.CopyValues(link, this);
    }


    public void Navigate(string Route)
    {
        if (IsAbsolutelyRoute(Route))
        {
            if (Model.States.ContainsKey(Route))
            {
                Model.State = Route;
            }
            else
            {
                Model.State = GetNotFound();
            }
        }
        else if (IsRelativeRoute(Route))
        {
            foreach (string Path in Route.Substring("./".Length).Split("/"))
            {
                if (Go(Path) == false)
                {
                    break;
                }
            }
        }
        else
        {
            Model.State = GetNotFound();
        }
    }


    private bool Go(string Path)
    {
        if (Path == "..")
        {
            int i = Model.State.LastIndexOf("/");
            if (i >= 1)
            {
                Model.State = Model.State.Substring(0, i - 1);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            string Next = Model.State + "/" + Path;
            if (Model.States.ContainsKey(Next))
            {
                Model.State = Next;
                return true;
            }
            else
            {
                Model.State = GetNotFound();
                return false;
            }
        }
    }

    private bool IsRelativeRoute(string Route)
    {
        return Route.StartsWith("./");
    }

    private bool IsAbsolutelyRoute(string Route)
    {
        return Route.StartsWith("/");
    }

    public string GetIndex()
    {
        return "/Home/About";
    }

    public string GetNotFound()
    {
        return "/Home/Error";
    }

    public string GetState()
    {
        return Model.State;
    }
          
}
