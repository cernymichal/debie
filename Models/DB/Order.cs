using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class Order {
        [Key]
        public int ID { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        [MaxLength(256)]
        public string Phone { get; set; }
        public bool Updates { get; set; }
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256)]
        [Required]
        public string LastName { get; set; }
        [ForeignKey("Address")]
        [Required]
        public int BillingAddress { get; set; }
        [ForeignKey("Address")]
        public int ShippingAddress { get; set; }
        [MaxLength(128)]
        [Required]
        public string ShippingMethod { get; set; }
        [Required]
        public int ShippingPrice { get; set; }
        [MaxLength(128)]
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}