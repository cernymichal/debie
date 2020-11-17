using System.Collections.Generic;
using System.Linq;

using Debie.Models.DB;

namespace Debie.Services.Repositories.DB {
    public class OrderRepository : DBRepository<Order>, IOrderRepository {
        public OrderRepository(DebieDBContext context) {
            _Context = context;
        }
        public override IEnumerable<Order> GetAll() {
            return _Context.Orders.ToList();
        }
        public override Order GetByID(int id) {
            return _Context.Orders.Find(id);
        }
        public override void Insert(Order order) {
            _Context.Orders.Add(order);
        }
        public override void Delete(Order order) {
            _Context.Orders.Remove(order);
        }
        public override void Update(Order order) {
            _Context.Update(order);
        }
    }
}