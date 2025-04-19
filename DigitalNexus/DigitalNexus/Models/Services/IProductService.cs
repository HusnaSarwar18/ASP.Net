using DigitalNexus.Models.Entities;

namespace DigitalNexus.Models.Services
{
    // Interface for Product Operations
    public interface IProductService
    {
        Product GetProductById(int productId);
        List<Product> GetProductsByCategory(string category);
        List<Product> SearchProducts(string keyword);
    }
}
