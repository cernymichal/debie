using System.ComponentModel.DataAnnotations;

namespace Debie.Models.DB {
    public class Address {
        [Key]
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
    }
}