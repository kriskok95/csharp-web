using System;
using Panda.Models;

namespace Panda.App.ViewModels.Receipts
{
    public class ListReceiptsViewModel
    {
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        //TODO: Try without ID
        public string RecipientId { get; set; }
        public User Recipient { get; set; }
    }
}
