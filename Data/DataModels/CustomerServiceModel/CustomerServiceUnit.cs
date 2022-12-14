
using System;
using System.Collections.Generic;

public class CustomerServiceUnit : TestingElement
{
    public CustomerServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (CustomerDataModel model = AppProviderService.GetInstance().Get<CustomerDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();

            }
            Messages.Add($"Даталогическая модель {typeof(CustomerDataModel).GetNameOfType()}  соответвует требованиям");
        }
        catch (Exception ex)
        {
            throw new Exception($"Даталогическая модель {typeof(CustomerDataModel).GetNameOfType()} не соответвует требованиям {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<ICustomerServiceModel>().EnsureIsValide();
            Messages.Add($"Сервисная модель {typeof(ICustomerServiceModel).GetNameOfType()}  соответвует требованиям");


        }
        catch (Exception ex)
        {
            Messages.Add($"Сервисная модель {typeof(ICatalogServiceModel).GetNameOfType()} не соответвует требованиям: " + ex.Message);

        }

        return Messages;
    }
}
