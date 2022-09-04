using System.Collections.Generic;

public interface IMessageAttribute
{
    string CSharpType { get; set; }
    string Icon { get; set; }
    string InputType { get; set; }
    bool IsSystem { get; set; }
    string MySQLDataType { get; set; }
    string OracleDataType { get; set; }
    string PostgreDataType { get; set; }
    string SqlServerDataType { get; set; }
    string SQLType { get; set; }
    List<ValidationModel> Validations { get; set; }
}