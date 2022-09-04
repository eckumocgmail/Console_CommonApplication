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
            Messages.Add($"�������������� ������ {typeof(PhoneDataModel).GetNameOfType()}  ����������� �����������");
        }
        catch (Exception ex)
        {
            Messages.Add($"�������������� ������ {typeof(PhoneDataModel).GetNameOfType()} �� ����������� ����������� {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IPhoneServiceModel>().EnsureIsValide();
            Messages.Add($"��������� ������ {typeof(IPhoneServiceModel).GetNameOfType()}  ����������� �����������");


        }
        catch (Exception ex)
        {
            Messages.Add($"��������� ������ {typeof(IPhoneServiceModel).GetNameOfType()} �� ����������� �����������: " + ex.Message);

        }

        return Messages;
    }
}
