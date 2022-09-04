
using AppModel.Models.DnsServiceModel;

using System;
using System.Collections.Generic;

public class DnsServiceUnit : TestingElement
{
    public DnsServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (DnsDataModel model = AppProviderService.GetInstance().Get<DnsDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();

            }
            Messages.Add($"�������������� ������ {typeof(DnsDataModel).GetNameOfType()}  ����������� �����������");
        }
        catch (Exception ex)
        {
            Messages.Add($"�������������� ������ {typeof(DnsDataModel).GetNameOfType()} �� ����������� ����������� {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IDnsServiceModel>().EnsureIsValide();
            Messages.Add($"��������� ������ {typeof(IDnsServiceModel).GetNameOfType()}  ����������� �����������");


        }
        catch (Exception ex)
        {
            Messages.Add($"��������� ������ {typeof(IDnsServiceModel).GetNameOfType()} �� ����������� �����������: " + ex.Message);

        }

        return Messages;
    }
}
