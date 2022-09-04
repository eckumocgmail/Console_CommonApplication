public class LoginEventsServices : EntityFasade<UserAuthEvent>
{
    public LoginEventsServices(IDbContext context) : base(context)
    {
    }
}