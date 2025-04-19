using DigitalNexus.Models.Entities;

namespace DigitalNexus.Models.Services
{
    public interface IBuyerService
    {
        void AddToCart(Cart cartItem);
        void PlaceOrder(Order order);
        List<Cart> ViewCart(int buyerId);
        List<Order> GetOrders(int buyerId);
    }
}
