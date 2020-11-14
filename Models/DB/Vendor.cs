using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Debie.Models.DB {
    public class Vendor {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(128)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}