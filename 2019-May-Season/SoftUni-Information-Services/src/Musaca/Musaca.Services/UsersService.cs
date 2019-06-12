using Musaca.Data;
using Musaca.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Musaca.Services
{
    public class UsersService : IUsersService
    {
        private readonly MusacaDbContext context;

        public UsersService(MusacaDbContext context)
        {
            this.context = context;
        }

        public User GetUserFromDb(string username, string password)
        {
            string hashedPassword = this.HashPassword(password);

            User user = context.Users.FirstOrDefault(x => x.Username == username && x.Password == hashedPassword);
            return user;
        }

        public User GetUserById(string userId)
        {
            User user = context.Users.Find(userId);

            return user;
        }

        public string RegisterUser(string username, string password, string email)
        {
            User user = new User
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password)
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();

            return user.Id;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

    }
}
