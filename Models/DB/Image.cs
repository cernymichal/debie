using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class Image {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(256)]
        public string Title { get; set; }
        [MaxLength(4), Required]
        public string Extension { get; set; }
        [MaxLength(8192), Required]
        public byte[] Data { get; set; }
    }
}