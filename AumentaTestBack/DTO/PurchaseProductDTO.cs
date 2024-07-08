namespace AumentaTestBack.DTO
{
    public class PurchaseProductDTO
    {
        public int Amount { get; set; }
        public ProductDTO Product { get; set; }
        public float GetFinalPrice()
        {
            return Product.FinalPrice*Amount;
        }
        public float GetTaxes()
        {
            return Product.GetTaxes()*Amount;
        }
    }
}
