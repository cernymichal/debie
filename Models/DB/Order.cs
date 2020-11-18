using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class Order {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(256)]
        [Required]
        public string Email { get; set; }
        [MaxLength(256)]
        [Required]
        public string Phone { get; set; }
        [Required]
        public bool Updates { get; set; } = false;
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(128)]
        [Required]
        public string ShippingMethod { get; set; }
        [Required]
        public float ShippingPrice { get; set; }
        [MaxLength(128)]
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
        [MaxLength(256)]
        [Required]
        public string BillingStreet { get; set; }
        [MaxLength(256)]
        public string BillingApartment { get; set; }
        [MaxLength(256)]
        [Required]
        public string BillingCity { get; set; }
        [MaxLength(256)]
        [Required]
        public string BillingCountry { get; set; }
        [MaxLength(256)]
        [Required]
        public string BillingZip { get; set; }
        [MaxLength(256)]
        public string ShippingStreet { get; set; }
        [MaxLength(256)]
        public string ShippingApartment { get; set; }
        [MaxLength(256)]
        public string ShippingCity { get; set; }
        [MaxLength(256)]
        public string ShippingCountry { get; set; }
        [MaxLength(256)]
        public string ShippingZip { get; set; }
        [Required]
        public float VAT { get; set; } = 21F;

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}