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
            Messages.Add($"ƒаталогическа€ модель {typeof(MarketDataModel).GetNameOfType()}  соответвует требовани€м");
        }
        catch (Exception ex)
        {
            throw new Exception($"ƒаталогическа€ модель {typeof(MarketDataModel).GetNameOfType()} не соответвует требовани€м {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IMarketServiceModel>().EnsureIsValide();
            Messages.Add($"—ервисна€ модель {typeof(IMarketServiceModel).GetNameOfType()}  соответвует требовани€м");


        }
        catch (Exception ex)
        {
            throw new Exception($"—ервисна€ модель {typeof(IMarketServiceModel).GetNameOfType()} не соответвует требовани€м: " + ex.Message);

        }

        return Messages;
    }
}
