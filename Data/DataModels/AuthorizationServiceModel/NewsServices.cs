public class NewsServices : EntityFasade<ServiceMessage>
{
    public NewsServices(IDbContext context) : base(context)
    {
    }
}