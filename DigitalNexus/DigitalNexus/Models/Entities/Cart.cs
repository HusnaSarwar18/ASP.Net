namespace DigitalNexus.Models.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
