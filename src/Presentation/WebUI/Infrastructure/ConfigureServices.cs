using WebUI.Areas.Admin.Factories;

namespace WebUI.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDependencyServices(this IServiceCollection services)
        {
            services.AddLogicServices();

            #region Admin

            services
                .AddScoped<UserModelFactory>()
                ;

            #endregion

            return services;
        }
    }
}