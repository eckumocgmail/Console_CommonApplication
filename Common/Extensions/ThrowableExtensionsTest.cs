using System;

public class ThrowableExtensionsTest : TestingElement
{

 

    public override System.Collections.Generic.List<string> OnTest()
    {
        try
        {
            throw new Exception();

        }
        catch (Exception ex)
        {
            try
            {
                ex.ToHTML().WriteToConsole();
                Messages.Add("Реализована функция формирования HTML для исключений");
            }catch (Exception ex2)
            {
                Messages.Add("Не реализована функция формирования HTML для исключений "+ex2.Message);
            }
            
        }
        return Messages;
    }
}
