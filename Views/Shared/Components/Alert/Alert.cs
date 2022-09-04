
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Alert: ViewItem
{

    public string Message { get; set; }

    public Alert()
    {
        this.Color = "info";
        this.Message = "";
    }

    public Alert( string message)
    {
        
        Message = message;
    }
    public Alert(string color, string message)
    {
        Color = color;
        Message = message;
    }
}

