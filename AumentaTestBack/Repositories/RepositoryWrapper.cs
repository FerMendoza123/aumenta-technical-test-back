using AumentaTestBack.Context;
using AumentaTestBack.Contracts;

namespace AumentaTestBack.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext _context;
        private IProductRepository _product;
        private IPurchaseRepository _purchase;
        private IPurchaseProductRepository _purchaseProduct;

        public RepositoryWrapper(AppDbContext context)
        {
            _context = context;
        }
        public IProductRepository Product
        {
            get { 
                if(_product == null)
                {
                    _product = new ProductRepository(_context);
                }
                return _product; 
            }
        }

        public IPurchaseRepository Purchase
        {
            get
            {
                if (_purchase == null)
                {
                    _purchase = new PurchaseRepository(_context);
                }
                return _purchase;
            }
        }

        public IPurchaseProductRepository PurchaseProduct
        {
            get
            {
                if (_purchaseProduct == null)
                {
                    _purchaseProduct = new PurchaseProductRepository(_context);
                }
                return _purchaseProduct;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
