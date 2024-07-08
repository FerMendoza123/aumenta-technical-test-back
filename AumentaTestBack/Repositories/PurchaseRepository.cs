using AumentaTestBack.Context;
using AumentaTestBack.Contracts;
using AumentaTestBack.Models;
using Microsoft.EntityFrameworkCore;

namespace AumentaTestBack.Repositories
{
    public class PurchaseRepository : RepositoryBase<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(AppDbContext context) : base(context)
        {
            context = context;
        }

        public Purchase? GetLastPurchase()
        {
            Purchase? lastPurchase =  AppDbContext.Purchases.OrderByDescending(p => p.Id).FirstOrDefault();
            return lastPurchase;

        }
        public Purchase? GetLastPurchaseWithPurchaseProducts()
        {
            Purchase? lastPurchase = AppDbContext.Purchases.Include(p => p.PurchaseProducts).ThenInclude(p=>p.Product).OrderByDescending(p=>p.Id).FirstOrDefault();
            return lastPurchase;
        }

        public void CreatePurchase(Purchase purchase)
        {
            Create(purchase);
        }

        public void UpdatePurchase(Purchase purchase)
        {
            Update(purchase);
        }
    }
}
