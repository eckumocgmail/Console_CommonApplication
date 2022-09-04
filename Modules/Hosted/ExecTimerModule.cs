using Microsoft.Extensions.Hosting;

using System;
using System.Threading;
using System.Threading.Tasks;




/// <summary>
/// Модуль прекдоставляет функеционал выполнения периодически выполняемой операции в фоновом режиме.
/// </summary>
public abstract class ExecTimerModule: PropertyChangeSupport, IHostedService, IDisposable
{

    /// <summary>
    /// Интервал между операциями
    /// </summary>
    protected long Timeout { get => Get<long>("Timeout"); set => Set<long>("Timeout", value); }




    public async Task StartAsync(CancellationToken cancellationToken)
    {
        this.SetInterval(OnTimeUpdate, Timeout);
        await Task.CompletedTask;
    }

    protected abstract void OnTimeUpdate();

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    public void Dispose()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}