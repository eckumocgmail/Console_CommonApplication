public class UserPersonServices : EntityFasade<UserPerson>
{
    public UserPersonServices(IDbContext context) : base(context)
    {
    }
}