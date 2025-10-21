using Authentication.Contracts;

namespace Authentication.Interfaces.Auth
{
    public interface IIdentityService
    {
        JwtTokenResponse? Login(string login, string password);
    }
}
