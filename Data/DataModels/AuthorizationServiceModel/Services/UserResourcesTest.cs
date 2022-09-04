using System.Collections.Generic;

public class UserResourcesTest : TestingElement
{
    public UserResourcesTest(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest() => DoTest<UserResourcesService>(service => {

    });
}