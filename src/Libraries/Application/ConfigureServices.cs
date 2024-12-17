using ContractorDocuments.Application.Common;
using ContractorDocuments.Application.ConstructStages;
using ContractorDocuments.Application.Equipments;
using ContractorDocuments.Application.Materials;
using ContractorDocuments.Application.Measures;
using ContractorDocuments.Application.Projects;
using ContractorDocuments.Application.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ContractorDocuments.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
                //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
                //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
                //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            });

            #region Customers

            services
                .AddScoped<UserService>()
                .AddScoped<UserReport>()
                .AddScoped<UserModelFactory>()
                .AddScoped<UserAuthenticationService>()
                ;

            #endregion

            #region Services

            services
                .AddScoped<DataSeedService>()
                // Projects
                .AddScoped<ProjectService>()
                .AddScoped<ProjectReportService>()
                // Construct Stages
                .AddScoped<ConstructStageService>()
                .AddScoped<ConstructStageReportService>()
                // Materials
                .AddScoped<MaterialService>()
                .AddScoped<MaterialReportService>()
                // Equipments
                .AddScoped<EquipmentService>()
                .AddScoped<EquipmentReportService>()
                // Directory
                .AddScoped<MeasureService>()
                .AddScoped<MeasureReportService>()
                ;

            #endregion

            return services;
        }
    }
}