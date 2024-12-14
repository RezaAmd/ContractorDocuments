namespace ContractorDocuments.WebUI.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDependencyServices(this IServiceCollection services)
        {
            services.AddApplicationServices();

            return services;
        }
    }
}