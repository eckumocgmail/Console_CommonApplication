using System.Collections.Generic;

public interface IMessageProtocol
{
    
    int? FromBusinessFunctionID { get; set; }
    int? FromID { get; set; }
    List<IMessageProperty> Properties { get; set; }
 
    int? ToBusinessFunctionID { get; set; }
    int? ToID { get; set; }

 
    string GetInputTableName();
   
}