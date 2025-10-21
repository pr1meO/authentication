using Authentication.Models;

namespace Authentication.Interfaces.Auth
{
    public interface ITokenFactory
    {
        string Create(Guid userId);
    }
}
