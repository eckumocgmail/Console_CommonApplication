
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public static class ViewServicesExtensions
{

    public static IServiceCollection ConfigureViewServices(this IServiceCollection services, IConfiguration configuration)
    {
        Api.Utils.Info("Регистрация служб общего доступа ");
        services.AddSignalR();
        services.AddCommonViewMVC();
        services.AddTreeViewMVC();
        services.AddFormViewMVC();
        services.AddListViewMVC();
        return services;
    }

    private static IServiceCollection AddCommonViewMVC(this IServiceCollection services)
    {
        Api.Utils.Info("Регистрация общих сервисов компонентов представлений AddCommonViewMVC");
        services.AddScoped<CssSerializer>();
        return services;
    }


    private static IServiceCollection AddListViewMVC(this IServiceCollection services)
    {
        Api.Utils.Info("Регистрация компонента представления AddListViewMVC");
        services.AddScoped<ListService>();
        return services;
    }



    private static IServiceCollection AddFormViewMVC(this IServiceCollection services)
    {
        Api.Utils.Info("Регистрация компонента представления AddFormViewMVC");
        return services;
    }

    private static IServiceCollection AddTreeViewMVC(this IServiceCollection services)
    {
        Api.Utils.Info("Регистрация компонента представления AddTreeViewMVC");
        services.AddScoped<TreeViewService>();
        return services;
    }

}