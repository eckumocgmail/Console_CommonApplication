using Microsoft.AspNetCore.Http;

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;


/// <summary>
/// 
/// </summary>
public interface IAppModelContext
{
    void OnDisconnectedAsync(string connectionId);
    void OnStepOverAsync(string connectionId);
    void OnConnectedAsync(string connectionId);
}


/// <summary>
/// 
/// </summary>
public class ModelContext: IAppModelContext
{
    protected APIServices _services;
    protected APIAuthorization _authorization;
    protected IHttpContextAccessor _accessor;

    public ModelContext( 
           APIAuthorization authorization, 
           APIServices services, 
           IHttpContextAccessor accessor)
    {
        _services = services;
        _authorization = authorization;
        _accessor = accessor;
    }


    /// <summary>
    /// 
    /// </summary>
    public void OnConnectedAsync(string signalrConnectionId)
    {
        this.Info($"OnDisconnectedAsync({signalrConnectionId})");

        _services.Connected(signalrConnectionId);
    }


    /// <summary>
    /// 
    /// </summary>
    public void OnDisconnectedAsync(string signalrConnectionId)
    {
        this.Info($"OnDisconnectedAsync({signalrConnectionId})");
        
        string httpRequestId = _accessor.HttpContext.TraceIdentifier;
        _services.Disconnected(
            signalrConnectionId 
        );
    }

    public void OnStepOverAsync(string connectionId)
    {
        throw new System.NotImplementedException();
    }
}