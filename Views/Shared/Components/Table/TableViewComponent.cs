


using Microsoft.AspNetCore.Mvc;
 
using System.Threading.Tasks;

 
public class TableViewComponent: ViewComponent
{
    private readonly TableService _table;


    public TableViewComponent(TableService table)
    {
        _table = table;
    }


    public IViewComponentResult Invoke( Table Model, IEntityFasade manager )
    {
        if( Model != null)
        {
            return View(Model);
        }
        else if (manager != null)
        {
            global::Table table = _table.ForTableManager(manager);
            return View(table);
        }
        return View(new Table());
        
    }
}
 
