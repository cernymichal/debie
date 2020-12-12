using System.ComponentModel.DataAnnotations;

namespace Debie.Models {
    public class OrderContactForm {
        [MaxLength(256), Required]
        public string Email { get; set; }
        public bool Updates { get; set; } = false;
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256), Required]
        public string LastName { get; set; }

        [MaxLength(256), Required]
        public string ShippingStreet { get; set; }
        [MaxLength(256), Required]
        public string ShippingApartment { get; set; }
        [MaxLength(256), Required]
        public string ShippingCity { get; set; }
        [MaxLength(256), Required]
        public string ShippingCountry { get; set; }
        [MaxLength(256), Required]
        public string ShippingZip { get; set; }

        public static OrderContactForm FromOrderForm(OrderForm order) {
            return new OrderContactForm {
                Email = order.Email,
                Updates = order.Updates,
                FirstName = order.FirstName,
                LastName = order.LastName,
                ShippingStreet = order.ShippingStreet,
                ShippingApartment = order.ShippingApartment,
                ShippingCity = order.ShippingCity,
                ShippingCountry = order.ShippingCountry,
                ShippingZip = order.ShippingZip
            };
        }

        public void ToOrderForm(OrderForm order) {
            order.Email = Email;
            order.Updates = Updates;
            order.FirstName = FirstName;
            order.LastName = LastName;
            order.ShippingStreet = ShippingStreet;
            order.ShippingApartment = ShippingApartment;
            order.ShippingCity = ShippingCity;
            order.ShippingCountry = ShippingCountry;
            order.ShippingZip = ShippingZip;
        }
    }
}