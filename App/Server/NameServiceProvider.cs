using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Collections;

/// <summary>
/// Предоставляет сервисы по имени типа
/// </summary>
public class NameServiceProvider: ActionService, IServiceProvider, IDisposable
{
    private static NameServiceProvider INSTANCE;


    protected ISet<string> _names;
    protected IServiceProvider _serviceProvider;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="names"></param>
    /// <returns></returns>
    public static NameServiceProvider Create(IServiceProvider serviceProvider, IEnumerable<string> names)
    {
        if(INSTANCE == null)
        {
            INSTANCE = new NameServiceProvider(serviceProvider, names);
        }
        return INSTANCE;
    }
 

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="names"></param>
    public NameServiceProvider( IServiceProvider serviceProvider=null, IEnumerable<string> names=null )
    { 
        _names = names==null? Assembly.GetExecutingAssembly().GetNames().ToHashSet(): names.ToHashSet();
        _serviceProvider = serviceProvider == null? new AppProviderService(): serviceProvider;        
    }

    /// <summary>
    /// Возвращает наименования типов зарегистрированных служб
    /// </summary>    
    public IEnumerable<string> GetServiceNames() => _names;


    /// <summary>
    /// Получение сервиса по имени типа
    /// </summary>   
    public object GetService(string name)
    {
        try
        {
            this.LogInformation($"GetService({name})");

            if (_serviceProvider == null)
                return null;
            if (_names.Contains(name) == false)
                throw new ArgumentException($"Аргумент задан некорректно: name={name}. Допустимые значения: {GetServiceNames().ToJson()}");
            var ptype = name.ToType();
            if (ptype == null)
                ptype = FactoryUtils.Get().TypeForName(name);
            if (ptype == null)
                ptype = FactoryUtils.Get().TypeForShortName(name);
            if (ptype == null)
                throw new Exception("Не найден тип с именем "+name);
            return _serviceProvider.GetService(ptype);
        }
        catch (Exception ex)
        {
            ex.ToString().WriteToConsole();
            return null;
        }
    }


    /// <summary>
    /// Регистрация пространства имён
    /// </summary>
    /// <param name="services"></param>
    public static void AddNamespace( IServiceCollection services )
    {       
        HashSet<string> names = services
            .Select(description => description.ServiceType.GetNameOfType())
            .Where(name=>FactoryUtils.Get().GetNames().Contains(name)).ToHashSet();
        services.AddSingleton(typeof(NameServiceProvider), sp => NameServiceProvider.Create(sp, names));
    }

    /// <summary>
    /// Получение кода конфигурации контейнера
    /// </summary>
    public static IEnumerable<string> GetCsConfigurationCode(IEnumerable<string> names) 
        => names.Select(name=>$"        services.AddScoped<ILogger<{name}>,ConsoleLogger<{name}>>();");

    /// <summary>
    /// Получение ссылки на сервис
    /// </summary>
    public object GetService(Type serviceType)
        => this._serviceProvider.GetService(serviceType);

    public void Dispose()
    {
        this.Info("Dispose");        
    }
}