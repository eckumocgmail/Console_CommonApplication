
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
            Messages.Add($"ƒаталогическа€ модель {typeof(AnaliticsDataModel).GetNameOfType()}  соответвует требовани€м");
        }
        catch (Exception ex)
        {
            throw new Exception($"ƒаталогическа€ модель {typeof(AnaliticsDataModel).GetNameOfType()} не соответвует требовани€м {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IAnaliticsServiceModel>().EnsureIsValide();
            Messages.Add($"—ервисна€ модель {typeof(IAnaliticsServiceModel).GetNameOfType()}  соответвует требовани€м");


        }
        catch (Exception ex)
        {
            Messages.Add($"—ервисна€ модель {typeof(IAnaliticsServiceModel).GetNameOfType()} не соответвует требовани€м: {ex.Message}");

        }
        return Messages;
    }
}
