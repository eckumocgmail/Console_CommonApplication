using System;

public class SelectControlWithoutValidation : SelectControlAttribute
{
    public SelectControlWithoutValidation(): base()
    {
        Api.Utils.Info("Create");
    }

    public SelectControlWithoutValidation(string expression) : base()
    {
        Api.Utils.Info("Create");
    }
    public override string GetMessage(object model, string property, object value)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public override string Validate(object model, string property, object value)
    {
        return null;
    }
}
 