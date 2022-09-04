 

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using MvcMarketPlace.Data.Entities;

using NetCoreConstructorAngular.Data;



[Label("Модель интернет-магазина")]
[Description("Абстракция высшего уровня, решает дугие задачи в нутри системы")]
public sealed class MarketDataModel: BaseDbContext, IMarketDataModel
{

    public MarketDataModel() : base() { }
    public MarketDataModel(DbContextOptions<MarketDataModel> options) : base(options) { }

    protected override void InitDbSets()
    {
    }
    public DbSet<MarketPlace> MarketPlaces { get; set; }
    public DbSet<MoneyTransfer> MoneyTransfers { get; set; }
    public DbSet<PriceList> PriceLists { get; set; }
    public DbSet<ProductCategory> ProductCategorys { get; set; }
    public DbSet<ProductCountInfo> ProductCountInfos { get; set; }
    public DbSet<ProductDescription> ProductDescriptions { get; set; }
    public DbSet<ProductionDealer> ProductionDealers { get; set; }
    public DbSet<SaleComposition> SaleCompositions { get; set; }    
    public DbSet<SaleContract> SaleContracts { get; set; }
    public DbSet<UserWallet> UserWallets { get; set; }   
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<SepateSubdivision> SepateSubdivisions { get; set; }



    /// <summary>
    /// Выполняется по событию установки конфигурации в EntityFramework
    /// </summary>
    /// <param name="builder">объект содержит методы конфигурации</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Api.Utils.Info(AuthorizationDataModel.DEFAULT_CONNECTION_STRING);
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase(nameof(AppDbContext));
            //optionsBuilder.UseSqlServer(AuthorizationDataModel.DEFAULT_CONNECTION_STRING);
            //optionsBuilder.ConfigureWarnings(ConfigureWarnings);
            optionsBuilder.EnableDetailedErrors(true);
            optionsBuilder.AddInterceptors(new IInterceptor[] { new LoggingInterceptor() });
        }

    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }





}