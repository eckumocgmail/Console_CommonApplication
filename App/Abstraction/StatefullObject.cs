using System.Collections.Generic;
using System.Collections.Concurrent;
/// <summary>
/// 
/// </summary>
public abstract class StatefullObject<TMockResult> :  ConcurrentQueue<TMockResult>, IStatefull<ConcurrentQueue<TMockResult>>
where TMockResult: class
{
    private int Version = 0;

    public StatefullObject()
    {
        this.LoadState();
    }

    public abstract void SaveState();

    public abstract void LoadState();

    public abstract void LoadState(int index);

    public abstract IDictionary<int, ConcurrentQueue<TMockResult>> GetHistory();
}

 