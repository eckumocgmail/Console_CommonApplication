
using System.Collections.Generic;

public class MessagesServiceModel: IMessagesServiceModel
{
 
    public IEntityFasade<MessageProtocol> MessageProtocols { get; set; }
    public IEntityFasade<MessageProperty> MessageProperties { get; set; }
    public IEntityFasade<MessageAttribute> MessageAttributes { get; set; }
    public IEntityFasade<ValidationModel> ValidationModels { get; set; }
    public IEntityFasade<BusinessResource> BusinessResources { get; set; }
    public IEntityFasade<BusinessFunction> BusinessFunctions { get; set; }
    public IEntityFasade<BusinessProcess> BusinessProcess { get; set; }

    public MessagesServiceModel()
    {
    }

    public IDictionary<string, MessageProtocol> Map()
    {
        throw new System.NotImplementedException();
    }

    public IDictionary<string, MessageProtocol> Map(int resourceId)
    {
        throw new System.NotImplementedException();
    }

    public MessageProtocol Get(string url)
    {
        throw new System.NotImplementedException();
    }

    public Form Input(string url)
    {
        throw new System.NotImplementedException();
    }

    IHierDictionaryFasade<MessageProtocol> IMessagesServiceModel.MessageProtocols { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void InitMessageAttributes()
    {
        throw new System.NotImplementedException();
    }

    public void InitMessageProtocols()
    {
        throw new System.NotImplementedException();
    }
}
