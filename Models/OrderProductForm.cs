namespace Debie.Models {
    public class OrderProductForm {
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Count { get; set; }
        public int ProductID { get; set; }
    }
}