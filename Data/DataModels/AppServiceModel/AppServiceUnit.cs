
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
            Messages.Add($"Даталогическая модель {typeof(AppDataModel).GetNameOfType()} соответвует требованиям");
        }
        catch (Exception ex)
        {
            throw new Exception($"Даталогическая модель {typeof(AppDataModel).GetNameOfType()} не соответвует требованиям {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IAppServiceModel>().EnsureIsValide();
            Messages.Add($"Сервисная модель {typeof(IAppServiceModel).GetNameOfType()}  соответвует требованиям");


        }
        catch (Exception ex)
        {
            Messages.Add($"Сервисная модель {typeof(IAppServiceModel).GetNameOfType()} не соответвует требованиям: "+ex.Message);

        }
        return Messages;
    }
}
