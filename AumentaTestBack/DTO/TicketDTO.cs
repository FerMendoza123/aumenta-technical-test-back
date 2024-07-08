using AumentaTestBack.Models;

namespace AumentaTestBack.DTO
{
    public class TicketDTO
    {
        public float Taxes { get; set; }
        public float Total { get; set; }
        public List<PurchaseProductDTO> PurchaseProducts { get; set; }
    }
}
