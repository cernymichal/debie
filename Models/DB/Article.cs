using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class Article {
        [Key]
        public int ID { get; set; }
        [ForeignKey("User")]
        public int Author { get; set; }
        [ForeignKey("Image")]
        public int Cover { get; set; }
        [MaxLength(128)]
        [Required]
        public string Title { get; set; }
        [MaxLength(16384)]
        [Required]
        public string Content { get; set; }
        [MaxLength(256)]
        public string Tags { get; set; }
    }
}