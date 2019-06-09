using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Models;
using Panda.Models.Enums;

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

        public ICollection<Package> GetPendingPackages()
        {
            return context.Packages
                .Include(x => x.Recipient)
                .Where(x => x.Status == Status.Pending)
                .ToList();
        }

        public ICollection<Package> GetDeliveredPackages()
        {
            return context.Packages
                .Include(x => x.Recipient)
                .Where(x => x.Status == Status.Delivered)
                .ToList();
        }
    }
}
