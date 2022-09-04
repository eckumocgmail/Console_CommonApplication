using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class ListItem: ViewItem
{

    [NotNullNotEmpty("Необходимо задать значение для заголовка")]
    public string Title { get; set; }


    [NotNullNotEmpty("Необходимо указать ссылку")]
    public string Href { get; set; }
    
    public ListItem()
    {
        Selectable = true;
        Title = "Item";
        this.OnEvent = (evt) => {



            this.Info(evt);
        };
    }
 
}