namespace AumentaTestBack.Contracts
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        IPurchaseRepository Purchase { get; }
        IPurchaseProductRepository PurchaseProduct { get; }
        void Save();
    }
}
