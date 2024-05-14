using InventoryAPI.Models;

namespace OrderAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsShipped { get; set; }
        public List<Product> Products { get; set; }
        public int TotalOrderPrice { get; set; }
    }
}
