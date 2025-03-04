using Dapper;
using Microsoft.Data.SqlClient;
using PetMarketPlace.Models.Entities;
using PetMarketPlace.Models.Interfaces;

namespace PetMarketPlace.Models.Repositories
{
    public class BuyerRepository : IBuyerInterface
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Pets;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public BuyerEntity Login(string username, string password)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT Buyers.*, Users.Username, Users.Password 
                                 FROM Buyers 
                                 INNER JOIN Users ON Buyers.UserId = Users.UserId 
                                 WHERE Users.Username = @Username AND Users.Password = @Password";
                return connection.QueryFirstOrDefault<BuyerEntity>(query, new { Username = username, Password = password });
            }
        }

        public BuyerEntity Signup(BuyerEntity buyer)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert user and directly retrieve the generated UserId using OUTPUT
                    string userQuery = "INSERT INTO Users (Username, Password, Role) OUTPUT INSERTED.UserId VALUES (@Username, @Password, @Role)";
                    int userId = connection.ExecuteScalar<int>(userQuery, new { buyer.Username, buyer.Password, Role = "Buyer" });

                    Console.WriteLine(userId);
                    if (userId <= 0)
                    {
                        throw new Exception("Failed to retrieve a valid user ID.");
                    }

                    // Insert buyer data with the UserId
                    string buyerQuery = "INSERT INTO Buyers (UserId, Username, Password, FullName, Email, PhoneNumber) VALUES (@UserId,@Username, @Password, @FullName, @Email, @PhoneNumber)";
                    buyer.UserId = userId;
                    connection.Execute(buyerQuery, new { UserId = userId, buyer.Username, buyer.Password, buyer.FullName, buyer.Email, buyer.PhoneNumber });
                    return buyer;
                }
            }
            catch (Exception)
            {
                buyer = null;
                return buyer;
            }
        }

        public bool UserExists(string username)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Role = @Role";
                return connection.ExecuteScalar<int>(query, new { Username = username, Role = "Buyer" }) > 0;
            }
        }

        public bool ValidatePhoneNumber(string phoneNumber)
        {
            bool isValid = phoneNumber.All(char.IsDigit) || (phoneNumber[0] == '+' && phoneNumber.Substring(1).All(char.IsDigit));
            return isValid;
        }
    }
}
