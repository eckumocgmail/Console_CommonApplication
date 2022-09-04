using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

[Icon("folder")]
[Label(nameof(ComponentsController))]
[Description("Контроллер предназначен для интерфейса, демонстрирующего " +
    "базовые базовые элементы пользовательского интерфейса.")]
[Route("[controller]/[action]")]

public class ComponentsController: BaseController 
{
    public ComponentsController(IServiceProvider provider) : base(provider)
    {
    }

    public IEnumerable<string> GetViewComponents()=>
        Assembly.GetExecutingAssembly().GetTypes<ViewComponent>().Select(t => t.Name);  


    public ViewComponentResult DraggableTreeView<TItem>([FromServices]IHierDictionaryFasade<TItem> fasade) where TItem: HierDictionary
    {
        
        return ViewComponent("Tree", fasade.GetRoot());

    }
    public ViewComponentResult DraggableTreeView<TItem>(TItem root, Func<TItem, TypeNode<TItem>> expand) where TItem: class
    {
        return ViewComponent("NavTree", new { Model = root });
    }

    public ViewComponentResult InputFormView(object model)
    {
        return ViewComponent("Form", new { Model = new global::Form(model) {  } });
    }

    public ViewComponentResult SelectListView<T>(List<T> items)
    {
        return ViewComponent("List", new { Model = new global::List(items) });
    }
}
 