using Microsoft.AspNetCore.Mvc;

using System;

[Route("[controller]/[action]")]
public class FormsController: FunctionController<Form>
{
    public FormsController(IServiceProvider provider) : base(provider)
    {
    }

    public override IActionResult Complete(Form entity)
        => Redirect("");


    protected override void Do(Form model)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    protected override string GetNext()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}
