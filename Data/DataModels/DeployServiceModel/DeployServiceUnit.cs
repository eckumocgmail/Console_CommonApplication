
using System;
using System.Collections.Generic;

public class DeployServiceUnit : TestingElement
{
    public DeployServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (DeployDataModel model = AppProviderService.GetInstance().Get<DeployDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();

            }
            Messages.Add($"�������������� ������ {typeof(DeployDataModel).GetNameOfType()}  ����������� �����������");
        }
        catch (Exception ex)
        {
            throw new Exception($"�������������� ������ {typeof(DeployDataModel).GetNameOfType()} �� ����������� ����������� {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IDeployServiceModel>().EnsureIsValide();
            Messages.Add($"��������� ������ {typeof(IDeployServiceModel).GetNameOfType()}  ����������� �����������");


        }
        catch (Exception ex)
        {
            Messages.Add($"��������� ������ {typeof(IDeployServiceModel).GetNameOfType()} �� ����������� �����������: " + ex.Message);

        }

        return Messages;
    }
}
