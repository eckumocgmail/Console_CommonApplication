using System.Collections.Generic;

public class ViewServicesUnit : TestingElement
{
    public override List<string> OnTest()
    {
        Messages.Add("Службы редставлений");
        return Messages;
    }
}