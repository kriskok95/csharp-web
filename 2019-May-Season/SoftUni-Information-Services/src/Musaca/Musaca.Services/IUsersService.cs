using Musaca.Models;

namespace Musaca.Services
{
    public interface IUsersService
    {
        string RegisterUser(string username, string password, string email);

        User GetUserFromDb(string username, string password);
        User GetUserById(string userId);
    }
}
