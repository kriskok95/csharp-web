using System.Linq;
using Panda.App.ViewModels.Packages;
using Panda.Models;
using Panda.Models.Enums;
using Panda.Services;
using SIS.MvcFramework.Attributes.Http;
using SIS.MvcFramework.Result;

namespace Panda.App.Controllers
{
    public class PackagesController : BaseController
    {
        private readonly IPackageService packageService;

        public PackagesController(IPackageService packageService)
        {
            this.packageService = packageService;
        }

        public IActionResult Create()
        {
            var recipients = packageService.GetRecipients()
                .ToList();

            return this.View(recipients);
        }

        [HttpPost]
        public IActionResult Create(CreatePackageViewModel packageViewModel)
        {
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
    }
}
