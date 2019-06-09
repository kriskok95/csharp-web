using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Panda.Models.Enums;

namespace Panda.Models
{
    public class User
    {
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Package> Packages { get; set; } = new List<Package>();

        public ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    }
}
