using System;

public class BasePageModel
{
    public BasePageModel(IServiceProvider provider)
    {
        Provider = provider;
    }

    public IServiceProvider Provider { get; }
}