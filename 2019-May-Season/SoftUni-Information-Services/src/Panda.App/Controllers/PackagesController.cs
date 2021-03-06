﻿namespace Panda.App.Controllers
{
    using System.Linq;
    using ViewModels.Packages;
    using Models;
    using Models.Enums;
    using Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;

    public class PackagesController : Controller
    {
        private readonly IPackageService packageService;

        public PackagesController(IPackageService packageService)
        {
            this.packageService = packageService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var recipients = packageService.GetRecipients()
                .ToList();

            return this.View(recipients);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreatePackageViewModel packageViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Packages/Create");
            }

            var package = new Package
            {
                Description = packageViewModel.Description,
                Weight = packageViewModel.Weight,
                ShippingAddress = packageViewModel.ShippingAddress,
                Recipient = packageService.GetRecipient(packageViewModel.RecipientName),
                Status = Status.Pending
            };

            this.packageService.AddPackage(package);

            //TODO: Maybe redirect to different page
            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Pending()
        {
            var packages = packageService
                .GetPendingPackages()
                .ToList();

            var packagesViewModel = packages
                .Select(x => new ShowPackagesViewModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight,
                    RecipientName = x.Recipient.Username
                })
                .ToList();

            return this.View(packagesViewModel);
        }

        [Authorize]
        public IActionResult Delivered()
        {
            var packages = packageService
                .GetDeliveredPackages()
                .ToList();

            var packagesViewModel = packages
                .Select(x => new ShowPackagesViewModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight,
                    RecipientName = x.Recipient.Username
                })
                .ToList();

            return this.View(packagesViewModel);
        }

        [Authorize]
        public IActionResult Deliver(string id)
        {
            packageService.DeliverItem(id);
            
            return this.Redirect("/");
        }
    }
}
