namespace DigitalNexus.Models.Entities
{
    public class Buyer
    {
        public int BuyerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public List<Cart> CartItems { get; set; } = new List<Cart>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
