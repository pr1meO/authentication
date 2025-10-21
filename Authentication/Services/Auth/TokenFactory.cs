using Authentication.Interfaces.Auth;
using Authentication.Options;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace Authentication.Services.Auth
{
    public class TokenFactory : ITokenFactory
    {
        private readonly TokenOptions _options;
        private readonly IClaimProvider _claimProvider;
        private readonly ISigningService _signingService;

        public TokenFactory(
            IOptions<TokenOptions> options,
            IClaimProvider claimProvider,
            ISigningService signingService
        )
        {
            _options = options.Value;
            _claimProvider = claimProvider;
            _signingService = signingService;
        }

        public string Create(Guid userId)
        {
            var now = DateTime.UtcNow;
            var expires = now.AddHours(_options.AccessExpiresHours);

            var token = new JwtSecurityTokenHandler()
                .WriteToken(
                    new JwtSecurityToken(
                        issuer: _options.Issuer,
                        audience: _options.Audience,
                        notBefore: now,
                        expires: expires,
                        claims: _claimProvider.GetAccessClaims(userId),
                        signingCredentials: _signingService.Create(_options.Key)
                    )
                );

            return token;
        }
    }
}