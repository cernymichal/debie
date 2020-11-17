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

        [Required]
        public int BillingAddressID { get; set; }
        [Required]
        public virtual Address BillingAddress { get; set; }
        [Required]
        public int ShippingAddressID { get; set; }
        [Required]
        public virtual Address ShippingAddress { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}