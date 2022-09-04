
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
            Messages.Add($"�������������� ������ {typeof(BusinessDataModel).GetNameOfType()}  ����������� �����������");
        }
        catch (Exception ex)
        {
            throw new Exception($"�������������� ������ {typeof(BusinessDataModel).GetNameOfType()} �� ����������� ����������� {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IBusinessServiceModel>().EnsureIsValide();
            Messages.Add($"��������� ������ {typeof(IBusinessServiceModel).GetNameOfType()}  ����������� �����������");


        }
        catch (Exception ex)
        {
            Messages.Add($"��������� ������ {typeof(IBusinessServiceModel).GetNameOfType()} �� ����������� �����������: " + ex.Message);

        }
        return Messages;
    }
}
