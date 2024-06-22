using BuildingMaterialAccounting.Application.Customers;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingMaterialAccounting.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection services)
        {
            #region Customers

            services
                .AddScoped<UserService>()
                .AddScoped<UserReport>()
                ;

            #endregion

            return services;
        }
    }
}