using System.Linq;
using Musaca.Services;
using SIS.MvcFramework.Mapping;

namespace Musaca.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Result;
    using System.Collections.Generic;
    using Musaca.App.ViewModels.Orders;

    public class HomeController : Controller
    {
        private readonly IOrdersService ordersService;

        public HomeController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [HttpGet(Url = "/")]
        public IActionResult SlashIndex()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            List<OrderHomeViewModel> orderHomeViewModels = new List<OrderHomeViewModel>();

            //TODO: Add in service
            if (this.IsLoggedIn())
            {
                var currentOrder = this.ordersService.GetCurrentOrder(this.User.Username);
                var orderProducts = currentOrder.OrderProducts.Select(x => x.Product).ToList();

                foreach (var product in orderProducts)
                {
                    orderHomeViewModels.Add(ModelMapper.ProjectTo<OrderHomeViewModel>(product));
                }
            }

            return this.View(orderHomeViewModels);
        }
    }
}
