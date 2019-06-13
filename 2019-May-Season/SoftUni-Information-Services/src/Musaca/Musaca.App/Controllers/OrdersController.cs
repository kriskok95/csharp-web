using System.Threading;
using Musaca.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace Musaca.App.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;

        [Authorize]
        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [Authorize]
        public IActionResult Cashout()
        {
            this.ordersService.CashOut(this.User.Id);

            return this.Redirect("/Users/Profile");
        }
    }
}
