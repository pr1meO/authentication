using System.Security.Claims;

namespace Authentication.Interfaces.Auth
{
    public interface IClaimProvider
    {
        IEnumerable<Claim> GetAccessClaims(Guid userId);
    }
}
