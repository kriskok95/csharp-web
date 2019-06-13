using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musaca.Models
{
    public class Product
    {
        public Product()
        {
            this.OrderProducts = new List<OrderProducts>();
        }

        public string Id { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public ICollection<OrderProducts> OrderProducts{ get; set; }
    }
}
