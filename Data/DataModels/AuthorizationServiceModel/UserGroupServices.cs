using ApplicationDb.Entities;

public class UserGroupServices : EntityFasade<UserGroup>
{
    public UserGroupServices(IDbContext context) : base(context)
    {
    }
}