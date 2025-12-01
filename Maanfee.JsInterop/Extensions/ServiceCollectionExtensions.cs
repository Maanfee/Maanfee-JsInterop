using Microsoft.Extensions.DependencyInjection;

namespace Maanfee.JsInterop
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMaanfeeJsInterop(this IServiceCollection services)
        {
            services.AddTransient<Dom>();
            services.AddTransient<LocalStorage>();
            services.AddTransient<Fullscreen>();

            return services;
        }
    }
}
