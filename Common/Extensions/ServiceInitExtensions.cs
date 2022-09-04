using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class ServiceInitExtensions
{


    public static void Init(this object target, IServiceProvider provider)
    {
        try
        {
            target.InitProperties(provider);
            target.InitFields(provider);
        }
        catch (Exception ex)
        {
            throw new Exception("Исключение при инициаллизации сервисов ", ex);
        }
    }
    public static void InitFields(this object target, IServiceProvider provider)
    {
        foreach (FieldInfo field in target.GetType().GetFields())
        {

            Dictionary<string, string> attrs = Utils.ForField(target.GetType(), field.Name);
            bool has = Utils.HasAttribute<ServiceAttribute>(attrs);
            if (has)
            {
                try
                {
                    field.SetValue(target, provider.GetService(field.FieldType));
                    target.Info($"{field.Name} успешно инициаллизировано");
                }
                catch (Exception ex)
                {
                    target.Error($"{field.Name} не инициаллизировано");
                    target.Error(ex);
                }
            }
            else
            {
                //target.Info($"{field.Name} не требует инициаллизации");
            }
        }
    }
    public static void InitProperties(this object target, IServiceProvider provider)
    {

        Typing.ForEachType(target.GetType(), (next) =>
        {
            target.Info(new
            {
                Name = next.GetNameOfType().ToJsonOnScreen(),
                Properties = next.GetProperties().Select(p => p.Name).ToJsonOnScreen()
            });
            foreach (PropertyInfo property in next.GetProperties())
            {

                Dictionary<string, string> attrs = Utils.ForProperty(target.GetType(), property.Name);
                bool has = Utils.HasAttribute<ServiceAttribute>(attrs);
                if (has)
                {
                    try
                    {
                        var value = provider.GetRequiredService(property.PropertyType);
                        if (value == null)
                        {
                            throw new Exception($"Поставщик {provider.GetTypeName()} не предоставил сервис" +
                                $" типа {property.PropertyType.GetNameOfType()}");
                        }
                        property.SetValue(target, value);
                        target.Info($"{property.Name} успешно инициаллизировано");
                    }catch (Exception ex)
                    {
                        Api.Utils.Error(ex);
                        continue;
                    }
                     
                } 
            }
        });

    }
}
