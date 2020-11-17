using System.Collections.Generic;
using System.Linq;

using Debie.Models.DB;

namespace Debie.Services.Repositories.DB {
    public class UserRepository : DBRepository<User>, IUserRepository {
        public UserRepository(DebieDBContext context) {
            _Context = context;
        }
        public override IEnumerable<User> GetAll() {
            return _Context.Users.ToList();
        }
        public override User GetByID(int id) {
            return _Context.Users.Find(id);
        }
        public override void Insert(User user) {
            _Context.Users.Add(user);
        }
        public override void Delete(User user) {
            _Context.Users.Remove(user);
        }
        public override void Update(User user) {
            _Context.Update(user);
        }
    }
}