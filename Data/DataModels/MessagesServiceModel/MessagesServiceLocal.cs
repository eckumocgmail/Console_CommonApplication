using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MessagesServiceLocal: Local, IMessagesServiceModel
{
    public IHierDictionaryFasade<MessageProtocol> MessageProtocols { get; set; }
    public IEntityFasade<MessageProperty> MessageProperties { get; set; }
    public IEntityFasade<MessageAttribute> MessageAttributes { get; set; }



    public MessagesServiceLocal(IServiceProvider provider) : base(provider)
    {
        this.MessageProtocols = new DbHierDictionaryFasade<MessageProtocol>(provider.GetService<MessagesDataModel>());
    }

    public IDictionary<string, MessageProtocol> Map()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public IDictionary<string, MessageProtocol> Map(int resourceId)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    MessageProtocol IMessagesServiceModel.Get(string url)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public Form Input(string url)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }



    public void InitMessageAttributes()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public void InitMessageProtocols()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}
