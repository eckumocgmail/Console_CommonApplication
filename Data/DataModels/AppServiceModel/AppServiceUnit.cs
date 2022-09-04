
using System;
using System.Collections.Generic;

public class AppServiceUnit : TestingElement
{
    public AppServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {

        try
        {
            using (AppDataModel model = AppProviderService.GetInstance().Get<AppDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();
                model.EnsureIsValide();

            }
            Messages.Add($"ƒаталогическа€ модель {typeof(AppDataModel).GetNameOfType()} соответвует требовани€м");
        }
        catch (Exception ex)
        {
            throw new Exception($"ƒаталогическа€ модель {typeof(AppDataModel).GetNameOfType()} не соответвует требовани€м {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IAppServiceModel>().EnsureIsValide();
            Messages.Add($"—ервисна€ модель {typeof(IAppServiceModel).GetNameOfType()}  соответвует требовани€м");


        }
        catch (Exception ex)
        {
            Messages.Add($"—ервисна€ модель {typeof(IAppServiceModel).GetNameOfType()} не соответвует требовани€м: "+ex.Message);

        }
        return Messages;
    }
}
