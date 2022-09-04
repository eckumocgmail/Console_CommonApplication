
using System;
using System.Collections.Generic;

public class CatalogServiceUnit : TestingElement
{
    public CatalogServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (CatalogDataModel model = AppProviderService.GetInstance().Get<CatalogDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();

            }
            Messages.Add($"�������������� ������ {typeof(CatalogDataModel).GetNameOfType()}  ����������� �����������");
        }
        catch (Exception ex)
        {
            throw new Exception($"�������������� ������ {typeof(CatalogDataModel).GetNameOfType()} �� ����������� ����������� {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<ICatalogServiceModel>().EnsureIsValide();
            Messages.Add($"��������� ������ {typeof(ICatalogServiceModel).GetNameOfType()}  ����������� �����������");


        }
        catch (Exception ex)
        {
            Messages.Add($"��������� ������ {typeof(ICatalogServiceModel).GetNameOfType()} �� ����������� �����������: " + ex.Message);

        }

        return Messages;
    }
}
