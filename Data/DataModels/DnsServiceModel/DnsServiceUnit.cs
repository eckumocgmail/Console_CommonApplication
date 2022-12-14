
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
            Messages.Add($"Даталогическая модель {typeof(DnsDataModel).GetNameOfType()}  соответвует требованиям");
        }
        catch (Exception ex)
        {
            Messages.Add($"Даталогическая модель {typeof(DnsDataModel).GetNameOfType()} не соответвует требованиям {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IDnsServiceModel>().EnsureIsValide();
            Messages.Add($"Сервисная модель {typeof(IDnsServiceModel).GetNameOfType()}  соответвует требованиям");


        }
        catch (Exception ex)
        {
            Messages.Add($"Сервисная модель {typeof(IDnsServiceModel).GetNameOfType()} не соответвует требованиям: " + ex.Message);

        }

        return Messages;
    }
}
