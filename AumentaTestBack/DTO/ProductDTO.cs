namespace AumentaTestBack.DTO
{
    public abstract class ProductDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public float FinalPrice { get; set; }
        public abstract float GetTaxes();
    }
}
