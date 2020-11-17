using System.Collections.Generic;
using System.Linq;

using Debie.Models.DB;

namespace Debie.Services.Repositories.DB {
    public class VendorRepository : DBRepository<Vendor>, IVendorRepository {
        public VendorRepository(DebieDBContext context) {
            _Context = context;
        }
        public override IEnumerable<Vendor> GetAll() {
            return _Context.Vendors.ToList();
        }
        public override Vendor GetByID(int id) {
            return _Context.Vendors.Find(id);
        }
        public override void Insert(Vendor vendor) {
            _Context.Vendors.Add(vendor);
        }
        public override void Delete(Vendor vendor) {
            _Context.Vendors.Remove(vendor);
        }
        public override void Update(Vendor vendor) {
            _Context.Update(vendor);
        }
    }
}