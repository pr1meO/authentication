using Authentication.Interfaces;
using Authentication.Interfaces.Repositories;
using Authentication.Models;

namespace Authentication.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User? GetByLogin(string login) => _usersRepository.FindByLogin(login);
    }
}
