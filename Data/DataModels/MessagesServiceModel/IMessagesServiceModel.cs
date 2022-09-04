using System.Collections.Generic;

public interface IMessagesServiceModel
{
    // получение всех адресов
    public IDictionary<string, MessageProtocol> Map( );
    // получение всех адресов
    public IDictionary<string, MessageProtocol> Map(int resourceId);
    // получение по адресу
    public MessageProtocol Get(string url);
    // получение по адресу
    public Form Input(string url);

    public IHierDictionaryFasade<MessageProtocol> MessageProtocols { get; set; }
    public IEntityFasade<MessageProperty> MessageProperties { get; set; }
    public IEntityFasade<MessageAttribute> MessageAttributes { get; set; }

    public void InitMessageAttributes();
    public void InitMessageProtocols();
}