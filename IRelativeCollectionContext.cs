using System.Collections.Generic;

public interface IRelativeCollectionContext<TEntity>
{
    public int Add(params TEntity[] items);
    public int Remove(params TEntity[] items);
    public bool HasAll(params TEntity[] items);
    public bool Has(TEntity items);
    public bool HasAll(params int[] ids);
    public HashSet<TEntity> Expect(params TEntity[] items);
    public HashSet<TEntity> Inspect(params TEntity[] items);
    public HashSet<TEntity> Search( string query );   
}
