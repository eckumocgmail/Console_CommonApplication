
using System;
using System.Collections.Generic;
using System.Linq;

 
public class ComponentRegistry: IComponentRegistry
{
    public static List<string> VIEW_COMPONENTS = null;
       /* new List<string>() {
            "PaneViewComponent",
            "FormViewComponent",
            "FormFieldViewComponent",
            "FlexContainerViewComponent"
    };*/


    public ComponentRegistry()
    {               
        //VIEW_COMPONENTS = AssemblyReader.GetTypeExtendsFrom("ViewComponent").AsQueryable().Select(item=>item.Name).ToList();
    }
    
    public List<string> GetViewComponentTypes()
    {
        if(VIEW_COMPONENTS == null)
        {
            VIEW_COMPONENTS = new List<string>();
             
        }
        return VIEW_COMPONENTS;
    }


    /// <summary>
    /// Поиск компонента для экземпляра модели
    /// </summary>   
    public string FindViewComponentFor(object target)
    {
        Api.Utils.Info("FindViewComponentFor "+target.GetType().Name+" "+target.GetHashCode());
        if (target.GetType().Name.StartsWith("Highcharts")) return "Highcharts"; 
        List<string> ViewComponentsTypeNames = VIEW_COMPONENTS;
        Type type = target.GetType();
        HashSet<Type> types = new HashSet<Type>();
        Type typeOfObject = new object().GetType();           
        Type p = type;
        while (p != typeOfObject && p != null)
        {
            if (FactoryUtils.Get().GetViewComponents().Values.Select(t=>t.Name).Contains(p.Name.Replace("`1","")+"ViewComponent"))
            {
                return p.Name.Replace("`1", "");
            }
            p = p.BaseType;
        }
        throw new Exception("Не удалось определить тип компонента представления для ссылки "+target.GetType().Name);
    }
}

 