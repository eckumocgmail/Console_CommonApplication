 

using System;
using System.Collections.Generic;

public class BookViewServiceTest: TestingElement
{
    public override List<string> OnTest()
    {
        try
        {
            var service = this.Get<BookViewService<UserGroups>>();
           
            Messages.Add("");
        }
        catch(Exception ex)
        {
            Messages.Add($"{ex}");
        }
        
        return Messages;
    }
}