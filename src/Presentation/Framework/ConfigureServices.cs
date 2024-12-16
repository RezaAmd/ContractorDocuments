using ContractorDocuments.Application.Common.Models;
using ContractorDocuments.Application.Common.Models.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ContractorDocuments.Framework
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            #region JWT settings

            // Prepare identity setting from appsetting.json
            var jwtSettingSection = configuration
                .GetSection("JwtSettings");
            services.Configure<JwtSettingModel>(jwtSettingSection);
            var jwtSetting = jwtSettingSection
                .Get<JwtSettingModel>();

            if (jwtSetting == null)
                throw new ArgumentNullException("JWT setting cannot be null in appsetting.");
            if (string.IsNullOrEmpty(jwtSetting.SecretKey))
                throw new ArgumentNullException("Secret key cannot be null in Jwt setting.");

            #endregion

            #region Authentication settings

            var authenticationSettingSection = configuration
                .GetSection("AuthenticationSetting");
            services.Configure<AuthenticationSettingModel>(authenticationSettingSection);

            #endregion

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    RequireSignedTokens = true,
                    ValidateIssuerSigningKey = true,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecretKey)),
                    TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.EncryptKey))
                };
            });

            return services;
        }
    }
}