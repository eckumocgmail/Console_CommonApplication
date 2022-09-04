using RootLaunch;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FileResourceTest: TestingElement
{
    public override System.Collections.Generic.List<string> OnTest()
    {
        var file = new FileResource("Program.cs");
        this.Info(file.ReadText());
        return this.Messages;

    }
}
