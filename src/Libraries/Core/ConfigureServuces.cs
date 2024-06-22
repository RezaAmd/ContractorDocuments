using BuildingMaterialAccounting.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingMaterialAccounting.Infrastructure
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