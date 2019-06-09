using System.Collections.Generic;
using System.Linq;
using Panda.Data;
using Panda.Models;

namespace Panda.Services
{
    public class PackageService : IPackageService
    {
        private readonly PandaDbContext context;

        public PackageService(PandaDbContext context)
        {
            this.context = context;
        }

        public ICollection<string> GetRecipients()
        {
            return context.Users
                .Select(x => x.Username)
                .ToList();
        }

        public User GetRecipient(string recipientUsername)
        {
            var recipient = context.Users.SingleOrDefault(x => x.Username == recipientUsername);

            return recipient;
        }

        public void AddPackage(Package package)
        {
            context.Packages.Add(package);
            context.SaveChanges();
        }
    }
}
