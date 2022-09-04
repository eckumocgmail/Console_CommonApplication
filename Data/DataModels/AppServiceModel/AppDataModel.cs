using Microsoft.EntityFrameworkCore;

public class AppDataModel: BaseDbContext,IAppDataModel
{
    public DbSet<MyApplicationModel> Applications { get; set; }
    public DbSet<MyControllerModel> Controllers { get; set; }
    public DbSet<MyActionModel> Actions { get; set; }
    public DbSet<MyParameterDeclarationModel> Parameters { get; set; }

    public AppDataModel()
    {        
    }

    protected override void InitDbSets()
    {
    }
}
