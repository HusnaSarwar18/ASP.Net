using Dapper;
using DigitalNexus.Models.Entities;
using DigitalNexus.Models.Services;
using System.Data;

namespace DigitalNexus.Models.Repositories
{
    public class ProductService : IProductService
    {
        private readonly IDbConnection _db;

        public ProductService(IDbConnection db)
        {
            _db = db;
        }

        public Product GetProductById(int productId)
        {
            string sql = "SELECT * FROM Products WHERE ProductId = @ProductId";
            return _db.QuerySingleOrDefault<Product>(sql, new { ProductId = productId });
        }

        public List<Product> GetProductsByCategory(string category)
        {
            string sql = "SELECT * FROM Products WHERE Category = @Category";
            return _db.Query<Product>(sql, new { Category = category }).ToList();
        }

        public List<Product> SearchProducts(string keyword)
        {
            string sql = "SELECT * FROM Products WHERE Name LIKE @Keyword OR Description LIKE @Keyword";
            return _db.Query<Product>(sql, new { Keyword = $"%{keyword}%" }).ToList();
        }
    }
}
