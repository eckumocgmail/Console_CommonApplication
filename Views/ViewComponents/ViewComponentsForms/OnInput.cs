using Microsoft.AspNetCore.Mvc;

using NetCoreConstructorAngular.ActionEvent.EventsAndMessages;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewControlles
{
    public interface OnInput
    {
        
 
        public IDictionary<string, List<string>> OnInput([Bind("Source,Property,Value")]InputEvent message);
    }
}