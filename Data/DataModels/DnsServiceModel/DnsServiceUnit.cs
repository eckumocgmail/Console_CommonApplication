
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
            Messages.Add($"ƒаталогическа€ модель {typeof(DnsDataModel).GetNameOfType()}  соответвует требовани€м");
        }
        catch (Exception ex)
        {
            Messages.Add($"ƒаталогическа€ модель {typeof(DnsDataModel).GetNameOfType()} не соответвует требовани€м {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<IDnsServiceModel>().EnsureIsValide();
            Messages.Add($"—ервисна€ модель {typeof(IDnsServiceModel).GetNameOfType()}  соответвует требовани€м");


        }
        catch (Exception ex)
        {
            Messages.Add($"—ервисна€ модель {typeof(IDnsServiceModel).GetNameOfType()} не соответвует требовани€м: " + ex.Message);

        }

        return Messages;
    }
}
