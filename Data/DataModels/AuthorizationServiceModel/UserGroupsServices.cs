public class UserGroupsServices : EntityFasade<UserGroups>
{
    public UserGroupsServices(IDbContext context) : base(context)
    {
    }
}