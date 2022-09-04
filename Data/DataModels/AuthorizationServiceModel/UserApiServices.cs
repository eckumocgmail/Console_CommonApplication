public class UserApiServices : EntityFasade<UserApi>
{
    public UserApiServices(IDbContext context) : base(context)
    {
    }
}