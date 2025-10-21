using Authentication.Contracts;
using Authentication.Models;

namespace Authentication.Interfaces.Auth
{
    public interface ITokenService
    {
        JwtTokenResponse Generate(User user);
    }
}
