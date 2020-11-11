using System.ComponentModel.DataAnnotations;

namespace Debie.Models.DB {
    public class Image {
        // http://www.binaryintellect.net/articles/2f55345c-1fcb-4262-89f4-c4319f95c5bd.aspx
        [Key]
        public int ID { get; set; }
        [MaxLength(256)]
        public string Title { get; set; }
        [MaxLength(8192)]
        [Required]
        public byte[] Data { get; set; }
    }
}