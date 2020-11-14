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
        public string Email { get; set; }
        [MaxLength(256)]
        public string Phone { get; set; }
        public bool Updates { get; set; }
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256)]
        [Required]
        public string LastName { get; set; }
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

        [Required]
        public int BillingAddressID { get; set; }
        [Required]
        public virtual Address BillingAddress { get; set; }
        public int ShippingAddressID { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}