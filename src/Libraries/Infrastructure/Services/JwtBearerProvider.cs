using ContractorDocuments.Application.Common.Interfaces;
using ContractorDocuments.Application.Common.Models;
using ContractorDocuments.Application.Common.Models.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ContractorDocuments.Infrastructure.Services
{
    public class JwtBearerProvider : IJwtBearerProvider
    {
        #region Field & Ctor

        private readonly ILogger<JwtBearerProvider> _logger;
        private readonly JwtSettingModel _identitySetting;

        public JwtBearerProvider(ILogger<JwtBearerProvider> logger, IOptions<JwtSettingModel> identitySetting)
        {
            _logger = logger;
            _identitySetting = identitySetting.Value;
        }

        #endregion

        #region Methods

        public async Task<string> GenerateTokenAsync(List<Claim> claims, DateTime? expiresAt,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await Task.FromResult(GenerateToken(claims, expiresAt));
        }

        public async Task<(IEnumerable<Claim>? claims, AccessTokenStatus status)> DecryptAsync(string token,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_identitySetting.SecretKey);
                //var encryptionkey = Encoding.UTF8.GetBytes(appSettings.EncryptionKey);

                return await Task.Run(() =>
                {
                    var claimsPrincipal = handler.ValidateToken(
                        token,
                        GetTokenValidationParameters(),
                        out SecurityToken securityToken);
                    return (claimsPrincipal.Claims, AccessTokenStatus.Succeeded);
                });
            }
            catch (SecurityTokenExpiredException)
            {
                // Token was expired.
                return (null, AccessTokenStatus.Expired);
            }
            catch (Exception)
            {
                // Another errors.
                return (null, AccessTokenStatus.Conflict);
            }
        }

        #endregion

        #region Utils

        private TokenValidationParameters GetTokenValidationParameters()
        {
            var parameters = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,
                RequireSignedTokens = true,
                ValidateIssuerSigningKey = true,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ValidateIssuer = false,
                ValidateAudience = false
            };

            if (!string.IsNullOrEmpty(_identitySetting.SecretKey))
                parameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_identitySetting.SecretKey));

            if (!string.IsNullOrEmpty(_identitySetting.EncryptKey))
                parameters.TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_identitySetting.EncryptKey));

            return parameters;
        }
        private string GenerateToken(IEnumerable<Claim> claims, DateTime? expiresAt = null)
        {
            var secretKey = Encoding.UTF8.GetBytes(_identitySetting.SecretKey); // it must be atleast 16 characters or more
            var signinCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _identitySetting.Issuer,
                Audience = _identitySetting.Audience,
                IssuedAt = DateTime.Now.ToUniversalTime(),
                NotBefore = DateTime.Now.ToUniversalTime(),
                SigningCredentials = signinCredentials,
                Subject = new ClaimsIdentity(claims)
            };

            #region Token expiration
            if (expiresAt.HasValue)
            {
                descriptor.Expires = expiresAt.Value.ToUniversalTime();
            }
            #endregion

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(securityToken);
        }

        #endregion
    }
}