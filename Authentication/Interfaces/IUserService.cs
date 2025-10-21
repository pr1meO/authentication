using Authentication.Models;

namespace Authentication.Interfaces
{
    public interface IUserService
    {
        public User? GetByLogin(string login);
    }
}
