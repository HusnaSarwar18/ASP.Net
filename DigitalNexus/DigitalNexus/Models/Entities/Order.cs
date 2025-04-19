namespace DigitalNexus.Models.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
