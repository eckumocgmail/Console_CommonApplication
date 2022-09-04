using System.Threading.Tasks;

public abstract class Http: IModel
{
    public string Description { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public object Item { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public string Url { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public ServiceCertificate ServiceCertificate { get; set; }
    public int LoginCount { get; set; }
    public MyApplicationModel Model { get; set; }



    protected Http(HttpClientController http)
    {
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
        throw new System.NotImplementedException();
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
