namespace OrderAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int InternalOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsShipped { get; set; }
    }
}
