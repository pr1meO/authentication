using Microsoft.IdentityModel.Tokens;

namespace Authentication.Interfaces.Auth
{
    public interface ISigningService
    {
        SigningCredentials Create(string key);
    }
}
