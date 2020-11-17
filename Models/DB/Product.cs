using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class Product {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
        [MaxLength(4096)]
        public string Description { get; set; }
        [MaxLength(64)]
        public string Color { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; } // %
        public DateTime DiscountFrom { get; set; }
        public DateTime DiscountUntil { get; set; }
        public int ReviewsCount { get; set; } = 0;// https://stackoverflow.com/questions/12636613/how-to-calculate-moving-average-without-keeping-the-count-and-data-total
        public float ReviewsAverage { get; set; } = 0F;

        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}