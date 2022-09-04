public interface IMessageProperty
{
    IMessageAttribute Attribute { get; set; }
    int AttributeID { get; set; }
    string Help { get; set; }
    bool Index { get; set; }
    string Label { get; set; }
    IMessageProtocol MessageProtocol { get; set; }
    int MessageProtocolID { get; set; }
    string Name { get; set; }
    int Order { get; set; }
    bool Required { get; set; }
    bool Unique { get; set; }
}