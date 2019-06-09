using System.Collections.Generic;
using Panda.Models;

namespace Panda.Services
{
    public interface IPackageService
    {
        ICollection<string> GetRecipients();
        User GetRecipient(string packageViewModel);
        void AddPackage(Package package);
        ICollection<Package> GetPendingPackages();
        ICollection<Package> GetDeliveredPackages();
        void DeliverItem(string id);
    }
}
