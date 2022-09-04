using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public class ActivationModel
{   
    [DisplayName("Код активации")] 
 
    public string ActivationKey { get; set; }

    public string Email { get; set; }
    public string Message { get; set; }


}
