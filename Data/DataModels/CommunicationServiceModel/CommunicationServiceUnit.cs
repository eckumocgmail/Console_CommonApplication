
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
            Messages.Add($"Даталогическая модель {typeof(CommunicationDataModel).GetNameOfType()}  соответвует требованиям");
        }
        catch (Exception ex)
        {
            throw new Exception($"Даталогическая модель {typeof(CommunicationDataModel).GetNameOfType()} не соответвует требованиям {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<ICommunicationServiceModel>().EnsureIsValide();
            Messages.Add($"Сервисная модель {typeof(ICommunicationServiceModel).GetNameOfType()}  соответвует требованиям");


        }
        catch (Exception ex)
        {
            Messages.Add($"Сервисная модель {typeof(ICommunicationServiceModel).GetNameOfType()} не соответвует требованиям: " + ex.Message);

        }

        return Messages;
    }
}
