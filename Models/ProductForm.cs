using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Debie.Models.DB;

namespace Debie.Models {
    public class ProductForm {
        [Key]
        public int ID { get; set; }
        [MaxLength(256), Required]
        public string Name { get; set; }
        [MaxLength(4096)]
        public string Description { get; set; }
        [MaxLength(64)]
        public string Color { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        [Display(Name = "Discount from")]
        public DateTime DiscountFrom { get; set; }
        [Display(Name = "Discount until")]
        public DateTime DiscountUntil { get; set; }
        [Display(Name = "Vendor")]
        public int VendorID { get; set; }
        public List<ImageForm> Images { get; set; }
        [Display(Name = "Main")]
        public int MainImageID { get; set; }

        public ProductForm() {
            Images = new List<ImageForm>();
        }

        public static ProductForm FromModel(Product model) {
            return new ProductForm {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                Color = model.Color,
                Price = model.Price.ToString(),
                Discount = model.Discount.ToString(),
                DiscountFrom = model.DiscountFrom,
                DiscountUntil = model.DiscountUntil,
                VendorID = model.VendorID,
                Images = model.ProductImages is null ? new List<ImageForm>() : model.ProductImages.Select(i => ImageForm.FromModel(i.Image)).ToList(),
                MainImageID = model.MainProductImage is null ? 0 : model.MainProductImage.Image.ID
            };
        }

        public Product ToModel(Product model) {
            model.Name = Name;
            model.Description = Description;
            model.Color = Color;
            model.Price = Price is null ? 0M : decimal.Parse(Price);
            model.Discount = Discount is null ? 0M : decimal.Parse(Discount);
            model.DiscountFrom = DiscountFrom;
            model.DiscountUntil = DiscountUntil;
            model.VendorID = VendorID;
            model.MainProductImage = model.ProductImages is null ? null : model.ProductImages.First(pi => pi.ImageID == MainImageID);
            return model;
        }
    }
}