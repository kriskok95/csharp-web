using System.Collections.Generic;
using System.Linq;
using Panda.App.ViewModels.Receipts;
using Panda.Models;
using Panda.Services;
using SIS.MvcFramework.Mapping;

namespace Panda.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Result;

    public class ReceiptsController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptsController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        public IActionResult Index()
        {
            List<Receipt> receiptsByUser = this.receiptService.GetReceiptsByUsername(this.User.Username);

            var receipts = receiptsByUser
                .Select(x => ModelMapper.ProjectTo<ListReceiptsViewModel>(x))
                .ToList();

            return this.View(receipts);
        }
    }
}
