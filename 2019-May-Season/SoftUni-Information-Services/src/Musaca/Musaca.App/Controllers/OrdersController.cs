using System.Threading;
using Musaca.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Result;

namespace Musaca.App.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public IActionResult Cashout()
        {
            this.ordersService.CashOut(this.User.Id);

            return this.Redirect("/Users/Profile");
        }
    }
}
