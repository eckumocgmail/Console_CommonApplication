using System;
using System.Collections.Concurrent;
/// <summary>
/// Контейнер объектов типа IServiceProvider.
/// Метод GetService( ... ) вернёт первый результат
/// отличный от null, полученный в ходе последовательного
/// исп. метода GetService( ... ) поставщиков исп.
/// порядок их регистрации.
/// </summary>
public class CoalesceProvider: IServiceProvider
{
    private ConcurrentBag<IServiceProvider>_providers = 
        new ConcurrentBag<IServiceProvider>();
    
    /// <summary>
    /// Регистрация поставщика слжубных типов
    /// </summary>
    public int AddServiceProvider<TServiceProvider>()
        where TServiceProvider : IServiceProvider
    {
        this.Info($"Регистрация поставщика служб: {typeof(TServiceProvider).GetTypeName()} c " +
            $"приоритетом {this._providers.Count}");
        try
        {
            var instance = (IServiceProvider)typeof(TServiceProvider).New();
            this._providers.Add(instance);
            
        }
        catch (Exception ex)
        {
            throw new Exception($"Не удалось создать экземпляр " +
                $"поставщика служебных типов {typeof(TServiceProvider).GetTypeName()}",ex);
        }
        return this._providers.Count;
    }

    /// <summary>
    /// Регистрация поставщика слжубных типов
    /// </summary>
    public int AddServiceProvider(IServiceProvider instance)     
    {
        if(instance == null)
            throw new ArgumentNullException(nameof(instance));
        this.Info($"Регистрация поставщика служб: {instance.GetTypeName()} c " +
            $"приоритетом {this._providers.Count}");
        return this._providers.Count;
    }

    /// <summary>
    /// Получение ссылки исп. систему внедрения зависимостей
    /// </summary>
    public object GetService(Type serviceType)
    {
        object result = null;
        try
        {
            
            foreach (IServiceProvider serviceProvider in _providers)
            {
                try
                {
                    if ((result = serviceProvider.GetService(serviceType)) != null)
                        return result;
                }
                catch (Exception ex)
                {
                    this.Warn(ex);
                    continue;
                }
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"При получении зависимости {serviceType.GetTypeName()}", ex);
        }
    }
}

