using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musaca.Models
{
    public class User
    {
        public User()
        {
            this.Orders = new List<Order>();
        }

        public string Id { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
