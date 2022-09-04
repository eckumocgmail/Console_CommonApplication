
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


public class RestoreModel: InputPageModel<string>
{
    public RestoreModel(IServiceProvider provider) : base(provider)
    {
    }

    [BindProperty]
    [DisplayName("Электронный адрес")]
    [DataType(
        DataType.EmailAddress,
        ErrorMessage = "Электронный адрес задан некорректно"
    )]
    [NotNullNotEmptyAttribute( "Не указан электронный адрес")]
    public string Email { get; set; }
       
}
