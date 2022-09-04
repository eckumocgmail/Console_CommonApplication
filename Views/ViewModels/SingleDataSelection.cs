
using System.Collections.Generic;

[Description("Контроллер предназначен для .")]
public interface SingleDataSelection 
{
    public List<object> Selected { get; set; }
    public DataResponseMessage OnSelected(int id);
 
}