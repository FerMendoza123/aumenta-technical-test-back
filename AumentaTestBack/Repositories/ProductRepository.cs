using AumentaTestBack.Context;
using AumentaTestBack.Contracts;
using AumentaTestBack.Models;

namespace AumentaTestBack.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> products = AppDbContext.Products.ToList();
            return products;
        }
    }
}
