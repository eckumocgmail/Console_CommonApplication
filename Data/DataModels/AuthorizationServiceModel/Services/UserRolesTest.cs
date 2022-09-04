using System.Collections.Generic;

public class UserRolesTest : TestingElement
{
    public UserRolesTest(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        return Messages;
    }
}