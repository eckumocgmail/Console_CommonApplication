using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class ReportComponent: ComponentEvents
{
    public readonly TypeNode<ComponentModel> Root;


    public ReportComponent(TypeNode<ComponentModel> Node) 
    {
        Root = Node;
    }



    public object Find(string Key)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

        



    public void OnInit()
    {

    }

       

    public void OnChanges()
    {
            
    }

    public void OnUpdate()
    {
            
    }

    public void OnDestroy()
    {
            
    }
}
