using Dapper;
using DigitalNexus.Models.Entities;
using DigitalNexus.Models.Services;
using System.Data;

namespace DigitalNexus.Models.Repositories
{
    public class AdminService : IAdminService
    {
        private readonly IDbConnection _db;

        public AdminService(IDbConnection db)
        {
            _db = db;
        }

        public void AddBuyer(Buyer buyer)
        {
            string sql = "INSERT INTO Buyers (Name, Email, PhoneNumber) VALUES (@Name, @Email, @PhoneNumber)";
            _db.Execute(sql, buyer);
        }

        public void AddSeller(Seller seller)
        {
            string sql = "INSERT INTO Sellers (Name, Email, PhoneNumber, BusinessName) VALUES (@Name, @Email, @PhoneNumber, @BusinessName)";
            _db.Execute(sql, seller);
        }

        public List<Buyer> GetAllBuyers()
        {
            string sql = "SELECT * FROM Buyers";
            return _db.Query<Buyer>(sql).ToList();
        }

        public List<Seller> GetAllSellers()
        {
            string sql = "SELECT * FROM Sellers";
            return _db.Query<Seller>(sql).ToList();
        }
    }
}
