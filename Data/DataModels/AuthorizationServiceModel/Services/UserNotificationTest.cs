using System.Collections.Generic;

public class UserNotificationTest : TestingElement
{
    public UserNotificationTest(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest() => DoTest<UserNotificationService>(service => {
        service.Info("Тестовое сообщение");
        service.Warn("Тестовое сообщение");
        service.Error("Тестовое сообщение");
        Messages.Add($"{typeof(UserNotificationService)} умеет регистрировать информационные сообщения, предупреждения и ошибки");
    });
}