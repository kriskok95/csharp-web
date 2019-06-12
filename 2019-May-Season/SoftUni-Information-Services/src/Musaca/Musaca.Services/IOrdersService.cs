using Musaca.Models;

namespace Musaca.Services
{
    public interface IOrdersService
    {
        Order CreateOrder(Order order);
        Order GetCurrentOrder(string username);
        void AddProductToOrder(Order activeOrderId, string productId);
    }
}
