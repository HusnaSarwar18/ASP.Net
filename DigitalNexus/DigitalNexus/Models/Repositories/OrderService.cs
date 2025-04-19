using Dapper;
using DigitalNexus.Models.Entities;
using DigitalNexus.Models.Services;
using System.Data;

namespace DigitalNexus.Models.Repositories
{
    public class OrderService : IOrderService
    {
        private readonly IDbConnection _db;

        public OrderService(IDbConnection db)
        {
            _db = db;
        }

        public Order GetOrderById(int orderId)
        {
            string sql = "SELECT * FROM Orders WHERE OrderId = @OrderId";
            return _db.QuerySingleOrDefault<Order>(sql, new { OrderId = orderId });
        }

        public List<Order> GetOrdersByStatus(string status)
        {
            string sql = "SELECT * FROM Orders WHERE OrderStatus = @OrderStatus";
            return _db.Query<Order>(sql, new { OrderStatus = status }).ToList();
        }

        public void UpdateOrderStatus(int orderId, string status)
        {
            string sql = "UPDATE Orders SET OrderStatus = @OrderStatus WHERE OrderId = @OrderId";
            _db.Execute(sql, new { OrderId = orderId, OrderStatus = status });
        }
    }

}
