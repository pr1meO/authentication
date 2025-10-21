using Authentication.Models;

namespace Authentication.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        User? FindByLogin(string login);
    }
}
