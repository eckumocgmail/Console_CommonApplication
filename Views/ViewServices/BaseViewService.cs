using System;

public abstract class BaseViewService<TViewModel, TDataModel> 
    where TViewModel    :   ViewItem
    where TDataModel    :   BaseEntity
{
    [Service] public IBusinessApplicationDesigner ServiceProvider { get; }


    public BaseViewService(IBusinessApplicationDesigner provider) 
    {
        this.ServiceProvider = provider;
    }

    public virtual void InitView()
    {
        this.Init((IServiceProvider)this.ServiceProvider);
    }

    public virtual void UpdateView()
    {
        this.Init((IServiceProvider)this.ServiceProvider);
    }
}