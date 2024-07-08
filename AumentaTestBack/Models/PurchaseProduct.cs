namespace AumentaTestBack.Models
{
    public class PurchaseProduct
    {
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        
    }
}
