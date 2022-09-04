using Microsoft.AspNetCore.Mvc;

using System;
using System.ComponentModel.DataAnnotations;


/// <summary>
///  онтроллер предназначен дл€ работы мастер диалогом дл€ пошагового ввода нескольких форм.
/// </summary>
[Icon("")]
[Label("")]
[Description(" онтроллер предназначен дл€ работы мастер диалогом дл€ пошагового ввода нескольких форм.")]
[Route("[controller]/[action]")]

public class DialogController : ActionsController<IModalDialogApi>
{
    public DialogController(IServiceProvider provider) : base(provider)
    {
    }
}