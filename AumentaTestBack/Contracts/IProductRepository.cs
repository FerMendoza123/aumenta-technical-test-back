using AumentaTestBack.Models;

namespace AumentaTestBack.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        public IEnumerable<Product> GetAllProducts();
    }
}
