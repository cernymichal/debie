using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

using Debie.Services;
using Debie.Models.DB;

namespace Debie.Components {
    public class CheckoutSidebarComponent : ViewComponent {
        private readonly IOrderService _OrderService;
        public CheckoutSidebarComponent(IOrderService order) {
            _OrderService = order;
        }
        public IViewComponentResult Invoke() {
            return View(_OrderService.CurrentOrder());
        }
    }
}