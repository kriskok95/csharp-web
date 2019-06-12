using System.Collections.Generic;

namespace Musaca.Models
{
    public class User
    {
        public User()
        {
            this.Orders = new List<Order>();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
