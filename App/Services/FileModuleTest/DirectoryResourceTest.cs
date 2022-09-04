using RootLaunch;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DirectoryTest : TestingElement
{
    public override System.Collections.Generic.List<string> OnTest()
    
    {
        var wrk = DirectoryResource.Get( );
        this.Info(wrk.GetFiles().ToJsonOnScreen());
        return Messages;
    }
}
