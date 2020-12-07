using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Debie.Models.DB;

namespace Debie.Services.Repositories.DB {
    public class OrderRepository : DBRepository<Order>, IOrderRepository {
        public OrderRepository(DebieDBContext context) {
            _Context = context;
        }
        public override List<Order> GetAll() {
            return _Context.Orders.ToList();
        }
        public override Order GetByID(params object[] keys) {
            return _Context.Orders.Find(keys);
        }
        public override void Insert(Order order) {
            _Context.Orders.Add(order);
        }
        public override void Delete(Order order) {
            _Context.Orders.Remove(order);
        }
        public override void Update(Order order) {
            _Context.Orders.Update(order);
        }
    }
}