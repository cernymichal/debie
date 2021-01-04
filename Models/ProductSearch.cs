using System.Collections.Generic;

namespace Debie.Models {
    public class ProductSearch {
        public string Query { get; set; }
        public List<int> Categories { get; set; }
        public List<int> Vendors { get; set; }
        public ProductSearch() {
            Query = "";
            Categories = new List<int>();
            Vendors = new List<int>();
        }
    }
}