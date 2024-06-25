using System.Security.Claims;

namespace ContractorDocuments.Framework.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetDisplayName(this ClaimsPrincipal claimsPrincipal)
        {
            try
            {
                if (claimsPrincipal.Identity == null)
                    return "";

                var fullname = GetClaimValue(claimsPrincipal.Claims, "Fullname");
                if (!string.IsNullOrEmpty(fullname))
                    return fullname;

                var username = GetClaimValue(claimsPrincipal.Claims, ClaimTypes.Name);
                return username;
            }
            catch
            {
                return "";
            }
        }

        private static string GetClaimValue(IEnumerable<Claim> claims, string claimType)
        {
            var claim = claims.FirstOrDefault(c => c.Type == claimType);
            if (claim == null)
                return string.Empty;
            return claim.Value;
        }
    }
}