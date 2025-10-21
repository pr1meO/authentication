using Authentication.Models;

namespace Authentication.Options
{
    public class AppDataOptions
    {
        public IEnumerable<User> Users { get; set; } = [];
    }
}