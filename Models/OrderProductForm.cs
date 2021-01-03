using Debie.Models.DB;

namespace Debie.Models {
    public class OrderProductForm {
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Count { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int MainProductImageID { get; set; }
        public string Color { get; set; }

        public OrderProduct ToModel() {
            return new OrderProduct() {
                UnitPrice = UnitPrice,
                Discount = Discount,
                Count = Count,
                ProductID = ProductID
            };
        }

        public decimal Sum { get { return UnitPrice * Count * (1 - Discount); } }
    }
}