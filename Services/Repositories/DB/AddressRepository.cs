using System.Collections.Generic;
using System.Linq;

using Debie.Models.DB;

namespace Debie.Services.Repositories.DB {
    public class AddressRepository : DBRepository<Address>, IAddressRepository {
        public AddressRepository(DebieDBContext context) {
            _Context = context;
        }
        public override IEnumerable<Address> GetAll() {
            return _Context.Addresses.ToList();
        }
        public override Address GetByID(int id) {
            return _Context.Addresses.Find(id);
        }
        public override void Insert(Address address) {
            _Context.Addresses.Add(address);
        }
        public override void Delete(Address address) {
            _Context.Addresses.Remove(address);
        }
        public override void Update(Address address) {
            _Context.Update(address);
        }
    }
}