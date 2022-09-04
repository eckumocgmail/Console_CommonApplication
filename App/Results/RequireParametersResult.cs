using Microsoft.AspNetCore.Mvc;

using System.Linq;

public class RequireParametersResult : BadRequestResult
{
    protected string[] RequiredParameters;
    public RequireParametersResult(string[] RequiredParameters)
    {
        this.RequiredParameters = RequiredParameters;
    }
    public override void ExecuteResult(ActionContext context)
    {
          
        RequiredParameters.ToList().ForEach(p => context.ModelState.AddModelError("Require", p));
    }
}
