using System.ComponentModel.DataAnnotations;

namespace Debie.Models.DB {
    public class User {
        [Key]
        public int ID { get; set; }
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
        [MaxLength(256)]
        [Required]
        public string Password { get; set; }
    }
}