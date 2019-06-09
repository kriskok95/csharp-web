
using Panda.Models;

namespace Panda.Services
{
    public interface IUserService
    {
        void CreateUser(User user);

        User GetUserByUsernameAndPassword(string username, string password);
    }
}
