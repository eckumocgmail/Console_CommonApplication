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
            Messages.Add($"�������������� ������ {typeof(MarketDataModel).GetNameOfType()}  ����������� �����������");
        }
        catch (Exception ex)
        {
            throw new Exception($"�������������� ������ {typeof(MarketDataModel).GetNameOfType()} �� ����������� ����������� {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IMarketServiceModel>().EnsureIsValide();
            Messages.Add($"��������� ������ {typeof(IMarketServiceModel).GetNameOfType()}  ����������� �����������");


        }
        catch (Exception ex)
        {
            throw new Exception($"��������� ������ {typeof(IMarketServiceModel).GetNameOfType()} �� ����������� �����������: " + ex.Message);

        }

        return Messages;
    }
}
