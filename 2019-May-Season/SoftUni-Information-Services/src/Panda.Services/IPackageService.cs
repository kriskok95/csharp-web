namespace Panda.Services
{
    using System.Collections.Generic;
    using Models;

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
