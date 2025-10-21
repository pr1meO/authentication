using Authentication.Interfaces.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Authentication.Services.Auth
{
    public class SigningService : ISigningService
    {
        public SigningCredentials Create(string key) =>
            new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256
            );
    }
}