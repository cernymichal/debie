using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class Image {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(256), Display(Name = "Image title")]
        public string Title { get; set; }
        [MaxLength(16), Required]
        public string ContentType { get; set; }
        [MaxLength(8388608), Required]
        public byte[] Data { get; set; }
    }
}