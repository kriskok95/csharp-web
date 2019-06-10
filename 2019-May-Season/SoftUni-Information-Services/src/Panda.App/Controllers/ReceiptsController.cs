namespace Panda.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels.Receipts;
    using Models;
    using Services;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Result;

    public class ReceiptsController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptsController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<Receipt> receiptsByUser = this.receiptService.GetReceiptsByUsername(this.User.Username);

            var receipts = receiptsByUser
                .Select(x => new ListReceiptsViewModel
                {
                    Id = x.Id,
                    Fee = x.Fee,
                    IssuedOn = x.IssuedOn,
                    Recipient = x.Recipient.Username
                })
                .ToList();

            return this.View(receipts);
        }
    }
}
