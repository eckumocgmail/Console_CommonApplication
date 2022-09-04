using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class DataComponentConstructor
{
}

public class CompositeViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<ViewItem> Components { get; set; }
}
public class ViewComponentConstructor : SessionController<CompositeViewModel>
{
    public ViewComponentConstructor(IServiceProvider provider) : base(provider)
    {
    }

    public override IActionResult Index()
        => ListViewComponents();

    private IActionResult ListViewComponents()
    {
        return ListView<string>
        (
            GetModel().Components.Select(component => component.GetTypeName()).ToList()
        );
    }



    /// <summary>
    /// Выбор типа нового компонента
    /// </summary>    
    public IActionResult SelectNewViewComponentType()
    {
        IList<string> components = Assembly.GetExecutingAssembly().GetTypes<ViewComponent>().Select(t => t.GetTypeName()).ToList();
        return this.ListView<string>
        (
            components,
            (component) => {
                try
                {
                    ViewItem item = (ViewItem)component.ToType().New();
                    GetModel().Components.Add(item);                    

                }
                catch(Exception ex)
                {
                    this.Error("При создании новогог компонента выброшено исключение. ",ex);
                }
            }
        );
    }

    public override void InitModel(CompositeViewModel model)
    {
        model.Name = "New CompositeViewModel";
        model.Description = "New CompositeViewModel";
        model.Components = new List<ViewItem>();
    }
}
