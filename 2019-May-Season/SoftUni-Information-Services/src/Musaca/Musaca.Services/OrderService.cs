using System;
using System.Collections.Generic;
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
        private readonly IUsersService usersService;

        public OrderService(MusacaDbContext context, IUsersService usersService)
        {
            this.context = context;
            this.usersService = usersService;
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

        public void CashOut(string userId)
        {
            User user = this.usersService.GetUserById(userId);
            Order currentOrder = GetCurrentOrder(user.Username);

            currentOrder.Status = OrderStatus.Completed;
            
            Order newCurrentOrder = new Order()
            {
                Cashier = user,
                Status = OrderStatus.Active,
                IssuedOn = DateTime.UtcNow
            };
            this.context.Add(newCurrentOrder);
            this.context.SaveChanges();
        }

        public List<Order> GetAllOrders(string cashierUsername)
        {
            var orders = this.context
                .Orders
                .Include(x => x.Cashier)
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Product)
                .Where(x => x.Cashier.Username == cashierUsername && x.Status == OrderStatus.Completed)
                .ToList();

            return orders;
        }
    }
}
