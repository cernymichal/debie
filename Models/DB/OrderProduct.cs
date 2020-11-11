using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class OrderProduct {
        [Key]
        [ForeignKey("Order")]
        public int Order { get; set; }
        [Key]
        [ForeignKey("Product")]
        public int Product { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        [Required]
        public int Discount { get; set; } // %
        [Required]
        public int Count { get; set; }
    }
}