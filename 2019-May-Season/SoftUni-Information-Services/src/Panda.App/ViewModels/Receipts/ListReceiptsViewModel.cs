namespace Panda.App.ViewModels.Receipts
{
    using System;

    public class ListReceiptsViewModel
    {
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public string Recipient { get; set; }
    }
}
