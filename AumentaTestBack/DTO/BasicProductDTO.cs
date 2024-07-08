namespace AumentaTestBack.DTO
{
    public class BasicProductDTO : ProductDTO
    {
        public override float GetTaxes()
        {
            float roundPrice = Price;
            float decimalPart = Price - (int) Math.Truncate(Price);
            if (decimalPart > 0.5)
            {
                roundPrice = (float) Math.Ceiling(Price);
            }
            float taxes = roundPrice / 10;

            return taxes;
        }
    }
}
