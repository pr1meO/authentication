using Authentication.Contracts;
using Authentication.Interfaces;
using Authentication.Interfaces.Auth;

namespace Authentication.Services.Auth
{
    public class IdentityService : IIdentityService
    {
        private readonly ILogger<IdentityService> _logger;
        private readonly IUserService _userService;
        private readonly IPasswordHasher _hasher;
        private readonly ITokenService _tokenService;

        public IdentityService(
            ILogger<IdentityService> logger,
            IUserService userService, 
            IPasswordHasher hasher,
            ITokenService tokenService
        )
        {
            _logger = logger;
            _userService = userService;
            _hasher = hasher;
            _tokenService = tokenService;
        }

        public JwtTokenResponse? Login(string login, string password)
        {
            var user = _userService.GetByLogin(login);

            if (user == null)
            {
                _logger.LogWarning("Login failed for {Login}: user not found.", login);
                return null;
            }

            var result = _hasher.Verify(password, user.PasswordHash);

            if (!result)
            {
                _logger.LogWarning("Login failed for {Login}: invalid credentials.", login);
                return null;
            }

            return _tokenService.Generate(user);
        }
    }
}