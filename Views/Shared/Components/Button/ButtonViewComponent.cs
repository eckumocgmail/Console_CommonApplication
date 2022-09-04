using Microsoft.AspNetCore.Mvc;


public class ButtonViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(global::Button Model )
    {
    
        return View(nameof(Button),Model);
    }
}

