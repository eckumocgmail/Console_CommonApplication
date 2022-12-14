using System;
using System.Collections.Generic;


public class PhoneServiceUnit : TestingElement
{
    public PhoneServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (PhoneDataModel model = AppProviderService.GetInstance().Get<PhoneDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();

            }
            Messages.Add($"Даталогическая модель {typeof(PhoneDataModel).GetNameOfType()}  соответвует требованиям");
        }
        catch (Exception ex)
        {
            Messages.Add($"Даталогическая модель {typeof(PhoneDataModel).GetNameOfType()} не соответвует требованиям {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IPhoneServiceModel>().EnsureIsValide();
            Messages.Add($"Сервисная модель {typeof(IPhoneServiceModel).GetNameOfType()}  соответвует требованиям");


        }
        catch (Exception ex)
        {
            Messages.Add($"Сервисная модель {typeof(IPhoneServiceModel).GetNameOfType()} не соответвует требованиям: " + ex.Message);

        }

        return Messages;
    }
}
