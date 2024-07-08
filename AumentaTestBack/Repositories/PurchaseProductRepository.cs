﻿using AumentaTestBack.Context;
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
    }
}
