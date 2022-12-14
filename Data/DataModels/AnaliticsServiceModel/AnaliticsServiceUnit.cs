
using System;
using System.Collections.Generic;

public class AnaliticsServiceUnit : TestingElement
{
    public AnaliticsServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (AnaliticsDataModel model = AppProviderService.GetInstance().Get<AnaliticsDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();
                model.EnsureIsValide();

            }
            Messages.Add($"Даталогическая модель {typeof(AnaliticsDataModel).GetNameOfType()}  соответвует требованиям");
        }
        catch (Exception ex)
        {
            throw new Exception($"Даталогическая модель {typeof(AnaliticsDataModel).GetNameOfType()} не соответвует требованиям {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IAnaliticsServiceModel>().EnsureIsValide();
            Messages.Add($"Сервисная модель {typeof(IAnaliticsServiceModel).GetNameOfType()}  соответвует требованиям");


        }
        catch (Exception ex)
        {
            Messages.Add($"Сервисная модель {typeof(IAnaliticsServiceModel).GetNameOfType()} не соответвует требованиям: {ex.Message}");

        }
        return Messages;
    }
}
