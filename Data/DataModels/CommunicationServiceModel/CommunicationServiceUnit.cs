
using System;
using System.Collections.Generic;

public class CommunicationServiceUnit : TestingElement
{
    public CommunicationServiceUnit(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            using (CommunicationDataModel model = AppProviderService.GetInstance().Get<CommunicationDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();

            }
            Messages.Add($"�������������� ������ {typeof(CommunicationDataModel).GetNameOfType()}  ����������� �����������");
        }
        catch (Exception ex)
        {
            throw new Exception($"�������������� ������ {typeof(CommunicationDataModel).GetNameOfType()} �� ����������� ����������� {ex.Message}");
        }




        try
        {
            AppProviderService.GetInstance().Get<ICommunicationServiceModel>().EnsureIsValide();
            Messages.Add($"��������� ������ {typeof(ICommunicationServiceModel).GetNameOfType()}  ����������� �����������");


        }
        catch (Exception ex)
        {
            Messages.Add($"��������� ������ {typeof(ICommunicationServiceModel).GetNameOfType()} �� ����������� �����������: " + ex.Message);

        }

        return Messages;
    }
}
