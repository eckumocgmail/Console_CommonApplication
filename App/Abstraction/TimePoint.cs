public class TimePoint:BaseEntity
{
    public long Timestamp;
    [InputNumber]
    public int Week { get;  set; }
    [InputNumber]
    public int Month { get;  set; }
    [InputNumber]
    public int Year { get;  set; }
    [InputNumber]
    public int Date { get;  set; }
    [InputNumber]
    public int Day { get;  set; }
    [InputNumber]
    public int Quarter { get;  set; }
}