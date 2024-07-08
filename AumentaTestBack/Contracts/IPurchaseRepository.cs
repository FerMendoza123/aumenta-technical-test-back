using AumentaTestBack.Models;

namespace AumentaTestBack.Contracts
{
    public interface IPurchaseRepository : IRepositoryBase<Purchase>
    {
        Purchase? GetLastPurchase();
        Purchase? GetLastPurchaseWithPurchaseProducts();
        void CreatePurchase(Purchase purchase);
        void UpdatePurchase(Purchase purchase);
    }
}
