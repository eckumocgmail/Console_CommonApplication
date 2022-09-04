using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ButtonController: Controller
{

    protected UserModelsService _models;

    public ButtonController(  UserModelsService models ) 
    {   
        _models = models;
    }


    public IActionResult OnClick( int hash )
    {
        object item = _models.FindByHash(hash);
        if( item is global::Button)
        {
            global::Button button = (global::Button)item;
            button.OnClick(button);
            return Ok();
        }
        else
        {
            return NotFound();
        }
            
    }
}