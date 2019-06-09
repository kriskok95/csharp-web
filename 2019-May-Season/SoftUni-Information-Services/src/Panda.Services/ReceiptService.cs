using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Panda.Data;
using Panda.Models;

namespace Panda.Services
{
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
                .SingleOrDefault(x => x.Username == username);

            if (user == null)
            {
                return null;
            }

            return user.Receipts
                .ToList();
        }
    }
}
