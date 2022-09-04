
using Microsoft.EntityFrameworkCore;


public sealed class CommunicationDataModel : BaseDbContext, ICommunicationDataModel
{
    public DbSet<AnalogTransmission> AnalogTransmissions { get; set; }
    public DbSet<ConnectionAddress> ConnectionAddress { get; set; }
    public DbSet<DeviceConnected> DevicesConnected { get; set; }

    public DbSet<MagistralChanal> MagistralChanals { get; set; }
    public DbSet<MediaDevice> MediaDevices { get; set; }
    public DbSet<MediaDeviceDefinition> MediaDeviceDefinitions { get; set; }
    public DbSet<MediaTransmission> MediaTransmission { get; set; }
    public DbSet<OpticalTransmission> OpticalTransmission { get; set; }
    public DbSet<RadioDevice> RadioDevice { get; set; }
    public DbSet<RadioTansmission> RadioTansmission { get; set; }
    public DbSet<ZoneChanals> ZoneChanals { get; set; }

    protected override void InitDbSets()
    {
    }
    public CommunicationDataModel()
    {
    }

    public CommunicationDataModel(DbContextOptions<CommunicationDataModel> options) : base(options)
    {
    }
}
 
