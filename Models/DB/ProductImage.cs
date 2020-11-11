using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class ProductImage {
        [Key]
        [ForeignKey("Product")]
        public int Product { get; set; }
        [Key]
        [ForeignKey("Image")]
        public int Image { get; set; }
        [Required]
        public bool Cover { get; set; }
    }
}