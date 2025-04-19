using Dapper;
using DigitalNexus.Models.Entities;
using DigitalNexus.Models.Services;
using System.Data;

namespace DigitalNexus.Models.Repositories
{
    public class SellerService : ISellerService
    {
        private readonly IDbConnection _db;

        public SellerService(IDbConnection db)
        {
            _db = db;
        }

        public void AddProduct(Product product)
        {
            string sql = "INSERT INTO Products (Name, Category, Brand, Condition, Price, Description, SellerId) " +
                         "VALUES (@Name, @Category, @Brand, @Condition, @Price, @Description, @SellerId)";
            _db.Execute(sql, product);
        }

        public List<Product> GetProductsBySeller(int sellerId)
        {
            string sql = "SELECT * FROM Products WHERE SellerId = @SellerId";
            return _db.Query<Product>(sql, new { SellerId = sellerId }).ToList();
        }

        public void RemoveProduct(int productId)
        {
            string sql = "DELETE FROM Products WHERE ProductId = @ProductId";
            _db.Execute(sql, new { ProductId = productId });
        }
    }
}
