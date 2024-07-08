using AumentaTestBack.Context;
using AumentaTestBack.Contracts;
using AumentaTestBack.Models;

namespace AumentaTestBack.Repositories
{
    public class PurchaseProductRepository : RepositoryBase<PurchaseProduct>, IPurchaseProductRepository
    {
        public PurchaseProductRepository(AppDbContext context) : base(context)
        {
            
        }

        public void CreatePurchaseProduct(PurchaseProduct purchaseProduct)
        {
            Create(purchaseProduct);
        }

        public PurchaseProduct? GetPurchaseProductByIds(int purchaseId, int productId)
        {
            return base.AppDbContext.PurchasesProducts.Where(p => p.PurchaseId == purchaseId && p.ProductId == productId).FirstOrDefault();
        }
    }
}
