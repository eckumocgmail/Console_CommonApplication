using CoreModel.Ananlitics.DeployDataModel;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DeployDataModel : BaseDbContext, IDeployDataModel
{
    public DeployDataModel()
    {
    }

    public DeployDataModel(DbContextOptions<DeployDataModel> options) : base(options)
    {
    }
    protected override void InitDbSets()
    {
    }
    public virtual DbSet<ApplicationUpgrade> ApplicationUpgrades { get; set; }
    public virtual DbSet<SystemsIntegration> SystemsIntegrations { get; set; }
    public virtual DbSet<ApplicationMigration> ApplicationMigrations { get; set; }


}