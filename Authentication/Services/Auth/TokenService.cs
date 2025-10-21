using Authentication.Contracts;
using Authentication.Interfaces.Auth;
using Authentication.Models;

namespace Authentication.Services.Auth
{
    public class TokenService : ITokenService
    {
        private readonly ITokenFactory _tokenFactory;

        public TokenService(ITokenFactory tokenFactory)
        {
            _tokenFactory = tokenFactory;
        }

        public JwtTokenResponse Generate(User user) =>
            new JwtTokenResponse()
            {
                Access = _tokenFactory.Create(user.Id)
            };
    }
}
