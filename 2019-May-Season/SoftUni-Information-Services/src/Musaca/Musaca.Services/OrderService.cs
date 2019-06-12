using Musaca.Data;
using Musaca.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Musaca.Models.Enums;

namespace Musaca.Services
{
    public class OrderService : IOrdersService
    {
        private readonly MusacaDbContext context;

        public OrderService(MusacaDbContext context)
        {
            this.context = context;
        }

        public Order CreateOrder(Order order)
        {
            this.context.Orders.Add(order);
            this.context.SaveChanges();

            return order;
        }

        public Order GetCurrentOrder(string username)
        {
            var order = this.context.Orders
                .Include(x => x.Cashier)
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Cashier.Username == username && x.Status == OrderStatus.Active);

            return order;
        }

        public void AddProductToOrder(Order activeOrder, string productId)
        {
            activeOrder.OrderProducts.Add(new OrderProducts()
            {
                OrderId = activeOrder.Id,
                ProductId = productId
            });

            this.context.SaveChanges();
        }
    }
}
