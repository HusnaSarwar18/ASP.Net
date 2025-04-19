using Dapper;
using DigitalNexus.Models.Entities;
using DigitalNexus.Models.Services;
using System.Data;

namespace DigitalNexus.Models.Repositories
{
    public class BuyerService : IBuyerService
    {
        private readonly IDbConnection _db;

        public BuyerService(IDbConnection db)
        {
            _db = db;
        }

        public void AddToCart(Cart cartItem)
        {
            string sql = "INSERT INTO Cart (BuyerId, ProductId, Quantity, TotalPrice) " +
                         "VALUES (@BuyerId, @ProductId, @Quantity, @TotalPrice)";
            _db.Execute(sql, cartItem);
        }

        public void PlaceOrder(Order order)
        {
            string sql = "INSERT INTO Orders (BuyerId, ProductId, TotalPrice, OrderStatus, CreatedAt) " +
                         "VALUES (@BuyerId, @ProductId, @TotalPrice, @OrderStatus, @CreatedAt)";
            _db.Execute(sql, order);
        }

        public List<Cart> ViewCart(int buyerId)
        {
            string sql = "SELECT * FROM Cart WHERE BuyerId = @BuyerId";
            return _db.Query<Cart>(sql, new { BuyerId = buyerId }).ToList();
        }

        public List<Order> GetOrders(int buyerId)
        {
            string sql = "SELECT * FROM Orders WHERE BuyerId = @BuyerId";
            return _db.Query<Order>(sql, new { BuyerId = buyerId }).ToList();
        }
    }

}
