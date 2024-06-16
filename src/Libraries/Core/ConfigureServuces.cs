using Core.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class ConfigureServuces
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(Repository<>), typeof(Repository<>))
                ;
            return services;
        }
    }
}