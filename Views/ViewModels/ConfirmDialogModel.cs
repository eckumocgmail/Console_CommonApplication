using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class ConfirmDialogModel
{
    [BindProperty()]
    public bool Confirmed { get; set; }

}