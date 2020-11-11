using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class ProductSize {
        [Key]
        [ForeignKey("Product")]
        public int Product { get; set; }
        [Key]
        [MaxLength(32)]
        public string Size { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}