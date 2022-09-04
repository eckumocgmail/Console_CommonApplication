
using System;
using System.Collections.Generic;

public class AnaliticsServiceUnit : TestingElement
{
    public AnaliticsServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (AnaliticsDataModel model = AppProviderService.GetInstance().Get<AnaliticsDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();
                model.EnsureIsValide();

            }
            Messages.Add($"�������������� ������ {typeof(AnaliticsDataModel).GetNameOfType()}  ����������� �����������");
        }
        catch (Exception ex)
        {
            throw new Exception($"�������������� ������ {typeof(AnaliticsDataModel).GetNameOfType()} �� ����������� ����������� {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IAnaliticsServiceModel>().EnsureIsValide();
            Messages.Add($"��������� ������ {typeof(IAnaliticsServiceModel).GetNameOfType()}  ����������� �����������");


        }
        catch (Exception ex)
        {
            Messages.Add($"��������� ������ {typeof(IAnaliticsServiceModel).GetNameOfType()} �� ����������� �����������: {ex.Message}");

        }
        return Messages;
    }
}
