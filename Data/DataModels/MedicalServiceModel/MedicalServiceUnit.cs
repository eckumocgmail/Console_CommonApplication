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
            Messages.Add($"�������������� ������ {typeof(MedicalDataModel).GetNameOfType()}  ����������� �����������");
        }
        catch (Exception ex)
        {
            throw new Exception($"�������������� ������ {typeof(MedicalDataModel).GetNameOfType()} �� ����������� ����������� {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IMedicalCardService>().EnsureIsValide();
            Messages.Add($"��������� ������ {typeof(IMedicalCardService).GetType().GetNameOfType()}  ����������� �����������");


        }
        catch (Exception ex)
        {
            throw new Exception($"��������� ������ {typeof(IMedicalCardService).GetType().GetNameOfType()} �� ����������� �����������: " + ex.Message);

        }

        return Messages;
    }
}
