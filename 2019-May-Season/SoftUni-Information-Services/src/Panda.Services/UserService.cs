namespace Panda.Services
{
    using System.Linq;
    using Data;
    using Models;
    public class UserService : IUserService
    {
        private readonly PandaDbContext dbContext;

        public UserService(PandaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateUser(User user)
        {
            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.dbContext.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
