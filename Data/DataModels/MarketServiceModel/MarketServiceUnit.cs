using System;
using System.Collections.Generic;


public class MarketServiceUnit : TestingElement
{
    public MarketServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (MarketDataModel model = AppProviderService.GetInstance().Get<MarketDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();

            }
            Messages.Add($"Даталогическая модель {typeof(MarketDataModel).GetNameOfType()}  соответвует требованиям");
        }
        catch (Exception ex)
        {
            throw new Exception($"Даталогическая модель {typeof(MarketDataModel).GetNameOfType()} не соответвует требованиям {ex.Message}");
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
