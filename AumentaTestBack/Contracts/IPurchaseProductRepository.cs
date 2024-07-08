using AumentaTestBack.Models;

namespace AumentaTestBack.Contracts
{
    public interface IPurchaseProductRepository : IRepositoryBase<PurchaseProduct>
    {

        void CreatePurchaseProduct(PurchaseProduct purchaseProduct);
    }
}
