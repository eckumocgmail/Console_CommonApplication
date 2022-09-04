using System;
using System.Collections.Generic;


public class ManagmentServiceUnit: TestingElement
{
    public ManagmentServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (ManagmentDataModel model = AppProviderService.GetInstance().Get<ManagmentDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();

            }
            Messages.Add($"Даталогическая модель {typeof(ManagmentDataModel).GetNameOfType()}  соответвует требованиям");
        }
        catch (Exception ex)
        {
            throw new Exception($"Даталогическая модель {typeof(ManagmentDataModel).GetNameOfType()} не соответвует требованиям {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IMarketServiceModel>().EnsureIsValide();
            Messages.Add($"Сервисная модель {typeof(IMarketServiceModel).GetNameOfType()}  соответвует требованиям");


        }
        catch (Exception ex)
        {
            throw new Exception($"Сервисная модель {typeof(IMarketServiceModel).GetNameOfType()} не соответвует требованиям: " + ex.Message);

        }

        return Messages;
    }
}
