using ApplicationDb.Entities;


using Microsoft.Extensions.Logging;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

 
public class AuthorizationClient: AppRootTransportSignalrClient   
{
    private readonly Service _service;
    private readonly AuthorizationOptions _options;

    public AuthorizationClient( AuthorizationOptions options, Service service )
    {
        _service = service;
        _options = options;
    }

    public override async Task Request(string Action, Dictionary<string, object> Message, Action<object> Handle)
    {
        //if(this.IsSignin() == false)
        //{
        //    await this.Signin(_service.ServiceCertificate.PublicKey);
        //}
        await base.Request(Action, Message, Handle);
    }

    public async Task Signin(byte[] publicKey)
    {
        await base.Request("Signin", new Dictionary<string, object>()
        {
            { "publicKey", publicKey }
        }, (resp) =>
        {
            this.Info(resp);
        });
        await Task.CompletedTask;
    }

    public void Signout(bool? IsFront = false)
    {
        this.Request(               
            "Signout",
            new Dictionary<string, object>()
            {
                {"IsFront",IsFront }
            },             
            (response)=> { }
        ).Wait();
    }
     

    public async Task<UserApi> Signin(ServiceCertificate cert)
    {
        if (cert == null)
            throw new ArgumentNullException("cert");
        await this.Signin(cert.PublicKey);
        return new UserApi();
    }

    

    public UserApi Signin(string Email, string Password, bool? IsFront = false)
    {
            
        this.Request(
            "Signin",
            new Dictionary<string, object>()
            {
                {"Email",Email },
                {"Password",Password },
                {"IsFront",IsFront }
            },
            (response) => {
                Api.Utils.Info(response);
            }
        ).Wait(); 

        return null;
    }

   

    public bool IsSignin()
    {
        bool result = false;
        bool ready = false;
        this.Request(
            "IsSignin",
            new Dictionary<string, object>()
            {
                   
            },
            (response) => {
                Debug.WriteLine(response);
            }
        ).Wait(); 

        while (true)
        {
            Thread.Sleep(100);
            if (ready)
            {
                break;
            }
        }
        return result;
    }


     

         
}
 