using System.Linq;
using Panda.Services;
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
    }
}
