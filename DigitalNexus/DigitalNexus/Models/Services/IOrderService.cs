using DigitalNexus.Models.Entities;

namespace DigitalNexus.Models.Services
{
    public interface IOrderService
    {
        Order GetOrderById(int orderId);
        List<Order> GetOrdersByStatus(string status);
        void UpdateOrderStatus(int orderId, string status);
    }
}
