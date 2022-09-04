public class UserSettingsServices : EntityFasade<UserSettings>
{
     

    public UserSettingsServices(IDbContext context) : base(context)
    {
    }
}