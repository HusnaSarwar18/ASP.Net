using Dapper;
using Microsoft.Data.SqlClient;
using PetMarketPlace.Models.Entities;
using PetMarketPlace.Models.Interfaces;

namespace PetMarketPlace.Models.Repositories
{
    public class SellerRepository : ISellerInterface
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Pets;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public (SellerEntity?, int) Login(string username, string password)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT Sellers.*, Users.Username, Users.Password 
                                 FROM Sellers 
                                 INNER JOIN Users ON Sellers.UserId = Users.UserId 
                                 WHERE Users.Username = @Username AND Users.Password = @Password";

                var seller = connection.QueryFirstOrDefault<SellerEntity>(query, new { Username = username, Password = password });
                return seller != null ? (seller, seller.UserId) : (null, 0);
            }
        }

        public SellerEntity Signup(SellerEntity seller)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string userQuery = "INSERT INTO Users (Username, Password, Role) OUTPUT INSERTED.UserId VALUES (@Username, @Password, @Role)";
                int userId = connection.ExecuteScalar<int>(userQuery, new { seller.Username, seller.Password, Role = "Seller" });

                string sellerQuery = "INSERT INTO Sellers (UserId, Username, Password, BusinessName, BusinessAddress, ContactNumber, Website) VALUES (@UserId, @Username, @Password,  @BusinessName, @BusinessAddress, @ContactNumber, @Website)";
                seller.UserId = userId;
                connection.Execute(sellerQuery, new { UserId = userId, seller.Username, seller.Password, seller.BusinessName, seller.BusinessAddress, seller.ContactNumber, seller.Website });

                return seller;
            }
        }

        public bool UserNotExists(string username)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Role = @Role";
                return connection.ExecuteScalar<int>(query, new { Username = username, Role = "Seller" }) == 0;
            }
        }
    }
}
