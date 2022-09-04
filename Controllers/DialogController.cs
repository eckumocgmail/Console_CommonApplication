using Microsoft.AspNetCore.Mvc;

using System;
using System.ComponentModel.DataAnnotations;


/// <summary>
/// ���������� ������������ ��� ������ ������ �������� ��� ���������� ����� ���������� ����.
/// </summary>
[Icon("")]
[Label("")]
[Description("���������� ������������ ��� ������ ������ �������� ��� ���������� ����� ���������� ����.")]
[Route("[controller]/[action]")]

public class DialogController : ActionsController<IModalDialogApi>
{
    public DialogController(IServiceProvider provider) : base(provider)
    {
    }
}