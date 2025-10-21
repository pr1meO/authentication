using Authentication.Interfaces;
using Authentication.Interfaces.Auth;
using Authentication.Interfaces.Repositories;
using Authentication.Services;
using Authentication.Services.Auth;
using Authentication.Services.Repositories;

namespace Authentication.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserServices(
            this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ISigningService, SigningService>();
            services.AddScoped<IClaimProvider, ClaimProvider>();
            services.AddScoped<ITokenFactory, TokenFactory>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
