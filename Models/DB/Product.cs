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
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DataType(DataType.Currency)]
        public decimal Discount { get; set; }
        public DateTime DiscountFrom { get; set; }
        public DateTime DiscountUntil { get; set; }
        public int ReviewsCount { get; set; } = 0;
        public decimal ReviewsSum { get; set; } = 0;

        public int VendorID { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }
        public virtual ProductImage MainProductImage { get; set; }
        public virtual List<Size> Sizes { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; }

        [NotMapped]
        public bool Discounted {
            get {
                return DiscountFrom >= DateTime.UtcNow && DiscountUntil < DateTime.UtcNow;
            }
        }
        [NotMapped]
        public decimal CurrentPrice {
            get {
                return Price * (1 - (Discounted ? Discount : 0));
            }
        }
        [NotMapped]
        public decimal ReviewsAvg {
            get {
                return ReviewsSum / ReviewsCount;
            }
        }
        [NotMapped]
        public decimal Stock {
            get {
                var stock = 0;
                foreach (var size in Sizes)
                    stock += size.Stock;
                return stock;
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