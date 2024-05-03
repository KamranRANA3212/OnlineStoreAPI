using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStoreAPI.Models
{
    public class Order
    {
        [Key]
       
        public int OrderId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime OrderedDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OrderedAmount { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
