using System.Security.Claims;

namespace ContractorDocuments.Application.Common.Interfaces
{
    public interface IJwtBearerProvider
    {
        Task<string> GenerateTokenAsync(List<Claim> claims,
            DateTime? expiresAt,
            CancellationToken cancellationToken = default);

        Task<(IEnumerable<Claim> claims, AccessTokenStatus status)> DecryptAsync(string token,
            CancellationToken cancellationToken = default);

    }
}