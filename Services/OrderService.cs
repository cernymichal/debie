using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using System.Text.Json;
using System.Linq;

using Debie.Models;
using Debie.Services.Repositories;

namespace Debie.Services {
    public interface IOrderService {
        OrderForm CurrentOrder();
        void SaveCurrentOrder();
        void AddProduct(int id, int count);
        void RemoveProduct(int id);
        void SubmitCurrentOrder();
    }

    public class OrderService : IOrderService {
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly IProductRepository _ProductRepo;
        private readonly IOrderRepository _OrderRepo;
        private OrderForm _CurrentOrder;
        public OrderService(IHttpContextAccessor httpContextAccessor, IProductRepository productRepo, IOrderRepository orderRepo) {
            _HttpContextAccessor = httpContextAccessor;
            _ProductRepo = productRepo;
            _OrderRepo = orderRepo;
        }

        private OrderForm LoadCurrentOrder() {
            var serialized = _HttpContextAccessor.HttpContext.Session.GetString("order");

            if (serialized is null || serialized == "null")
                return new OrderForm();

            return JsonSerializer.Deserialize<OrderForm>(serialized);
        }

        public OrderForm CurrentOrder() {
            if (_CurrentOrder is null)
                _CurrentOrder = LoadCurrentOrder();

            return _CurrentOrder;
        }

        public void AddProduct(int id, int count) {
            var op = CurrentOrder().OrderProducts.SingleOrDefault(op => op.ProductID == id);

            if (op is null) {
                var product = _ProductRepo.GetByID(id);
                op = new OrderProductForm() {
                    UnitPrice = product.Price,
                    Discount = product.Discount,
                    ProductID = product.ID,
                    Name = product.Name,
                    MainProductImageID = product.MainProductImage is null ? 0 : product.MainProductImage.ImageID,
                    Color = product.Color
                };
                CurrentOrder().OrderProducts.Add(op);
            }

            op.Count += count;
        }

        public void RemoveProduct(int id) {
            CurrentOrder().OrderProducts.RemoveAll(op => op.ProductID == id);
        }

        public void SaveCurrentOrder() {
            var serialized = JsonSerializer.Serialize(_CurrentOrder);
            _HttpContextAccessor.HttpContext.Session.SetString("order", serialized);
        }

        public void SubmitCurrentOrder() {
            _OrderRepo.Insert(CurrentOrder().ToModel(0));
            _OrderRepo.Save();
            _CurrentOrder = null;
            SaveCurrentOrder();
        }
    }
}
