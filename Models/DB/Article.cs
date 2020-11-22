using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace Debie.Models.DB {
    public class Article {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(128)]
        [Required]
        public string Title { get; set; }
        [MaxLength(16384)]
        [Required]
        public string Content { get; set; }

        public virtual User User { get; set; }
        public int ImageID { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public bool Search(string query) {
            return
                Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                User.Username.Contains(query, StringComparison.OrdinalIgnoreCase);
        }
    }
}