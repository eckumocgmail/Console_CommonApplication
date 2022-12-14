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
            Messages.Add($"Даталогическая модель {typeof(MedicalDataModel).GetNameOfType()}  соответвует требованиям");
        }
        catch (Exception ex)
        {
            throw new Exception($"Даталогическая модель {typeof(MedicalDataModel).GetNameOfType()} не соответвует требованиям {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IMedicalCardService>().EnsureIsValide();
            Messages.Add($"Сервисная модель {typeof(IMedicalCardService).GetType().GetNameOfType()}  соответвует требованиям");


        }
        catch (Exception ex)
        {
            throw new Exception($"Сервисная модель {typeof(IMedicalCardService).GetType().GetNameOfType()} не соответвует требованиям: " + ex.Message);

        }

        return Messages;
    }
}
