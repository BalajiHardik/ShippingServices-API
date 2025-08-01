using System.ComponentModel.DataAnnotations;

namespace ShippingServices.Model
{
    public class ShippingItem
    {
        
        public int? Id {  get; set; }
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }
        public DateTime? ItemShippedDate { get; set; }
        
    }
}
