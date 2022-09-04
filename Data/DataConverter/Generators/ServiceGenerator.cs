using DataConverter.Generators;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

public class ServiceGenerator : ControllerGenerator
{
    public ServiceGenerator(IServiceProvider models) : base(models)
    {


    }

    public Dictionary<string, string> Generate(IServiceCollection services)
    {
        Dictionary<string, string> scripts = new Dictionary<string, string>();

        try
        {
            var converter = new MyApplicationModelController(_provider);
            foreach (var service in services)
            {

                Type type = null;
                try
                {
                    type = ReflectionService.TypeForName(service.ServiceType.Name);
                }
                catch (Exception ex)
                {
                    Api.Utils.Info(ex);
                    continue;
                }
                if (type != null)
                {
                    if (type.Assembly.GetName() == Assembly.GetExecutingAssembly().GetName())
                    {
                        var model = MyApplicationModelController.CreateModel(type);
                        string script = AngularJsService(model);
                        scripts[type.Name] = script;
                    }
                }

            }
        }
        catch (Exception ex)
        {
            throw new Exception("Исключение при генерации сервисов клиента ", ex);
        }
        return scripts;
    }
}
 