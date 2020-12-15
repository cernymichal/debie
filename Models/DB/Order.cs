using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Debie.Models.DB {
    public class Order {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(256), Required]
        public string Email { get; set; }
        [Required]
        public bool Updates { get; set; } = false;
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256), Required]
        public string LastName { get; set; }
        [MaxLength(128), Required]
        public string ShippingMethod { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal ShippingPrice { get; set; }
        [MaxLength(128), Required]
        public string PaymentMethod { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
        [MaxLength(256)]
        public string BillingStreet { get; set; }
        [MaxLength(256)]
        public string BillingApartment { get; set; }
        [MaxLength(256)]
        public string BillingCity { get; set; }
        [MaxLength(256)]
        public string BillingCountry { get; set; }
        [MaxLength(256)]
        public string BillingZip { get; set; }
        [MaxLength(256), Required]
        public string ShippingStreet { get; set; }
        [MaxLength(256)]
        public string ShippingApartment { get; set; }
        [MaxLength(256), Required]
        public string ShippingCity { get; set; }
        [MaxLength(256), Required]
        public string ShippingCountry { get; set; }
        [MaxLength(256), Required]
        public string ShippingZip { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal VAT { get; set; } = .21M;

        public virtual List<OrderProduct> OrderProducts { get; set; }

        [NotMapped]
        public decimal Sum { get { return OrderProducts.Select(op => op.UnitPrice * op.Count * (1 - op.Discount) * (1 + VAT)).Sum() + ShippingPrice; } }

        public bool Search(string query) {
            return LastName.Contains(query, StringComparison.OrdinalIgnoreCase);
        }
    }
}