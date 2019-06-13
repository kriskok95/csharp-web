using Musaca.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musaca.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderProducts = new List<OrderProducts>();
        }

        public string Id { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Active;

        public DateTime IssuedOn{ get; set; }

        [Required]
        public string CashierId { get; set; }

        public User Cashier { get; set; }

        public ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
