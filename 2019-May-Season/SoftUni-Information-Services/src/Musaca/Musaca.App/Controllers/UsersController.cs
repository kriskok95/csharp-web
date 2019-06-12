using System;
using System.Collections.Generic;
using System.Linq;
using Musaca.App.ViewModels.Orders;

namespace Musaca.App.Controllers
{
    using Musaca.App.ViewModels.Users;
    using Musaca.Models;
    using Musaca.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Result;

    public class UsersController : Controller
    {
        private readonly IUsersService userService;
        private readonly IOrdersService orderService;

        public UsersController(IUsersService userService, IOrdersService orderService)
        {
            this.userService = userService;
            this.orderService = orderService;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/");
            }

            User userFromDb = userService.GetUserFromDb(inputModel.Username, inputModel.Password);

            if(userFromDb == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email);

            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if(inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            string userId = userService.RegisterUser(inputModel.Username, inputModel.Password, inputModel.Email);
            this.orderService.CreateOrder(new Order { CashierId = userId, IssuedOn = DateTime.UtcNow});

            return this.Redirect("/Users/Login");
        }

        public IActionResult Profile()
        {
            List<Order> allOrders = this.orderService.GetAllOrders(this.User.Username);

            var allOrdersView = allOrders.Select(x => new ShowAllOrdersViewModel()
            {
                Id = x.Id,
                Cashier = x.Cashier.Username,
                IssuedOn = x.IssuedOn,
                Total = x.OrderProducts.Sum(y => y.Product.Price)
            })
                .ToList();

            return this.View(allOrdersView);
        }

        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
