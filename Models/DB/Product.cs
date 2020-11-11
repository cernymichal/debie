using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class Product {
        [Key]
        public int ID { get; set; }
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
        [ForeignKey("Vendor")]
        public int Vendor { get; set; }
        [MaxLength(4096)]
        public string Description { get; set; }
        [MaxLength(64)]
        public string Color { get; set; }
        [MaxLength(256)]
        public string Tags { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; } // %
        public DateTime DiscountFrom { get; set; }
        public DateTime DiscountUntil { get; set; }
        public int ReviewsCount { get; set; } // https://stackoverflow.com/questions/12636613/how-to-calculate-moving-average-without-keeping-the-count-and-data-total
        public int ReviewsAverage { get; set; }
    }
}