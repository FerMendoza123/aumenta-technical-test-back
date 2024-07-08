namespace AumentaTestBack.DTO
{
    public class TaxesFreeProductDTO : ProductDTO
    {
        public override float GetTaxes()
        {
            return 0;
        }
    }
}
