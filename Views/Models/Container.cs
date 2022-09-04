using System;

public class Container: ViewItem
{
    public string View = "FlexContainer";

    public bool Horizontal { get => Get<bool>("Horizontal"); set => Set<bool>("Horizontal", value); }


    //[SelectControlAttribute("'wrap','nowrap'")]
    public string FlexWrap { get => Get<string>("FlexWrap"); set => Set<string>("FlexWrap", value); }

    public Container()
    {       
        Horizontal = true;
        FlexWrap = "wrap";
        Changed = false;
        
    }

    public void ToContextMenu()
    {
        View = "ContextMenu";
    }


}
