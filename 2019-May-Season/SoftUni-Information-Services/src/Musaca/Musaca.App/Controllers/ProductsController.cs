using SIS.MvcFramework.Attributes.Security;

namespace Musaca.App.Controllers
{
    using ViewModels.Products;
    using ViewModels.Users;
    using Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Result;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrdersService ordersService;

        public ProductsController(IProductService productService, IOrdersService ordersService)
        {
            this.productService = productService;
            this.ordersService = ordersService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateProductInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Products/Create");
            }

            this.productService.CreateProduct(inputModel.Name, inputModel.Price);

            return this.All();
        }

        [Authorize]
        public IActionResult All()
        {
            var products = this.productService.GetAllProducts();

            List<ProductsViewModel> productsViewModels = products.Select(x => new ProductsViewModel()
            {
                Name = x.Name,
                Price = x.Price
            }).ToList();


            return this.View(productsViewModels);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Order(OrderProductInputModel inputModel)
        {
            var product = this.productService.GetProductByName(inputModel.Product);

            if (product == null)
            {
                return this.Redirect("/");
            }

            var activeOrder = this.ordersService.GetCurrentOrder(this.User.Username);
            this.ordersService.AddProductToOrder(activeOrder, product.Id);

            return this.Redirect("/");
        }
    }
}
