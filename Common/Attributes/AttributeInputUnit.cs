using System.Collections.Generic;

public class AttributeInputUnit : TestingUnit
{
    public AttributeInputUnit(TestingUnit parent): base(parent)
    {
    }

    public override List<string> OnTest()
    {
        Messages.Add("Умеем исп. маркеты ввода");
        return Messages;
    }
}
