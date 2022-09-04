using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

public class GroupFasade<Monitoring, Indicator> : EntityFasade<Monitoring>, IGroupFasade<Monitoring, Indicator>
    where Monitoring : BaseEntity
    where Indicator : BaseEntity
{
    public GroupFasade(IDbContext context) : base(context)
    {
    }

    public bool AddToGroup(Monitoring group, Indicator item)
    {
        throw new System.NotImplementedException();
    }

    public bool SetGroup(Monitoring group, IEnumerable<Indicator> items)
    {
        throw new System.NotImplementedException();
    }

    public bool RemoveFromGroup(Monitoring group, Indicator item)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<Indicator> ClearGroup(Monitoring group)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<Indicator> GetGroup(Monitoring group)
    {
        return typeof(Monitoring).GetProperty<IEnumerable<Indicator>>().GetValue<IEnumerable<Indicator>>(GetDbSet().Include(next => typeof(Monitoring).GetProperty<IEnumerable<Indicator>>().GetValue(next)).Where(p => p.ID == group.ID).Single());
    }

    public IDictionary<int, int> GetGroupSizeAbsReport()
    {
        return new Dictionary<int, int>(
            GetDbSet().Include(next => typeof(Monitoring).GetProperty<IEnumerable<Indicator>>().GetValue(next)).
                Select(next => new KeyValuePair<int, int>(next.ID,
                typeof(Monitoring).GetProperty<IEnumerable<Indicator>>().GetValue<IEnumerable<Indicator>>(next).Count()

            ))
        );
    }

    public IDictionary<int, int> GetGroupSizeRelReport()
    {
        var abs = GetGroupSizeAbsReport();
        var summa = abs.Values.Sum();
        foreach(var kv in abs)
        {
            abs[kv.Key] = kv.Value / summa;
        }
        return abs;
    }
}