public class InMemoryViewService<T1, T2>: BaseViewService<T1, T2>
    where T1 : ViewItem
    where T2 : BaseEntity
{
    public InMemoryViewService(IBusinessApplicationDesigner provider) : base(provider)
    {
    }

    public override void InitView()
    {
        throw new System.NotImplementedException();
    }

 
}