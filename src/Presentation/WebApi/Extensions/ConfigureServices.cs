using ContractorDocuments.Application;
using ContractorDocuments.Framework;
using ContractorDocuments.Infrastructure;
using Microsoft.OpenApi.Models;

namespace ContractorDocuments.WebApi.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDependencyServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Swagger services
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gateway", Version = "v1" });

                // Define the security scheme
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                // Add security requirement
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,

                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            // Register application layer services.
            services.AddApplicationServices();

            // Register infrastructure services.
            services.AddInfrastructureServices(configuration);

            // Add JWT authentication.
            services.AddJwtAuthentication(configuration);

            return services;
        }
    }
}