using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class Address {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(256)]
        [Required]
        public string AddressStreet { get; set; }
        [MaxLength(256)]
        public string Apartment { get; set; }
        [MaxLength(256)]
        [Required]
        public string City { get; set; }
        [MaxLength(256)]
        [Required]
        public string Country { get; set; }
        [MaxLength(256)]
        [Required]
        public string Zip { get; set; }

        public virtual Order Order { get; set; }
    }
}