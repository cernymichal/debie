using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Debie.Models.DB {
    public class Tag {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(32), Required]
        public string Label { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}