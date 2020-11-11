using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class ProductCategory {
        [Key]
        [ForeignKey("Product")]
        public int Product { get; set; }
        [Key]
        [ForeignKey("Category")]
        public int Category { get; set; }
    }
}