using System;
using System.Collections.Generic;


public class MedicalServiceUnit : TestingElement
{
    public MedicalServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (MedicalDataModel model = AppProviderService.GetInstance().Get<MedicalDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();

            }
            Messages.Add($"ƒаталогическа€ модель {typeof(MedicalDataModel).GetNameOfType()}  соответвует требовани€м");
        }
        catch (Exception ex)
        {
            throw new Exception($"ƒаталогическа€ модель {typeof(MedicalDataModel).GetNameOfType()} не соответвует требовани€м {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IMedicalCardService>().EnsureIsValide();
            Messages.Add($"—ервисна€ модель {typeof(IMedicalCardService).GetType().GetNameOfType()}  соответвует требовани€м");


        }
        catch (Exception ex)
        {
            throw new Exception($"—ервисна€ модель {typeof(IMedicalCardService).GetType().GetNameOfType()} не соответвует требовани€м: " + ex.Message);

        }

        return Messages;
    }
}
