using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Debie.Models;
using Debie.Models.DB;
using Debie.Services;

namespace Debie.Controllers {
    public class CartController : Controller {
        private readonly IOrderService _OrderService;

        public CartController(IOrderService orderService) {
            _OrderService = orderService;
        }

        public IActionResult Index() {
            return View(_OrderService.CurrentOrder());
        }

        public IActionResult RemoveOrderProduct(int id) {
            _OrderService.RemoveProduct(id);
            _OrderService.SaveCurrentOrder();
            return RedirectToAction("Index");
        }


        public IActionResult Contact() {
            var contactForm = OrderContactForm.FromOrderForm(_OrderService.CurrentOrder());
            return View(contactForm);
        }

        [HttpPost]
        public IActionResult ContactUpdate(OrderContactForm contact) {
            contact.ToOrderForm(_OrderService.CurrentOrder());
            _OrderService.SaveCurrentOrder();
            return RedirectToAction("Shipping");
        }

        public IActionResult Shipping() {
            var shippingForm = OrderShippingForm.FromOrderForm(_OrderService.CurrentOrder());
            return View(shippingForm);
        }

        [HttpPost]
        public IActionResult ShippingUpdate(OrderShippingForm shipping) {
            shipping.ToOrderForm(_OrderService.CurrentOrder());
            _OrderService.CurrentOrder().ShippingPrice = OrderForm.Options.ShippingMethods[_OrderService.CurrentOrder().ShippingMethod];
            _OrderService.SaveCurrentOrder();
            return RedirectToAction("Payment");
        }

        public IActionResult Payment() {
            var paymentForm = OrderPaymentForm.FromOrderForm(_OrderService.CurrentOrder());
            return View(paymentForm);
        }

        [HttpPost]
        public IActionResult PaymentUpdate(OrderPaymentForm payment) {
            try {
                payment.ToOrderForm(_OrderService.CurrentOrder());
                _OrderService.SubmitCurrentOrder();
            }
            catch (Exception) {
                return Content("Something went wrong.");
            }

            return RedirectToAction("Complete");
        }

        public IActionResult Complete() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
