using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Debie.Models.DB;

namespace Debie.Services.Repositories.DB {
    public class UserRepository : DBRepository<User>, IUserRepository {
        public UserRepository(DebieDBContext context) {
            _Context = context;
        }
        public override IEnumerable<User> GetAll() {
            return _Context.Users.ToList();
        }
        public override User GetByID(params object[] keys) {
            return _Context.Users.Find(keys);
        }
        public override void Insert(User user) {
            user.LastChanged = DateTime.UtcNow;
            _Context.Users.Add(user);
        }
        public override void Delete(User user) {
            _Context.Users.Remove(user);
        }
        public override void Update(User user) {
            user.LastChanged = DateTime.UtcNow;
            _Context.Users.Update(user);
        }
    }
}