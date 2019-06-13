namespace Musaca.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Result;
    using System.Collections.Generic;
    using ViewModels.Orders;
    using System.Linq;
    using Services;
    using SIS.MvcFramework.Mapping;

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

            if (this.IsLoggedIn())
            {
                var currentOrder = this.ordersService.GetCurrentOrder(this.User.Username);
                var orderProducts = currentOrder.OrderProducts.Select(x => x.Product).ToList();
                orderHomeViewModels = orderProducts
                    .Select(ModelMapper.ProjectTo<OrderHomeViewModel>)
                    .ToList();
            }

            return this.View(orderHomeViewModels);
        }
    }
}
