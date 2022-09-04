using CoreModel.Ananlitics.DeployDataModel;

using Microsoft.EntityFrameworkCore;

public interface IDeployDataModel
{
    DbSet<ApplicationMigration> ApplicationMigrations { get; set; }
    DbSet<ApplicationUpgrade> ApplicationUpgrades { get; set; }
    DbSet<SystemsIntegration> SystemsIntegrations { get; set; }
}