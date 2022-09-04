using Microsoft.AspNetCore.Mvc;

public class AlertViewComponent: ViewComponent
{
    public IViewComponentResult Invoke(global::Alert Model)
    {

        return View(nameof(Alert), Model);
    }
}

