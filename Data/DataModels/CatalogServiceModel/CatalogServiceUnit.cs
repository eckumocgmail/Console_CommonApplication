
using System;
using System.Collections.Generic;

public class CatalogServiceUnit : TestingElement
{
    public CatalogServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (CatalogDataModel model = AppProviderService.GetInstance().Get<CatalogDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();

            }
            Messages.Add($"ƒаталогическа€ модель {typeof(CatalogDataModel).GetNameOfType()}  соответвует требовани€м");
        }
        catch (Exception ex)
        {
            throw new Exception($"ƒаталогическа€ модель {typeof(CatalogDataModel).GetNameOfType()} не соответвует требовани€м {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<ICatalogServiceModel>().EnsureIsValide();
            Messages.Add($"—ервисна€ модель {typeof(ICatalogServiceModel).GetNameOfType()}  соответвует требовани€м");


        }
        catch (Exception ex)
        {
            Messages.Add($"—ервисна€ модель {typeof(ICatalogServiceModel).GetNameOfType()} не соответвует требовани€м: " + ex.Message);

        }

        return Messages;
    }
}
