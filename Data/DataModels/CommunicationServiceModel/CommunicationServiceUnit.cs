
using System;
using System.Collections.Generic;

public class CommunicationServiceUnit : TestingElement
{
    public CommunicationServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (CommunicationDataModel model = AppProviderService.GetInstance().Get<CommunicationDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();

            }
            Messages.Add($"ƒаталогическа€ модель {typeof(CommunicationDataModel).GetNameOfType()}  соответвует требовани€м");
        }
        catch (Exception ex)
        {
            throw new Exception($"ƒаталогическа€ модель {typeof(CommunicationDataModel).GetNameOfType()} не соответвует требовани€м {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<ICommunicationServiceModel>().EnsureIsValide();
            Messages.Add($"—ервисна€ модель {typeof(ICommunicationServiceModel).GetNameOfType()}  соответвует требовани€м");


        }
        catch (Exception ex)
        {
            Messages.Add($"—ервисна€ модель {typeof(ICommunicationServiceModel).GetNameOfType()} не соответвует требовани€м: " + ex.Message);

        }

        return Messages;
    }
}
