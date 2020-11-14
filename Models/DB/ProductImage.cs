using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class ProductImage {
        [Required]
        public bool Main { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ImageID { get; set; }
        public virtual Image Image { get; set; }
    }
}