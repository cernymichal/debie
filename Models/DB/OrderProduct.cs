using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class OrderProduct {
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public int Count { get; set; }

        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}