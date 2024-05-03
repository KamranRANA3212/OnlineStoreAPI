using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreAPI.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemCost { get; set; }
        public int Quantity { get; set; }

        // Navigation property for OrderDetails
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
