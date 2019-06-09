using System.Collections.Generic;

namespace Panda.Services
{
    public interface IPackageService
    {
        ICollection<string> GetRecipients();
    }
}
