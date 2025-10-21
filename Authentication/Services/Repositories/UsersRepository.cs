using Authentication.Interfaces.Repositories;
using Authentication.Models;
using Authentication.Options;
using Microsoft.Extensions.Options;

namespace Authentication.Services.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDataOptions _data;

        public UsersRepository(IOptions<AppDataOptions> options)
        {
            _data = options.Value;
        }

        public User? FindByLogin(string login)
        {
            return _data.Users.FirstOrDefault(u => u.Login == login);
        }
    }
}
