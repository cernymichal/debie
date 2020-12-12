using System.ComponentModel.DataAnnotations;

namespace Debie.Models {
    public class OrderShippingForm {
        [MaxLength(256), Required]
        public string ShippingMethod { get; set; }

        public static OrderShippingForm FromOrderForm(OrderForm order) {
            return new OrderShippingForm {
                ShippingMethod = order.ShippingMethod
            };
        }

        public void ToOrderForm(OrderForm order) {
            order.ShippingMethod = ShippingMethod;
        }
    }
}