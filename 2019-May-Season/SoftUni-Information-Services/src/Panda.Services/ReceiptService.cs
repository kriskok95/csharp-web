namespace Panda.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Models;

    public class ReceiptService : IReceiptService
    {
        private readonly PandaDbContext context;

        public ReceiptService(PandaDbContext context)
        {
            this.context = context;
        }

        public List<Receipt> GetReceiptsByUsername(string username)
        {
            User user = this
                .context.Users
                .Include(x => x.Receipts)
                .SingleOrDefault(x => x.Username == username);

            return user?.Receipts
                .ToList();
        }
    }
}
