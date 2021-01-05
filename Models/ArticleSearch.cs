using System.Collections.Generic;

namespace Debie.Models {
    public class ArticleSearch {
        public string Query { get; set; }
        public List<int> Tags { get; set; }
        public ArticleSearch() {
            Query = "";
            Tags = new List<int>();
        }
    }
}