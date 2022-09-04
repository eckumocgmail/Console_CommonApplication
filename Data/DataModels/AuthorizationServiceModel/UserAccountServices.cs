public class UserAccountServices : EntityFasade<UserAccount>
{
    public UserAccountServices(IDbContext context) : base(context)
    {
    }
}