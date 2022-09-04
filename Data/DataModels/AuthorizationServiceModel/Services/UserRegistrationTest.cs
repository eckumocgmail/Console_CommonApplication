using System.Collections.Generic;

public class UserRegistrationTest : TestingElement
{
    public UserRegistrationTest(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        return Messages;
    }
}