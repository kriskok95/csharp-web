using System.Collections.Generic;
using System.Linq;
using Panda.Data;

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
    }
}
