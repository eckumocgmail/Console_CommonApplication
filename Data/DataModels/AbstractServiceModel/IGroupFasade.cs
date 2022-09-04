using System.Collections.Generic;

public interface IGroupFasade<MainEntity, IRelativeEntity>:
    IEntityFasade<MainEntity> where MainEntity : BaseEntity
{
    public bool AddToGroup(MainEntity group, IRelativeEntity item);
    public bool SetGroup( MainEntity group, IEnumerable<IRelativeEntity> items );
    public bool RemoveFromGroup(MainEntity group, IRelativeEntity item);
    
    public IEnumerable<IRelativeEntity> ClearGroup(MainEntity group);
    public IEnumerable<IRelativeEntity> GetGroup(MainEntity group);


    /// <summary>
    /// Отчет объёмах групп в абс. величинах
    /// </summary>    
    public IDictionary<int, int> GetGroupSizeAbsReport();

    /// <summary>
    /// Отчет объёмах групп, в процентном соотношении
    /// </summary>    
    public IDictionary<int, int> GetGroupSizeRelReport();
}