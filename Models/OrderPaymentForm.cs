using System.ComponentModel.DataAnnotations;

namespace Debie.Models {
    public class OrderPaymentForm {
        [MaxLength(256), Required]
        public string PaymentMethod { get; set; }
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

        public static OrderPaymentForm FromOrderForm(OrderForm order) {
            return new OrderPaymentForm {
                PaymentMethod = order.PaymentMethod,
                BillingStreet = order.BillingStreet,
                BillingApartment = order.BillingApartment,
                BillingCity = order.BillingCity,
                BillingCountry = order.BillingCountry,
                BillingZip = order.BillingZip
            };
        }

        public void ToOrderForm(OrderForm order) {
            order.PaymentMethod = PaymentMethod;
            order.BillingStreet = BillingStreet;
            order.BillingApartment = BillingApartment;
            order.BillingCity = BillingCity;
            order.BillingCountry = BillingCountry;
            order.BillingZip = BillingZip;
        }
    }
}