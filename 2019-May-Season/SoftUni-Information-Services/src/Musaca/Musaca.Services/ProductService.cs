namespace Musaca.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Musaca.Data;
    using Musaca.Models;

    public class ProductService : IProductService
    {
        private readonly MusacaDbContext context;

        public ProductService(MusacaDbContext context)
        {
            this.context = context;
        }

        public void CreateProduct(string name, decimal price)
        {
            Product product = new Product
            {
                Name = name,
                Price = price
            };

            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return this.context
                .Products
                .ToList();
        }

        public Product GetProductByName(string productName)
        {
            var product = context.Products.FirstOrDefault(x => x.Name == productName);

            return product;
        }
    }
}
