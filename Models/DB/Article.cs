using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace Debie.Models.DB {
    public class Article {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required, MaxLength(128)]
        public string Title { get; set; }
        [Required, MaxLength(16384)]
        public string Content { get; set; }
        [Required]
        public DateTime Created { get; set; }

        [Required, Display(Name = "Author")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int ImageID { get; set; }
        public virtual Image Image { get; set; }
        public virtual List<Tag> Tags { get; set; }

        public bool Search(string query) {
            return
                Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                User.Username.Contains(query, StringComparison.OrdinalIgnoreCase);
        }
    }
}