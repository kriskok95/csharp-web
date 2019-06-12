namespace Musaca.Models
{
    public class OrderProducts
    {
        public string ProductId { get; set; }

        public Product Product { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }
    }
}
