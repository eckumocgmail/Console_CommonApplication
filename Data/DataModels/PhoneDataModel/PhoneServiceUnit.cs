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
            Messages.Add($"ƒаталогическа€ модель {typeof(PhoneDataModel).GetNameOfType()}  соответвует требовани€м");
        }
        catch (Exception ex)
        {
            Messages.Add($"ƒаталогическа€ модель {typeof(PhoneDataModel).GetNameOfType()} не соответвует требовани€м {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IPhoneServiceModel>().EnsureIsValide();
            Messages.Add($"—ервисна€ модель {typeof(IPhoneServiceModel).GetNameOfType()}  соответвует требовани€м");


        }
        catch (Exception ex)
        {
            Messages.Add($"—ервисна€ модель {typeof(IPhoneServiceModel).GetNameOfType()} не соответвует требовани€м: " + ex.Message);

        }

        return Messages;
    }
}
