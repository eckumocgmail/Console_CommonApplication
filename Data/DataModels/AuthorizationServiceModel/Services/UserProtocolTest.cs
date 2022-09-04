using System.Collections.Generic;

public class UserProtocolTest : TestingElement
{
    public UserProtocolTest(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        return Messages;
    }
}