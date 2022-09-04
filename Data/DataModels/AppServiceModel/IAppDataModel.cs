using Microsoft.EntityFrameworkCore;

public interface IAppDataModel
{

    public DbSet<MyApplicationModel> Applications { get; set; }
    public DbSet<MyControllerModel> Controllers { get; set; }
    public DbSet<MyActionModel> Actions { get; set; }
    public DbSet<MyParameterDeclarationModel> Parameters { get; set; }
}