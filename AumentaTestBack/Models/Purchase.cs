using System.ComponentModel.DataAnnotations;

namespace AumentaTestBack.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public bool Finished { get; set; }
        public List<PurchaseProduct> PurchaseProducts { get; set; }
    }
}
