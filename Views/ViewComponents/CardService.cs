using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class CardService
{
    public global::ComponentViewModel ForEntity(object record)
    {
        var card = new global::ComponentViewModel(record);

        return card;
    }
}