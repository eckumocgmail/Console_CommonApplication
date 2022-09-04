
using System.Collections.Generic;

public class UserMessagesTest: TestingElement
{
    public UserMessagesTest(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        return DoTest<UserMessagesService>((service) =>
        {
            /*service.Info("Входящие сообщения: ");
            foreach (var message in service.GetInbox())
            {
                service.Info(message);
            }
            foreach (var message in service.GetOutbox())
            {
                service.Info(message);
            }*/
            service.Info("Исходящие сообщения: ");

        });
    }
}

