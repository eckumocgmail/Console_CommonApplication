
using System;
using System.Collections.Generic;

public class UserEmailTest: TestingElement
{
    public UserEmailTest(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        
        try
        {
            var service = this.Get<UserEmailService>();
            service.SendEmail("eckumoc@gmail.com","Тест","Это тестовое сообщение");
            this.Messages.Add($"Сервис {typeof(UserEmailService).GetTypeName()} умеет отправлять сообщения по электронной почте");

        }
        catch (Exception ex)
        {
            string message = GetFailedMessage();
            this.Error(message, ex);
            this.Messages.Add(message);
            throw new Exception(message, ex);
        }

        return Messages;
    }
}
 