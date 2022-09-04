using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataConverter.Generators;
 

/// <summary>
/// Предоставляет модель панели навигации для заданной области
/// </summary>
public class NavigationSingleton
{

    public static Dictionary<string, List<Type>> RoleControllers = 
               new Dictionary<string, List<Type>>();
 
    

    /// <summary>
    /// Создание панели навигации по представлениям контроллера
    /// </summary>
    /// <param name="ctype">тип контроллера</param>
    /// <returns>панель навигации</returns>
    public static Link CreateControllerNavigation(Type ctype)
    {
        if (ctype == null)
            throw new Exception("Ссылка на Null");
        MyControllerModel model = ControllerGenerator.CreateModel(ctype);

        string controller = ctype.Name.Replace("Controller", "");
        var res = new Link();
        res.Icon = AttrsUtils.IconFor(ctype);
        res.Label = AttrsUtils.LabelFor(ctype);
        res.Tooltip = AttrsUtils.ForDescription(ctype);
        res.Href = model.Path;

        List<string> names = ReflectionService.GetOwnMethodNames(ctype);
        foreach (var action in model.Actions)
        {
            if (names.Contains(action.Key) && action.Key.StartsWith("On")==false )
            {
                if(ViewUtils.IsViewResult(ctype, action.Key))
                {
                    var link = new Link()
                    {
                        Icon = action.Value.Attributes.ContainsKey(nameof(IconAttribute)) ?
                            action.Value.Attributes[nameof(IconAttribute)].ToString() : null,
                        Tooltip = action.Value.Attributes.ContainsKey(nameof(DescriptionAttribute)) ?
                            action.Value.Attributes[nameof(DescriptionAttribute)].ToString() :
                            action.Key,
                        Label =
                            action.Value.Attributes.ContainsKey(nameof(LabelAttribute)) ?
                            action.Value.Attributes[nameof(LabelAttribute)].ToString() :
                            action.Key,
                        Href = PathFor(ctype) + "/" + action.Key
                    };
                    res.ChildLinks.Add(link);
                }                
            }

        }
        return res;
    }



    /// <summary>
    /// Создание представления для меню навигации
    /// </summary>
    public static Link GetNavigationFor( Microsoft.AspNetCore.Mvc.Rendering.ViewContext vc) {

        if (vc == null)
            throw new ArgumentNullException("vc");
        string controller = (vc.RouteData.Values["controller"].ToString() + "Controller");
        var type = ReflectionService.TypeForName(controller);
        if (type == null)
            throw new ArgumentNullException("type");
        var role = RoleFor(type);
  
        List<Type> Controllers = CreateNavigationFor(role);
        var nav = CreateNavigationFor(Controllers);
        nav.Label = LabelFor(role);
        return nav;

    }


    /// <summary>
    /// Подпись корня навигационной панели
    /// </summary>
    /// <param name="role">имя роля</param>
    /// <returns></returns>
    public static string LabelFor(string role)
    {
      
        if (role=="Public")
        {
            return "Общий раздел";
        }
        else
        {
            string code = role.Replace("Face", "");
            string title = code;
            using (var db = new AuthorizationDataModel())
            {
                title = db.BusinessResources.Where(r => r.Code == code).Select(r => r.Name).FirstOrDefault();
            }
            return title;
            
        }
    }


    /// <summary>
    /// Создание меню навигации для контроллеров заданных типами
    /// </summary>
    /// <param name="Controllers">типы контроллеров</param>
    /// <returns>меню навигации</returns>
    public static Link CreateNavigationFor(List<Type> Controllers)
    {
        
        var nav = new Link();
        nav.Icon = "home";
        nav.ChildLinks = new List<ILink>();
        Controllers.ForEach((System.Action<System.Type>)(ctrl => {

            Api.Utils.Info($"Ссылки {ctrl.Name}");
            if (ctrl.IsAbstract == false && TypeUtils.IsExtendedFrom(ctrl, nameof(BaseController)))
            {
                var link = CreateControllerNavigation(ctrl);

                link.Label = AttrsUtils.LabelFor(ctrl);
                if (link.Label == null)
                {
                    link.Label = ctrl.Name;
                }
                nav.ChildLinks.Add(link);
            }

        }));
        return nav;
    }


    /// <summary>
    /// Получение меню навигации для области приложения
    /// </summary>
    /// <param name="role">роль пользователя приложения</param>
    /// <returns>меню навигации</returns>
    public static Link GetNavigationFor(string role)
    {
        var ctrls = CreateNavigationFor(role);
        return CreateNavigationFor(ctrls);
    }
 
    


    /// <summary>
    /// Получение контроллеров зарегистрированных в указанной области
    /// </summary>
    /// <param name="role">наименование области</param>
    /// <returns>Типы контроллеров</returns>
    private static List<Type> CreateNavigationFor(string role) {
        if (RoleControllers.ContainsKey(role))
        {
            return RoleControllers[role];
        }

        if (role == "")
        {            
            return (from p in FactoryUtils.Get().GetControllers().Values
                                            where AttrsUtils.ForType(p.Name).ContainsKey(nameof(AreaAttribute)) == false
                                            select p).ToList();
        }

        return (from p in FactoryUtils.Get().GetControllers().Values
                                        where RoleFor(p) == role select p).ToList();
    }



    /// <summary>
    /// Определение области по типу контроллера
    /// </summary>
    /// <param name="type">тип контроллера</param>
    /// <returns>наименование области</returns>
    public static string RoleFor(Type type) {
        if (type == null)
            throw new ArgumentNullException("type");
        var attrs = AttrsUtils.ForType(type.Name);
        if (attrs.ContainsKey(nameof(AreaAttribute)))
        {
            return attrs[nameof(AreaAttribute)];
        }
        else
        {
            return "Public";
        }
    }



    /// <summary>
    /// Возвращает маршрут к контроллеру
    /// </summary>
    /// <param name="controllerType">тип контроллера</param>
    /// <returns>маршрут</returns>
    public static string PathFor(Type controllerType)
    {
        string role = RoleFor(controllerType);
        if (role != null && role != "Public")
        {
            return "/" + role + "/" + controllerType.Name.Replace("Controller", "");
        }
        else
        {
            return "/" + controllerType.Name.Replace("Controller", "");
        }
    }



    
}