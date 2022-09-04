using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 
public class FindStr: CmdService
{
    public FindStr() : base()
    {
    }



    public string Find(string regularExpression, string filename)
    {            
        return CmdExec("findstr /n /r " + regularExpression + " " + filename);
    }
        

    public Dictionary<string, object> Search( string regularExpression )
    {
        Dictionary<string, object> searchResults = new Dictionary<string, object>();
        /*foreach( string file in GetAppDataResources("documentation"))
        {
            //string result = this.Execute("findstr /n /r " + regularExpression + " "+file,(line)=> { return 1; });
            string[] results = null;// result.Split("\n");
            searchResults[file] = new HashSet<string>(results);
        }*/
        return searchResults;            
    }

        
}
 

/// <summary>
/// 
/// </summary>
[Label("")]
[Description("")]
public class FindStrTest: TestingElement
{
    public FindStrTest()
    {
    }

    public FindStrTest(TestingElement parent) : base(parent)
    {
    }

    public override List<string> OnTest()
    {
        return DoTest<FindStr>(service => { 
        });
    }
}