using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReCaptcha
{

    /// <summary>
    /// Расширение для регистрации сервисов ReCaptcha
    /// </summary>
    public static class ReCaptchaExtensions
    {

        /// <summary>
        /// Расширение для регистрации сервисов ReCaptcha
        /// </summary>
        public static IServiceCollection AddRecaptcha(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configurationRoot=null)
        {
            services.AddSingleton<ReCaptchaOptions>();
            services.AddScoped<ReCaptchaService>();
            return services;
        }
    }
}
