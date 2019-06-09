using System;
using System.ComponentModel.DataAnnotations;
using Panda.Models.Enums;

namespace Panda.Models
{
    public class Package
    {
        public string Id { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public string RecipientId { get; set; }
        public User Recipient { get; set; }

        public Receipt Receipt { get; set; }
    }
}
