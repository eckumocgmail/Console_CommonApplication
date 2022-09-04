using Microsoft.Extensions.Hosting;
using static Api.Utils;
using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Collections.Concurrent;
using System.Collections;


/// <summary>
/// Объект сохраняемый в памяти
/// </summary>
public interface IStatefull<TState>
{
    public void SaveState();
    public void LoadState();

    /// <summary>
    /// Восстановление состояния создаёт новый индекс в истории с даннами полученным из 
    /// заданногогиндекса
    /// </summary>    
    public void LoadState(int index);

    /// <summary>
    /// Чтение журнала
    /// </summary>
    public IDictionary<int, TState> GetHistory();
}


/// <summary>
/// 
/// </summary>
public interface IProcess: IStatefull<StatefullObject<byte[]>>
{
    public void GetProcessName();
    public void SetWaitingState();
    public void SetSuccessState();
    public void SetFailedState();
    public void SetProgressState();
}



public interface UserDialogAPI
{
    T SingleSelect<T>(IEnumerable<T> items);
    T SingleSelect<T>(IEnumerable<T> items, Func<T, string> namingFn);
}


public interface ProgramAPI
{

    public int Run(params string[] args);
}


public class AppMiddlewareContainer
{
    private ConcurrentQueue<Action<HttpContext>> TODO;

    public AppMiddlewareContainer()
    {
        TODO = new ConcurrentQueue<Action<HttpContext>>();
    }

    public void OnHttpRequest(HttpContext http)
    {
        foreach (var todo in TODO)
        {
            todo(http);
        }
    }
}

public class AppMiddlewareComponent
{
    private readonly RequestDelegate _next;
    public AppMiddlewareComponent(RequestDelegate next)
    {
        _next = next;
        this.Info("Новый экземпляр");
    }

    public async Task Invoke(HttpContext http, IBusinessApplicationDesigner provider)
    {
        try
        {
            provider.GetService<AppMiddlewareContainer>().OnHttpRequest(http);
            await _next.Invoke(http);
        }
        catch (Exception ex)
        {
            provider.GetService<EventHandler<ExceptionEvent>>().Invoke(this, new ExceptionEvent(ex));
            await Task.CompletedTask;
        }
    }
}
