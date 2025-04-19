namespace DigitalNexus.Models.Entities
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessName { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
