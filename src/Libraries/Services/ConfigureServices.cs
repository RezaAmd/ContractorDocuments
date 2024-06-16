using BuildingMaterialAccounting.Services.Customers;
using Core;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingMaterialAccounting.Services
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection services)
        {
            services.AddCoreServices();

            #region Customers

            services
                .AddScoped<UserService>()
                ;

            #endregion

            return services;
        }
    }
}