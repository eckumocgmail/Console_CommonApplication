


using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Link: ILink
//: //ViewItem, 
{
    //public override int ID { get; set; }
    public string Icon { get; set; }
    public string Label { get; set; }
    public string Href { get; set; }
    public bool IsActive { get; set; } = false;
    public string Tooltip { get; set; } = "";
    public List<ILink> ChildLinks { get; set; } = new List<ILink>();


    [Newtonsoft.Json.JsonIgnore()]
    [JsonIgnore()]
    public object Item { get; set; }
}