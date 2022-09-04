using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

public class TestTypeScriptSeriallizer : TestingElement
{
    public TestTypeScriptSeriallizer()
    {
    }

    public TestTypeScriptSeriallizer(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        try
        {
            var seriallizer = new TypeScriptClassSeriallizer();
            string script = seriallizer.ToTypeScript( typeof(UserAccount));
            Messages.Add("Удалось сформировать код TypeScript => \n"+ script);

        }
        catch (Exception ex)
        {
            this.Error(ex);

            Messages.Add($"Не удалось сформировать код TypeScript => \n\t{ex.Message}\n\n{ex.StackTrace}\n");
        }


        return Messages;
    }
} 