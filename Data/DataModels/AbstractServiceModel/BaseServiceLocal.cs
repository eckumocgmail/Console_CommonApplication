using System;
using System.Threading.Tasks;

 
public abstract class Local : DictionaryTable, IModel

{
    [InputUrl] 
    [NotNullNotEmpty()]
    public string Url { get; set; }

    [NotNullNotEmpty()]
    public MyApplicationModel Model { get; set; }
    public int LoginCount { get; set; } = 0;


    [Service]
    [NotNullNotEmpty()]
    public ServiceCertificate ServiceCertificate { get; set; }


    protected Local( IServiceProvider provider )
    {
        this.Description = this.Name = this.GetTypeName();
        this.Init(provider);
        this.Url = provider.Get<Service>().Url + "/" + this.Name;
        EnsureIsValide();
    }


    public RequestMessage ActionEvent(ResponseMessage message)
    {
        this.Info(message);
        throw new System.NotImplementedException();
    }

    public async Task<RequestMessage> ActionEventAsync(ResponseMessage message)
    {
        this.Info(message);
        await Task.CompletedTask;
        return null;
     
    }


    public async Task DoCheck(long timeout)
    {
        this.Info(timeout);        
        await Task.CompletedTask;
    }

    public Task Request(DataRequestMessage message)
    {
        throw new System.NotImplementedException();
    }


}
