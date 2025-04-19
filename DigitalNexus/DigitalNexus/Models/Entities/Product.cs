namespace DigitalNexus.Models.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty; // Ensures it is initialized
        public string Category { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Condition { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int SellerId { get; set; }
    }

}
