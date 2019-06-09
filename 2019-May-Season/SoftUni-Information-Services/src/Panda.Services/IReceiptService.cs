using System.Collections.Generic;
using Panda.Models;

namespace Panda.Services
{
    public interface IReceiptService
    {
        List<Receipt> GetReceiptsByUsername(string username);
    }
}
