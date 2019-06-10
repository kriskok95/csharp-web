namespace Panda.Services
{
    using Models;

    public interface IUserService
    {
        void CreateUser(User user);

        User GetUserByUsernameAndPassword(string username, string password);
    }
}
