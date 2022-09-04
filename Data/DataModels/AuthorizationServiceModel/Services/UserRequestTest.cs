using System.Collections.Generic;

public class UserRequestTest : TestingElement
{
    public UserRequestTest(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        return Messages;
    }
}