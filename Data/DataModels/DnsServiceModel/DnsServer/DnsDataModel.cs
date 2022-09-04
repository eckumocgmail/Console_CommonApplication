using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;


public class DnsDataModel: BaseDbContext
{
    private static void Configure(DbContextOptionsBuilder optionsBuilder)
    {            
        if (optionsBuilder.IsConfigured==false)
        {
            optionsBuilder.Info($"UseInMemoryDatabase({nameof(DnsDataModel)})");
            optionsBuilder.UseInMemoryDatabase(nameof(DnsDataModel));
        }
    }
    public static void ConfigureServices(IServiceCollection services)
    {
        services.Info($"ConfigureServices()");
        services.AddDbContext<DnsDataModel>(options => Configure(options), ServiceLifetime.Scoped);
        services.AddScoped(typeof(IEntityFasade<DnsRecord>),
            sp => new EntityFasade<DnsRecord>(sp.GetRequiredService<DnsDataModel>()));
    }
    protected override void InitDbSets()
    {
    }
    //=======================================================================
    public virtual DbSet<DnsRecord> DnsRecords { get; set; }
    public class DnsRecord: BaseEntity 
    {
    
        public string IP4 { get; set; }
        public string IP6 { get; set; }
        public string Owner { get; set; }
        public string Origin { get; set; }           
    }
    //=======================================================================
    public DnsDataModel() {
        this.Info("Создан новый экземпляр");        
    }
    public DnsDataModel(DbContextOptions<DnsDataModel> options):base(options) {
        this.Info("Создан новый экземпляр");
    }
    //=======================================================================
    protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        this.Info($"OnConfiguring()");
        Configure(optionsBuilder);
    }       
    protected  override void OnModelCreating(ModelBuilder modelBuilder)
    {
        this.Info($"OnModelCreating()");
        modelBuilder
            .Entity<DnsRecord>()
            .HasIndex(b => b.Origin)
            .IsUnique();
        modelBuilder
            .Entity<DnsRecord>()
            .HasIndex(b => b.IP4)
            .IsUnique();
    }
    //=======================================================================
    public async Task Write( TextWriter output )
    {

        foreach( DnsRecord record in await this.DnsRecords.ToListAsync())
        {
            this.Info($" => {record.IP4} {record.Origin}");
            output.WriteLine($"{record.IP4} {record.Origin}");
            await output.FlushAsync();
        }
    }
    public async Task Read(TextReader input)
    {
        string line = null;
        while ((line = input.ReadLine()) != null)
        {
            var words = line.Split(" ");
            await DnsRecords.AddAsync(new DnsRecord()
            {
                IP4 = words[0],
                Origin = words[1]
            });
            this.Info($" <= {line}");
            await SaveChangesAsync();
        }
    }
}
