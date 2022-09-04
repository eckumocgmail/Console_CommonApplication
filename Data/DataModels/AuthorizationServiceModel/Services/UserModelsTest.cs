using System.Collections.Generic;

public class UserModelsTest : TestingElement
{
    public UserModelsTest(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        /*return DoTest<UserModelsService>((service) => { 

        });*/
        return Messages;
    }
}