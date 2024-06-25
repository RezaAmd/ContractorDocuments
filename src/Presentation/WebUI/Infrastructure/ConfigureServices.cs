using ContractorDocuments.WebUI.Areas.Admin.Factories;

namespace ContractorDocuments.WebUI.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDependencyServices(this IServiceCollection services)
        {
            services.AddApplicationServices();

            #region Admin

            services
                .AddScoped<UserModelFactory>()
                ;

            #endregion

            return services;
        }
    }
}