using System.Collections.Generic;

public class CrudTest : TestingElement
{
    public CrudTest(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {

        var sp = AppProviderService.GetInstance();
        try
        {
            using (var db = sp.Get<AuthorizationDataModel>())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var cruds = new DataCrud(db);
      
                Messages.Add($"Фукнция выборки список работает стабильно \n"+ cruds.Statistics().ToJsonOnScreen());
            }
        }catch(System.Exception ex)
        {
            this.Error(ex);
            Messages.Add($"Фукнция выборки список работает не стабильно \n"  );

        }
        return Messages;
    }
}