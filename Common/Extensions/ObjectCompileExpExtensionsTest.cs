using System;

public class ObjectCompileExpExtensionsTest : TestingElement
{

    public void CompileTest() {

        try
        {
         
            Messages.Add("Умеем динамически исполнить выражения исп. рефлексию: "+ this.Compile("GetType().Name"));

        }
        catch (Exception)
        {
            Messages.Add("Выражения не компилируются");
        }


    }

    public override System.Collections.Generic.List<string> OnTest()
    {
        CompileTest();
        return Messages;
    }
}
