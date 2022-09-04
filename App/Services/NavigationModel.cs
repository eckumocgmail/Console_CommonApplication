using System;
using System.Collections.Generic;

public abstract class NavigationModel: ILink
{

    public string ID { get; set; }
    public string Icon { get; set; }
    public string Label { get; set; }
    public string Tooltip { get; set; }

    public string Href { get; set; }
    public object Item { get; set; }
    public bool IsActive { get; set; }
    public List<ILink> ChildLinks { get; set; }


    public string State { get; set; } = "/Index";


    public Dictionary<string, object> States { get; set; } = new Dictionary<string, object>();







}
