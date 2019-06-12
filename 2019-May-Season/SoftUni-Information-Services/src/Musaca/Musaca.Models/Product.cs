using System.Collections.Generic;

namespace Musaca.Models
{
    public class Product
    {
        public Product()
        {
            this.OrderProducts = new List<OrderProducts>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<OrderProducts> OrderProducts{ get; set; }
    }
}
