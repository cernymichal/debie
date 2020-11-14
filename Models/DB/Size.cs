using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class Size {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(32)]
        public string Label { get; set; }
        [Required]
        public int Stock { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}