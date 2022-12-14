
using System;
using System.Collections.Generic;

public class BusinessServiceUnit : TestingElement
{
    public BusinessServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (BusinessDataModel model = AppProviderService.GetInstance().Get<BusinessDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();

            }
            Messages.Add($"Даталогическая модель {typeof(BusinessDataModel).GetNameOfType()}  соответвует требованиям");
        }
        catch (Exception ex)
        {
            throw new Exception($"Даталогическая модель {typeof(BusinessDataModel).GetNameOfType()} не соответвует требованиям {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IBusinessServiceModel>().EnsureIsValide();
            Messages.Add($"Сервисная модель {typeof(IBusinessServiceModel).GetNameOfType()}  соответвует требованиям");


        }
        catch (Exception ex)
        {
            Messages.Add($"Сервисная модель {typeof(IBusinessServiceModel).GetNameOfType()} не соответвует требованиям: " + ex.Message);

        }
        return Messages;
    }
}
