﻿using BuildingMaterialAccounting.Application.Customers;
using BuildingMaterialAccounting.Application.Projects;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingMaterialAccounting.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
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
                .AddScoped<UserAuthenticationService>()
                ;

            #endregion

            #region Projects

            services
                .AddScoped<ProjectService>()
                ;

            #endregion

            return services;
        }
    }
}