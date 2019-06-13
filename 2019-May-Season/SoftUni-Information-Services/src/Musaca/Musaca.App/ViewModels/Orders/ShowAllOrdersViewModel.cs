using System;

namespace Musaca.App.ViewModels.Orders
{
    public class ShowAllOrdersViewModel
    {
        public string Id { get; set; }

        public decimal Total { get; set; }

        public DateTime IssuedOn { get; set; }

        public string Cashier { get; set; }
    }
}
