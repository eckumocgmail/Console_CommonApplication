
using System;
using System.Collections.Generic;

public class AppServiceUnit : TestingElement
{
    public AppServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {

        try
        {
            using (AppDataModel model = AppProviderService.GetInstance().Get<AppDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();
                model.EnsureIsValide();

            }
            Messages.Add($"�������������� ������ {typeof(AppDataModel).GetNameOfType()} ����������� �����������");
        }
        catch (Exception ex)
        {
            throw new Exception($"�������������� ������ {typeof(AppDataModel).GetNameOfType()} �� ����������� ����������� {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IAppServiceModel>().EnsureIsValide();
            Messages.Add($"��������� ������ {typeof(IAppServiceModel).GetNameOfType()}  ����������� �����������");


        }
        catch (Exception ex)
        {
            Messages.Add($"��������� ������ {typeof(IAppServiceModel).GetNameOfType()} �� ����������� �����������: "+ex.Message);

        }
        return Messages;
    }
}
