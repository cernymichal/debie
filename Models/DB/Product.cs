using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debie.Models.DB {
    public class Product {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(256), Required]
        public string Name { get; set; }
        [MaxLength(4096)]
        public string Description { get; set; }
        [MaxLength(64)]
        public string Color { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public DateTime DiscountFrom { get; set; }
        public DateTime DiscountUntil { get; set; }
        public int ReviewsCount { get; set; } = 0;
        public float ReviewsSum { get; set; } = 0F;

        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual Image MainImage { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        [NotMapped]
        public bool Discounted {
            get {
                return DiscountFrom >= DateTime.UtcNow && DiscountUntil < DateTime.UtcNow;
            }
        }
        [NotMapped]
        public float CurrentPrice {
            get {
                return Price * (1 - (Discounted ? Discount : 0));
            }
        }
        [NotMapped]
        public float ReviewsAvg {
            get {
                return ReviewsSum / ReviewsCount;
            }
        }

        public bool Search(string query) {
            return
                Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                Vendor.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                Color.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                Categories.FirstOrDefault(c => c.Name.Contains(query, StringComparison.OrdinalIgnoreCase)) != null;
        }
    }
}