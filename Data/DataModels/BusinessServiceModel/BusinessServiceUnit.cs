
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
            Messages.Add($"ƒаталогическа€ модель {typeof(BusinessDataModel).GetNameOfType()}  соответвует требовани€м");
        }
        catch (Exception ex)
        {
            throw new Exception($"ƒаталогическа€ модель {typeof(BusinessDataModel).GetNameOfType()} не соответвует требовани€м {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IBusinessServiceModel>().EnsureIsValide();
            Messages.Add($"—ервисна€ модель {typeof(IBusinessServiceModel).GetNameOfType()}  соответвует требовани€м");


        }
        catch (Exception ex)
        {
            Messages.Add($"—ервисна€ модель {typeof(IBusinessServiceModel).GetNameOfType()} не соответвует требовани€м: " + ex.Message);

        }
        return Messages;
    }
}
