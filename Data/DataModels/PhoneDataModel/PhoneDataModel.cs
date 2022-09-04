using ApplicationDb.Entities;

using CoreModel.Ananlitics.DeployDataModel;

using Microsoft.EntityFrameworkCore;

public interface IPhoneDataModel: IFilesDataModel, IDeployDataModel, IAuthorizationDataModel, IMessagesDataModel, ICommunicationDataModel
{

}
public class PhoneDataModel: BaseDbContext, IPhoneDataModel
{
    protected override void InitDbSets()
    {
    }
    public DbSet<FileCatalog> FileCatalogs { get; set; }
    public DbSet<TextResource> TextResources { get; set; }
    public DbSet<AudioResource> AudioResources { get; set; }
    public DbSet<PhotoResource> PhotoResources { get; set; }
    public DbSet<VideoResource> VideoResources { get; set; }
    public DbSet<ApplicationMigration> ApplicationMigrations { get; set; }
    public DbSet<ApplicationUpgrade> ApplicationUpgrades { get; set; }
    public DbSet<SystemsIntegration> SystemsIntegrations { get; set; }
    public DbSet<UserAccount> Accounts { get; set; }
    public DbSet<UserApi> Users { get; set; }
    public DbSet<UserGroups> UserGroups { get; set; }
    public DbSet<UserGroup> Groups { get; set; }
    public DbSet<UserMessage> Messages { get; set; }
    public DbSet<UserPerson> Persons { get; set; }
    public DbSet<UserSettings> Settings { get; set; }
    public DbSet<BusinessResource> BusinessResources { get; set; }
    public DbSet<TimePoint> Calendars { get; set; }
    public DbSet<UserGroupMessage> GroupMessages { get; set; }
    public DbSet<MessageAttribute> MessageAttributes { get; set; }
    public DbSet<MessageProperty> MessageProperties { get; set; }
    public DbSet<MessageProtocol> MessageProtocols { get; set; }
    public DbSet<ValidationModel> ValidationModels { get; set; }
    public DbSet<BusinessFunction> BusinessFunctions { get; set; }
    public DbSet<BusinessProcess> BusinessProcess { get; set; }
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
}