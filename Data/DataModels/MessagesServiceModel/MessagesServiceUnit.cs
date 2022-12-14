using System;
using System.Collections.Generic;


public class MessagesServiceUnit : TestingElement
{
    public MessagesServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (MessagesDataModel model = AppProviderService.GetInstance().Get<MessagesDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();

            }
            Messages.Add($"Даталогическая модель {typeof(MessagesDataModel).GetNameOfType()}  соответвует требованиям");
        }
        catch (Exception ex)
        {
            Messages.Add($"Даталогическая модель {typeof(MessagesDataModel).GetNameOfType()} не соответвует требованиям {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IMessagesServiceModel>().EnsureIsValide();
            Messages.Add($"Сервисная модель {typeof(IMessagesServiceModel).GetNameOfType()}  соответвует требованиям");


        }
        catch (Exception ex)
        {
            Messages.Add($"Сервисная модель {typeof(IMessagesServiceModel).GetNameOfType()} не соответвует требованиям: " + ex.Message);

        }

        return Messages;
    }
}
