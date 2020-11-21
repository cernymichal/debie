using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class Size {
        [MaxLength(32), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Label { get; set; }
        [Required]
        public int Stock { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}