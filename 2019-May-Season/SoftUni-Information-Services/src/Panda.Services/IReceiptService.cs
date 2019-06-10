namespace Panda.Services
{
    using System.Collections.Generic;
    using Models;

    public interface IReceiptService
    {
        List<Receipt> GetReceiptsByUsername(string username);
    }
}
