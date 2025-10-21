using Authentication.Interfaces.Auth;
using System.Security.Claims;

namespace Authentication.Services.Auth
{
    public class ClaimProvider : IClaimProvider
    {
        public IEnumerable<Claim> GetAccessClaims(Guid userId) =>
        [
            CreateUserIdClaim(userId)
        ];

        private Claim CreateUserIdClaim(Guid userId) =>
            new(ClaimTypes.NameIdentifier, userId.ToString());
    }
}
