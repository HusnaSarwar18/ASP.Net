using DigitalNexus.Models.Entities;

namespace DigitalNexus.Models.Services
{
    public interface ISellerService
    {
        void AddProduct(Product product);
        List<Product> GetProductsBySeller(int sellerId);
        void RemoveProduct(int productId);
    }
}
