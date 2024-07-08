using AumentaTestBack.Models;

namespace AumentaTestBack.Contracts
{
    public interface IPurchaseProductRepository : IRepositoryBase<PurchaseProduct>
    {
        PurchaseProduct? GetPurchaseProductByIds(int purchaseId,int productId);
        void CreatePurchaseProduct(PurchaseProduct purchaseProduct);
    }
}
