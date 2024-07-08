using AumentaTestBack.Models;

namespace AumentaTestBack.DTO
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public bool Finished { get; set; }
        public List<PurchaseProductDTO> PurchaseProducts { get; set; }
    }
}
