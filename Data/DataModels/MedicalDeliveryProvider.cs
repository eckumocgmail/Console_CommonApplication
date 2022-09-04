 
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MvcSessionApp
{

    public class MedicalDeliveryProvider: IServiceProvider
    {
        protected ConcurrentDictionary<Type, Func<IServiceProvider, object>> Factories =
            new ConcurrentDictionary<Type, Func<IServiceProvider, object>>();

        private Type[] serviceModuleTypes;
        
        public T Get<T>() where T : class
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().Where(t => t == typeof(T) || t.GetInterfaces().Contains(typeof(T))).FirstOrDefault();
            if (type != null)
            {
                var constructor = type.GetConstructors().FirstOrDefault();
                var newInstance = constructor.Invoke(constructor.GetParameters().ToList()
                        .Select(p => GetService(p.ParameterType)).ToArray());
                return (T)newInstance;
            }
            return null;
                
        }

        public MedicalDeliveryProvider() { }
        public void Add(IEnumerable<ServiceDescriptor> disc)  
        {

            disc.ToList().ForEach(d =>
            {
                Factories[d.ServiceType] = d.ImplementationFactory;
            });
        }


        

        public MedicalDeliveryProvider(Type[] serviceModuleTypes)
        {
            this.serviceModuleTypes = serviceModuleTypes;
        }

        public virtual bool HasService(Type type)=> Factories.ContainsKey(type);
        public MedicalDeliveryProvider AddProvider(IServiceProvider provider)
        {
            return this;
        }

        public virtual void AddServiceDescriptions(ServiceDescriptor[] descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                var serviceType = descriptor.ServiceType;
                this.Factories[descriptor.ServiceType] = (sp) => {
                    return sp.GetService(descriptor.ServiceType);
                };
            }
        }

        public virtual object GetService(Type serviceType)
            => Factories.ContainsKey(serviceType) ? Factories[serviceType].Invoke(this) : null;
    }
}