using BuildingMaterialAccounting.Application.Customers;
using BuildingMaterialAccounting.Core;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingMaterialAccounting.Application
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