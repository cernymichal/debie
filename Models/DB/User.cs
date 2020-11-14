using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Debie.Models.DB {
    public class User {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
        [MaxLength(256)]
        [Required]
        public string Password { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}