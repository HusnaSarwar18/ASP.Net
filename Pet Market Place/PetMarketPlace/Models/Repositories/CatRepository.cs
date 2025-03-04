using Dapper;
using Microsoft.Data.SqlClient;
using PetMarketPlace.Models.Entities;
using PetMarketPlace.Models.Interfaces;

namespace PetMarketPlace.Models.Repositories
{
    public class CatRepository : ICatInterface
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Pets;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public void AddCat(CatEntity cat, int sellerId)
        {
            string query = @"INSERT INTO Cat (CatType, CatAge, CatColor, CatPrice, CatPicturePath, SellerId) 
                             VALUES (@CatType, @CatAge, @CatColor, @CatPrice, @CatPicturePath, @SellerId)";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(query, new { cat.CatType, cat.CatAge, cat.CatColor, cat.CatPrice, cat.CatPicturePath, SellerId = sellerId });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error Occurred: " + ex.Message);
            }
        }

        public bool UpdateCat(CatEntity cat)
        {
            if (!CatExists(cat.CatId)) return false;

            string query = @"UPDATE Cat 
                             SET CatType = @CatType, CatAge = @CatAge, CatColor = @CatColor, CatPrice = @CatPrice, CatPicturePath = @CatPicturePath 
                             WHERE CatId = @CatId";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(query, new { cat.CatType, cat.CatAge, cat.CatColor, cat.CatPrice, cat.CatPicturePath, cat.CatId });
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error Occurred: " + ex.Message);
                return false;
            }
        }

        public bool DeleteCat(int catId)
        {
            if (!CatExists(catId)) return false;

            string query = "DELETE FROM Cat WHERE CatId = @CatId";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    int rowsAffected = connection.Execute(query, new { CatId = catId });
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error Occurred: " + ex.Message);
                return false;
            }
        }

        private bool CatExists(int catId)
        {
            string query = "SELECT COUNT(1) FROM Cat WHERE CatId = @CatId";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    return connection.ExecuteScalar<int>(query, new { CatId = catId }) > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error Occurred: " + ex.Message);
                return false;
            }
        }
    }
}
