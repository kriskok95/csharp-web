using System;
using Musaca.App.ViewModels.Products;
using Musaca.App.ViewModels.Users;
using Musaca.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Http;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;
using System.Collections.Generic;
using System.Linq;
using Musaca.Models;

namespace Musaca.App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrdersService ordersService;

        public ProductsController(IProductService productService, IOrdersService ordersService)
        {
            this.productService = productService;
            this.ordersService = ordersService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

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
