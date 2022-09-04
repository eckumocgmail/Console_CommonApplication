 
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Reflection;
using Microsoft.AspNetCore.Http;

 
[Route( "api/[controller]" )]
[ApiController]
public class AppController: Controller
{        
    public AppController( ):base(  )
    {            
    }

    public string Index() => GetType().Name;

    //[HttpGet("{key?}/{value?}")]
    [HttpGet()]
    public Dictionary<string, object> GetRequest( string path, string pars )
    {
        return this.ProcessRequest( true, path, pars );
    }

    [HttpPost()]
    public Dictionary<string, object> PostRequest( string path, string pars )
    {
        return this.ProcessRequest( false, path, pars );

    }


    private Dictionary<string, object> ProcessRequest( bool timeup, string path, string pars )
    {
        long started = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        Dictionary<string, object> response = new Dictionary<string, object>();
        try
        {
            if( path == null )
            {
                throw new Exception("Parameter 'path' not defined");
            }
            object api = null;// this.GetApi( timeup );
            lock ( api )
            {
                Dictionary<string, Object> prototype = Find(api, path);
                response["response"] = Invoke((MethodInfo)prototype["method"], prototype["target"], JsonConvert.DeserializeObject<JObject>(pars));
                response["status"] = "success";
            }


        }
        catch ( Exception ex )
        {
            Response.StatusCode = 500;
            response["status"] = "failed";
            response["params"] = new { path = path, pars = pars };
            response["token"] = Request.Headers["token"];
            if ( ex.InnerException != null )
            {
                response["text"] = ex.InnerException.Message + " => " + ex.Message;
            }
            else
            {
                response["text"] = ex.Message;
            }
        }
        finally
        {
            try
            {
                long ms = DateTimeOffset.Now.ToUnixTimeMilliseconds() - started;
                AddDiagnosticReport( "http", path, pars, response["status"], ms );
            }
            catch ( Exception e )
            {
                Debug.WriteLine( e );
            }


        }

        return response;
    }

    private void AddDiagnosticReport(string v1, string path, string pars, object v2, long ms)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    private object Invoke(MethodInfo methodInfo, object v, JObject jObject)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    private Dictionary<string, object> Find(object api, string path)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    [HttpOptions()]
    public object OptionsRequest(  )
    {
        return null;// this.GetResourceMap();
    }
    /*
    private object GetResourceMap( )
    {
        var session = GetSession( Request, true );
        if ( session == null )
        {
            return GetRestfullMetadata();
        }
        else
        {
            return session.GetSkeleton(null,new List<string>());
        }
    }
    */
    private object GetRestfullMetadata()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    /*
    private object GetApi( bool timeup )
    {
        HttpSessionContext session = GetSession( Request, timeup );
        if ( session != null )
        {
            return session.GetApi();
        }
        else
        {
            return GetRestfullModel();
        }
    }
    */
    private object GetRestfullModel()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }








    /// <summary>
    /// ///////////////////////////////////
    /// </summary>
    public byte[] GetRequestBody( )
    {
        long? size = this.HttpContext.Request.ContentLength;
        if ( size == 0 || size == null )
        {
            return new byte[0];
        }
        byte[] data = new byte[( long ) size];
        this.HttpContext.Request.Body.Read( data, 0, ( int ) size );
        return data;
    }
    ///
    public void BeforeProcessRequest( )
    {
         
        Debug.WriteLine(
        JObject.FromObject( new
        {
            headers = Request.Headers,
            query = Request.QueryString,
            url = Request.Path
        } ) );
            
    }
    public void AfterProcessRequest( )
    {
           
        Debug.WriteLine(
        JObject.FromObject( new
        {
            headers = Response.Headers,
            status = Response.StatusCode
        } ) );
           
    }
}
 