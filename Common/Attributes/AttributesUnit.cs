
using System.Collections.Generic;

public class AttributesUnit: TestingElement
{
    public AttributesUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        return Messages;
    }
}
