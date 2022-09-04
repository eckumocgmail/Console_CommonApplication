using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreConstructorAngular.ActionEvent.EventsAndMessages
{
    [Label("Модель события ввода")]
    public class InputEvent
    {
        [BindProperty]
        [NotNullNotEmpty("Источник события не задан")]
        public int Source { get; set; }

        [BindProperty]
        [NotNullNotEmpty("Имя свойства не задано")]        
        public string Property { get; set; }

        [BindProperty]
        public string Value { get; set; }
    }
}
