using System.ComponentModel.DataAnnotations;

namespace Debie.Models.DB {
    public class Vendor {
        [Key]
        public int ID { get; set; }
        [MaxLength(128)]
        [Required]
        public string Name { get; set; }
    }
}