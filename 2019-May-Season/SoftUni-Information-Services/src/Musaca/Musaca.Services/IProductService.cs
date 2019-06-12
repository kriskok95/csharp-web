using Musaca.Models;
using System.Collections.Generic;

namespace Musaca.Services
{
    public interface IProductService
    {
        void CreateProduct(string name, decimal price);

        List<Product> GetAllProducts();
        Product GetProductByName(string product);
    }
}
