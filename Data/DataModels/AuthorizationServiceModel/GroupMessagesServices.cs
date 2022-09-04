public class GroupMessagesServices : EntityFasade<UserGroupMessage>
{
    public GroupMessagesServices(IDbContext context) : base(context)
    {
    }
}