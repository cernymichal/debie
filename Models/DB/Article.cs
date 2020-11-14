using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class Article {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [MaxLength(128)]
        [Required]
        public string Title { get; set; }
        [MaxLength(16384)]
        [Required]
        public string Content { get; set; }
        [MaxLength(256)]
        public string Tags { get; set; }

        public virtual User User { get; set; }
        public int ImageID { get; set; }
        public virtual Image Image { get; set; }
    }
}