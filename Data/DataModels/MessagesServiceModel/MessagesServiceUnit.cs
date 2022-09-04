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
            Messages.Add($"ƒаталогическа€ модель {typeof(MessagesDataModel).GetNameOfType()}  соответвует требовани€м");
        }
        catch (Exception ex)
        {
            Messages.Add($"ƒаталогическа€ модель {typeof(MessagesDataModel).GetNameOfType()} не соответвует требовани€м {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IMessagesServiceModel>().EnsureIsValide();
            Messages.Add($"—ервисна€ модель {typeof(IMessagesServiceModel).GetNameOfType()}  соответвует требовани€м");


        }
        catch (Exception ex)
        {
            Messages.Add($"—ервисна€ модель {typeof(IMessagesServiceModel).GetNameOfType()} не соответвует требовани€м: " + ex.Message);

        }

        return Messages;
    }
}
