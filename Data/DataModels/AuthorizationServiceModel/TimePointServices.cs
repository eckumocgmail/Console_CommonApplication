public class TimePointServices : EntityFasade<TimePoint>
{
    public TimePointServices(IDbContext context) : base(context)
    {
    }
}