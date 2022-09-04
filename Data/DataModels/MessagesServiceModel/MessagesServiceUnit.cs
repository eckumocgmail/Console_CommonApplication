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
            Messages.Add($"�������������� ������ {typeof(MessagesDataModel).GetNameOfType()}  ����������� �����������");
        }
        catch (Exception ex)
        {
            Messages.Add($"�������������� ������ {typeof(MessagesDataModel).GetNameOfType()} �� ����������� ����������� {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IMessagesServiceModel>().EnsureIsValide();
            Messages.Add($"��������� ������ {typeof(IMessagesServiceModel).GetNameOfType()}  ����������� �����������");


        }
        catch (Exception ex)
        {
            Messages.Add($"��������� ������ {typeof(IMessagesServiceModel).GetNameOfType()} �� ����������� �����������: " + ex.Message);

        }

        return Messages;
    }
}
