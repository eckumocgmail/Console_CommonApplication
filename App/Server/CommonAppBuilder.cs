using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Hosting;
using System.Reflection;

/// <summary>
/// Объект инкапсулирующий логику регистрации сервисов в контейнере
/// </summary>
public class CommonAppBuilder 
{
    private IServiceCollection services;
    public CommonAppBuilder(IServiceCollection services)
    {
        this.services = services;
    }

   
    /// <summary>
    /// Регистрация истоника данных EF
    /// </summary>
    /// <param name="dbContext"></param>
    public void AddDbContextType( Type dbContext )
    {
        if (this.Contains(dbContext))
        {
            throw new Exception($"Тип {dbContext.GetNameOfType()} уже зарегистрирован");
        }
        else
        {
            services.AddScoped(dbContext, sp => 
                dbContext.New()
            );
            services.AddScoped(dbContext, sp => 
                dbContext.New()
            );
        }
    }


    


    public bool Contains<InterfaceType>() => this.Contains(typeof(InterfaceType));
    public bool Contains(Type target)   
        => services.Any(desc => desc.ServiceType == target);

    public void AddHostedService<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THostedService>( ) where THostedService : class, IHostedService
    {
        services.AddHostedService<THostedService>();
    }

    public HashSet<Type> GetTransientServices<TInterface>() => GetServices<TInterface>(ServiceLifetime.Transient);
    public HashSet<Type> GetScopedServices<TInterface>() => GetServices<TInterface>(ServiceLifetime.Scoped);
    public HashSet<Type> GetSingletonServices<TInterface>() => GetServices<TInterface>(ServiceLifetime.Singleton);
    public HashSet<Type> GetServices<TInterface>(ServiceLifetime Scope) => GetServices(typeof(TInterface));
    public HashSet<Type> GetServices(Type api, ServiceLifetime Scope)
    => services
        .Where(desc =>
            desc.Lifetime == Scope &&
            desc.ServiceType.IsAbstract == false &&
            desc.ServiceType.IsImplementsFrom(api) ||
            desc.ServiceType.IsExtendsFrom(api))
        .Select(desc => desc.ServiceType).ToHashSet();


    public HashSet<Type> GetServices<TInterface>() => GetServices(typeof(TInterface));
    public HashSet<Type> GetServices(Type api)
    => services
        .Where(desc =>
            desc.ServiceType.IsAbstract == false &&
            desc.ServiceType.IsImplementsFrom(api) ||
            desc.ServiceType.IsExtendsFrom(api))
        .Select(desc => desc.ServiceType).ToHashSet();



    public IEnumerable<Type> GetSingletonServiceTypes()    
        => this.services.Where(desc => desc.Lifetime == ServiceLifetime.Singleton)
            .Select(d => d.ServiceType);
    

    public IEnumerable<Type> GetTransientServiceTypes()    
        => this.services.Where(desc => desc.Lifetime == ServiceLifetime.Transient)
            .Select(d => d.ServiceType);
    

    public IEnumerable<Type> GetScopedServiceTypes()     
        => this.services.Where(desc => desc.Lifetime == ServiceLifetime.Scoped)
            .Select(d => d.ServiceType);


    /// <summary>
    /// Исключяение выбрасывается в случае некорректной конфигурации приложения
    /// </summary>
    [Serializable]
    public class InvalidConfigurationException : Exception
    {
       
        public InvalidConfigurationException(string message) : base(message)
        {
        }

       
    }

    public ServiceDescriptor AddSingletonConfiguration<T>( IConfiguration configuration )
    {
        this.services.AddSingleton(typeof(T), sp => {
            var section = configuration.GetSection(typeof(T).GetTypeName());
            T result = section.Get<T>();
            if (result == null)
                throw new InvalidConfigurationException(typeof(T).GetTypeName());
            return result;
        });
        return services.FirstOrDefault(desc => desc.ServiceType == typeof(T));
    }
    public ServiceDescriptor AddSingleton(Type type)
    {
        this.services.AddSingleton(type);
        return services.FirstOrDefault(desc => desc.ServiceType == type);
    }
    public ServiceDescriptor AddSingleton(Type type,Func<IServiceProvider, object> create)
    {
        this.services.AddSingleton(type,create);
        return this.services.FirstOrDefault(desc => desc.ServiceType == type);
    }
    public ServiceDescriptor AddSingleton<TType>() => AddSingleton(typeof(TType));
    public ServiceDescriptor AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>() where TService : class where TImplementation : class, TService  
    {
        services.AddSingleton<TService, TImplementation>();
        if(services.Count(desc => desc.ServiceType == typeof(TService)) > 1)
        {
            this.Info($"Кол-во {typeof(TService).GetTypeName()} более 1");
            return services.FirstOrDefault(desc => desc.ServiceType == typeof(TService));
        }
        else
        {
            return services.FirstOrDefault(desc => desc.ServiceType == typeof(TService));
        }
            
    }
    public ServiceDescriptor AddScopedService(Type type)
    {
        this.services.AddTransient(type);
        return services.FirstOrDefault(desc => desc.ServiceType == type);
    }
    public ServiceDescriptor AddScopedService<TType>() => AddScopedService(typeof(TType));
    public ServiceDescriptor AddTransientService(Type type)
    {
        this.services.AddTransient(type);
        return services.FirstOrDefault(desc => desc.ServiceType == type);
    }
    public ServiceDescriptor AddTransientService<TType>()
    {
        return this.AddTransientService(typeof(TType));
    }
    public ISet<ServiceDescriptor> AddSingletonGenericServices(Type ServiceType, Type ArgumentType)
    {
        var services = new HashSet<ServiceDescriptor>();
        foreach (var kv in GetGenericTypes(ServiceType, ArgumentType))
        {
            this.Info($"Зарегистрирован сервис уровня приложения {kv.Key}");
            var service = AddSingleton(kv.Value);
            services.Add(service);
        }
        return services;
    }
    public void AddTransientGenericServices(Type ServiceType, Type ArgumentType)
    {
        foreach (var kv in GetGenericTypes(ServiceType, ArgumentType))
        {
            this.Info($"Зарегистрирован сервис уровня приложения {kv.Key}");
            AddTransientService(kv.Value);
        }
    }
    public void AddScopedGenericServices(Type ServiceType, Type ArgumentType)
    {
        foreach (var kv in GetGenericTypes(ServiceType, ArgumentType))
        {
            this.Info($"Зарегистрирован сервис в изолированно {kv.Key}");
            AddScopedService(kv.Value);
        }
    }

    public List<object> GetArgumentsList(Func<string, object> getter, Func<Type, object> injector, string service, string action )
    {
        var argv = new List<object>();
        var method = service.ToType().GetMethods().FirstOrDefault(m => m.Name == action);
        foreach (ParameterInfo par in method.GetParameters())
        {
            if (AttrsUtils.IsParameterInjectable(service, action, par.Name))
            {
                try
                {
                    argv.Add(injector(par.ParameterType));
                }
                catch (Exception ex)
                {
                    throw new Exception($"Не удалось собрать аргументы для {service} " +
                        $"выполнения операции {action} . " +
                        $"В пространстве имён отсутсвиет тип {par.ParameterType.GetNameOfType()} либо он не зарегистрированв ServiceProvider", ex); ;
                }
            }
            else
            {
                argv.Add(getter(par.Name));

            }
        }

        return argv;
    }

    /// <summary>
    /// Формирует все возможные типы реалзации
    /// </summary>
    public IDictionary<string, Type> GetGenericTypes(Type ParametrizedType, params Type[] ParameterImplementations)
    {
        this.Info(new
        {
            ParametrizedType = ParametrizedType.GetNameOfType(),
            ParameterImplementations = ParameterImplementations.Select(param => param.GetNameOfType())
        });
        var result = new SortedDictionary<string, Type>();        
        try
        {
            
            var cube = new List<HashSet<Type>>();
            foreach (var impl in ParameterImplementations)
            {
                HashSet<Type> services = GetServices(impl);
          
                this.Info(GetServicesNames(impl));
                cube.Add(services);
            }
            this.Info(new
            {
                ParametrizedType = ParametrizedType.GetNameOfType(),
                ParameterImplementations = ParameterImplementations.Select(param => param.GetNameOfType()),
                ServicesImapleted = cube.Select(dim=>dim.Select(t=>t.GetNameOfType()))
            });
            // индекс в списке = номеру параметра
            List<Type[]>[] paramsDim = new List<Type[]>[cube.Count()];

            Func<Type[]> CreateGenericArgumentsImpl = () => new Type[ParametrizedType.GetGenericArguments().Length];

            var enumerators = cube.Select(set => set.GetEnumerator()).ToList();
            for (int i = 0; i < enumerators.Count(); i++)
            {
                enumerators[i].MoveNext();
            }
            for (int i = 0; i < enumerators.Count(); i++)
            {
                System.Collections.Generic.List<Type> parameters = new System.Collections.Generic.List<Type>();
                do
                {

                    foreach (var en in enumerators)
                    {
                        parameters.Add(en.Current);
                    }
                }
                while (enumerators[i].MoveNext());
                foreach (var p in parameters)
                {
                    if (p == null)
                        "null".WriteToConsole();
                    else p.GetNameOfType().WriteToConsole();
                }

                Type generic = ParametrizedType.MakeGenericType(parameters.ToArray());
                result[generic.GetNameOfType()] = generic;
                result.Keys.ToJsonOnScreen().WriteToConsole();
                parameters.Clear();
                enumerators[i] = cube[i].GetEnumerator();
            }
        }catch (Exception ex)
        {
            ex.ToString().WriteToConsole();
        }
     

        
        return result;
    }

    private IEnumerable<string> GetServicesNames(Type impl)
    {
        var result = new List<string>();
        foreach(var desc in services)
        {
            if(desc != null && desc.ServiceType != null)
            {
                result.Add(desc.ServiceType.GetNameOfType());
            }
        }
        return result;
    }


    /// <summary>
    /// Возвращает все сервисы реализующие заданный интерфейс
    /// </summary>
    public IEnumerable<Type> GetImplementations<TServiceImplementation>()
    {
        return services
            .Where(description =>
                description.ServiceType!=null && 
                description.ServiceType.IsImplementsFrom(typeof(TServiceImplementation)))
            .Select(desc => desc.ServiceType);
    }


    
    
    public string ActionEvent(string message)
    {
        MethodResult<object> methodResult = null;
        try
        {
            this.Info("Переход к шагу проверка входящего сообщения");
            if (String.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException("message");
            var context = new ActionInvokeContext();

            this.Info("Переход к шагу десериализации сообщения");
            RequestMessage request = null;
            try
            {
                request = message.FromJson<RequestMessage>();
            }
            catch (Exception ex)
            {
                throw new Exception("Исключение на этапе десериализации", ex);
            }
            request.EnsureIsValide();

            this.Info("Переход к шагу рефлексивного вызова");
            try
            {
                this.GetServiceByName(request.ServiceName);
                object result = context.Invoke(request.ActionName, request.GetArguments());
                methodResult = MethodResult<object>.OnResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Исключение на этапе рефлексивноо вызова", ex);
            }
        }
        catch (Exception ex)
        {
            methodResult = MethodResult<object>.OnError(ex);
        }
        finally
        {
            this.Info();
        }
        return methodResult.ToJsonOnScreen();
    }

    public object GetServiceByName(string serviceName)
    {
        Type serviceType = serviceName.ToType();
        return this.GetServices(serviceType);
    }

    
}



public class AppServiceBuilderTest: TestingElement
{
    public override List<string> OnTest()
    {
        
        return Messages;
    }
}

