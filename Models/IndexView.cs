using System.Collections.Generic;

using Debie.Models.DB;

namespace Debie.Models {
    public class IndexView {
        public List<Product> InSale { get; set; }
        public List<Product> NewArrivals { get; set; }
        public IndexView(List<Product> inSale, List<Product> newArrivals) {
            InSale = inSale;
            NewArrivals = newArrivals;
        }
    }
}